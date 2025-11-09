using System;

using Reines.dmsflex.BLL.mes;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ParametrosBll())
            {
                var productos = context.SelectAllFechas(25754000);
                foreach (var cust in productos)
                {
                    Console.WriteLine(cust.CalFfecha);
                }
                Console.WriteLine("fin");
                Console.ReadLine();
            }

        }
    }
}
