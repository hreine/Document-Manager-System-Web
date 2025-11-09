using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.model
{
    [Table("tusuario", Schema = "mes")]
    public class Tusuario
    {
        [Key]
        [Column("usu_ccodigo")]
        public string aud_cusuario { get; set; }
        public string aud_cestado { get; set; }
        public DateTime aud_ffecha { get; set; }
        public string usu_ccodigo { get; set; }                      
        public decimal sed_ncodigo { get; set; }
        public string usu_ccedula { get; set; }
        public string usu_cnombre { get; set; }
        public string usu_capellido { get; set; }
        public string usu_cemail { get; set; }
        public string usu_cclave { get; set; }
        public string usu_cobliga { get; set; }
        public string usu_csadmin { get; set; }
        public decimal usu_ntimeout { get; set; }
        public string usu_creexpedicion { get; set; }                 
    }
}
