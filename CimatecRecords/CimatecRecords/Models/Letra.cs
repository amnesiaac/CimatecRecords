using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CimatecRecords.Models
{
    public class Letra
    {
        [Key]
        public int Pk_Letra { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public bool Publicada { get; set; }
        [ForeignKey("Compositor")]
        public int Fk_Compositor { get; set; }
        public virtual Compositor Compositor { get; set; }
       
    }
}