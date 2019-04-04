using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CimatecRecords.Models
{
    public class Publicacao
    {
        [Key]
        public int PK_Publicacao { get; set; }
        public string Data { get; set; }
        [ForeignKey("Letra")]
        public int Fk_Letra { get; set; }
        public virtual Letra Letra { get; set; }

        public bool validaPublicacao()
        {
            if(Letra.Compositor.Idade >= 18)
            {
                return true;
            }
            else
            {
                if(Letra.Compositor.Fk_Responsavel != null)
                {

                    return true;
                }
            }
            return false;
        }
    }
}