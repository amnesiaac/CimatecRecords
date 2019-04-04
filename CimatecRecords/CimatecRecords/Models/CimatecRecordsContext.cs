using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CimatecRecords.Models
{
    public class CimatecRecordsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public CimatecRecordsContext() : base("name=CimatecRecordsContext")
        {
        }

        public System.Data.Entity.DbSet<CimatecRecords.Models.Compositor> Compositors { get; set; }

        public System.Data.Entity.DbSet<CimatecRecords.Models.Responsavel> Responsavels { get; set; }

        public System.Data.Entity.DbSet<CimatecRecords.Models.Letra> Letras { get; set; }

        public System.Data.Entity.DbSet<CimatecRecords.Models.Publicacao> Publicacaos { get; set; }
    }
}
