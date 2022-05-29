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
    public class BrandMap : EntityTypeConfiguration<Brand>
    {
        public BrandMap()
        {

            this.ToTable("tblBrand");
            this.Property(p => p.BrandId).HasColumnType("int");
            this.Property(p => p.BrandId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.BrandName).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.BrandImgUrl).HasColumnType("varchar").HasMaxLength(500);
            this.Property(p => p.Explanation).HasColumnType("varchar").HasMaxLength(500);


        }
    }
}
