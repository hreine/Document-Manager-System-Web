using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;


namespace Reines.dmsflex.Dao.mes
{

    public class PcalendarioMap : ClassMap<Pcalendario>
    {

        public PcalendarioMap()
        {
            Table("mes.pcalendario");
            LazyLoad();
            Id(x => x.CalNcodigo).GeneratedBy.Assigned().Column("cal_ncodigo");
            Map(x => x.CalFfecha).Column("cal_ffecha");       
            Map(x => x.CalCobservacion).Column("cal_cobservacion");       
        }
    }
}