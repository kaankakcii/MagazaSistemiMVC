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
    public class ProductMap : EntityTypeConfiguration<Product>
    {

        public ProductMap()
        {

            this.ToTable("tblProduct");
            this.Property(p => p.ProductId).HasColumnType("int");
            this.Property(p => p.ProductId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.ProductName).HasColumnType("varchar").HasMaxLength(100);
            this.Property(p => p.ProductStockCode).HasColumnType("varchar");
            this.Property(p => p.ProductStockAmount).HasColumnType("int");
            this.Property(p => p.ProductPrice).HasColumnType("int");
            this.Property(p => p.ProductBarcode).HasColumnType("float");
            this.Property(p => p.ProductDiscountedPrice).HasColumnType("int");
            this.Property(p => p.ProductPurchasePrice).HasColumnType("int");
            this.Property(p => p.ProductImage).HasColumnType("varchar");

            this.HasRequired(p => p.Category).WithMany(p => p.Products).HasForeignKey(p => p.CategoryId);
            this.HasRequired(p => p.Subcategory).WithMany(p => p.Products).HasForeignKey(p => p.SubcategoryId);
            this.HasRequired(p => p.Brand).WithMany(p => p.Products).HasForeignKey(p => p.BrandId);
            this.HasRequired(p => p.Color).WithMany(p => p.Products).HasForeignKey(p => p.ColorId);

        }
    }
}
