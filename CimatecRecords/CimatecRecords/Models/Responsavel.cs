using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CimatecRecords.Models
{
    public class Responsavel
    {
      [Key]
        public int Pk_Responsavel  { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public virtual ICollection<Compositor>Compositores { get; set; }
    }
}