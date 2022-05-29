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
    public class InvoiceAndProductMap : EntityTypeConfiguration<InvoiceAndProduct>
    {
        public InvoiceAndProductMap()
        {

            this.ToTable("tblInvoiceAndProduct");
            this.Property(p => p.InvoiceAndProductId).HasColumnType("int");
            this.Property(p => p.InvoiceAndProductId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.InvoiceId).HasColumnType("int");
            this.Property(p => p.ProductId).HasColumnType("int");
            this.Property(p => p.ToplamFiyat).HasColumnType("int");

            this.HasRequired(p => p.Invoice).WithMany(p => p.InvoiceAndProducts).HasForeignKey(x => x.InvoiceId);
            this.HasRequired(p => p.Product).WithMany(p => p.InvoiceAndProducts).HasForeignKey(x => x.ProductId);



        }
    }
}
