using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Reflection;
using System.Text.RegularExpressions;
using NHibernate;

namespace Reines.dmsflex.Dao
{
    public class ClaseBase : IDisposable
    {
        private static ISession _contexto;

        public static ISession Contexto
        {
            get
            {
                if (UnitOfWorkScope.CurrentObjectContext != null)
                {
                    if (UnitOfWorkScope.CurrentObjectContext.Connection.State == ConnectionState.Broken ||
                        UnitOfWorkScope.CurrentObjectContext.Connection.State == ConnectionState.Closed)
                    {
                        UnitOfWorkScope.CurrentObjectContext.Connection.Close();
                        UnitOfWorkScope.CurrentObjectContext.Connection.Open();
                    }
                    return UnitOfWorkScope.CurrentObjectContext;
                }
                else
                {
                    if (_contexto != null)
                    {
                        return _contexto;
                    }
                    return _contexto;
                }
            }
            set { _contexto = value; }
        }


        private string Extraemensaje(string mensaje)
        {
            var mensajes =
                new Regex("(<msg>)(.*?)(</msg>)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            MatchCollection mensajesColl = mensajes.Matches(mensaje);
            if (mensajesColl.Count > 0)
            {
                return mensajesColl[0].Value.Replace("<msg>", "").Replace("</msg>", "");
            }
            return mensaje;
        }


        protected void ManageEx(Exception ex)
        {
            if (ex.Message.StartsWith("ORA-"))
            {
                string[] msg = ex.Message.Split(':');
                if (msg.Length > 0)
                {
                    if (msg.Length > 1)
                    {
                        if (msg[0].Trim() == "ORA-04068")
                        {
                            throw new Exception("Por favor intente nuevamente; " + msg[1] +
                                                (msg.Length > 2 ? msg[2] : " "));
                        }
                        string mensaje = Extraemensaje(ex.Message);
                        throw new Exception(mensaje, ex);
                    }
                }
            }
        }


        public static DataTable ListToDataTable(IDataReader dr)
        {
            var dt = new DataTable();
            dt.Load(dr);
            return dt;
        }


        public static DataTable ListToDataTable<T>(IList<T> data)
        {
            var table = new DataTable();
            //special handling for value types and string
            if (typeof (T).IsValueType || typeof (T).Equals(typeof (string)))
            {
                var dc = new DataColumn("Value");

                table.Columns.Add(dc);

                foreach (T item in data)
                {
                    DataRow dr = table.NewRow();
                    dr[0] = item;

                    table.Rows.Add(dr);
                }
            }
            else
            {
                PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof (T));
                foreach (PropertyDescriptor prop in properties)
                {
                    table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
                }

                foreach (T item in data)
                {
                    DataRow row = table.NewRow();
                    foreach (PropertyDescriptor prop in properties)
                    {
                        try
                        {
                            row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                        }
                        catch (Exception)
                        {
                            row[prop.Name] = DBNull.Value;
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        public static Object GetPropValue(Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null)
                {
                    return null;
                }

                Type type = obj.GetType();
                //var listap = type.GetProperties();
                PropertyInfo info = type.GetProperty(part);
                if (info == null)
                {
                    return null;
                }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static T GetPropValue<T>(Object obj, String name)
        {
            Object retval = GetPropValue(obj, name);
            if (retval == null)
            {
                return default(T);
            }

            // throws InvalidCastException if types are incompatible
            return (T) retval;
        }


        public string CutField(string value, int maxLength)
        {
            //var cadutf8 = Encoding.Unicode.GetString(Encoding.Default.GetBytes(value));
            try
            {
                return value.Trim().Substring(0, maxLength);
            }
            catch (ArgumentOutOfRangeException)
            {
                return value.Trim();
            }
        }

        public void Dispose()
        {
            if (Contexto != null)
            {
                if (Contexto.Connection.State == ConnectionState.Open)
                {
                    Contexto.Connection.Close();
                }
                Contexto.Connection.Dispose();
                Contexto.Dispose();
                Contexto = null;
            }
        }
    }
}