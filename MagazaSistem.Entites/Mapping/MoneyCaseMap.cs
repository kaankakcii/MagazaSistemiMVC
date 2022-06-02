using MagazaSistem.Entites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaSistem.Entites.Mapping
{

    public class MoneyCaseMap : EntityTypeConfiguration<MoneyCase>
    {
        public MoneyCaseMap()
        {

            this.ToTable("tblMoneyCase");
            this.Property(p => p.MoneyCaseId).HasColumnType("int");
            this.Property(p => p.MoneyCaseId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.MoneyCaseName).HasColumnType("varchar").HasMaxLength(500);
            this.Property(p => p.MoneyCaseStatus).HasColumnType("bit");
            


        }
    }
}


