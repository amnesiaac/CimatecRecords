using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CimatecRecords.Models
{
    public class Compositor
    {
        [Key]
        public int Pk_Compositor { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public int Idade { get; set; }
        public virtual ICollection<Letra> Letras { get; set; }
        [ForeignKey("Responsavel")]
        public int? Fk_Responsavel { get; set; }
        public virtual Responsavel Responsavel { get; set; }
    }
}