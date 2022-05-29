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
    public class CategoryMap : EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            this.ToTable("tblCategory");
            this.Property(p => p.CategoryId).HasColumnType("int");
            this.Property(p => p.CategoryId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.CategoryName).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.Explanation).HasColumnType("varchar").HasMaxLength(500);

            this.Property(p => p.ImageUrl).HasColumnType("varchar").HasMaxLength(700);


        }
    }
}
