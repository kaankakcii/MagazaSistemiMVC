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
    public class SubcategoryMap : EntityTypeConfiguration<Subcategory>
    {
        public SubcategoryMap()
        {
            this.ToTable("tblSubcategory");
            this.Property(p => p.SubcategoryId).HasColumnType("int");
            this.Property(p => p.SubcategoryId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.SubcategoryName).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.Explanation).HasColumnType("varchar").HasMaxLength(500);
            this.Property(p => p.ImageUrl).HasColumnType("varchar").HasMaxLength(700);

            this.HasRequired(p => p.Category).WithMany(p => p.Subcategories).HasForeignKey(p => p.CategoryId).WillCascadeOnDelete(false);




        }
    }
}

