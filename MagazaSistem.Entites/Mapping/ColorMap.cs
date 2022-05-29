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
    public class ColorMap : EntityTypeConfiguration<Color>
    {
        public ColorMap()
        {
            this.ToTable("tblColor");
            this.Property(p => p.ColorId).HasColumnType("int");
            this.Property(p => p.ColorId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.ColorName).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.colorHex).HasColumnType("varchar").HasMaxLength(100);
            

        }
    }
}
