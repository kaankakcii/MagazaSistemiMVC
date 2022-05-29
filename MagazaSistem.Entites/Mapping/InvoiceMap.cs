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
    public class InvoiceMap : EntityTypeConfiguration<Invoice>
    {
        public InvoiceMap()
        {

            this.ToTable("tblInvoice");
            this.Property(p => p.InvoiceId).HasColumnType("int");
            this.Property(p => p.InvoiceId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.InvoiceNo).HasColumnType("float");
            this.Property(p => p.AraToplam).HasColumnType("int");
            this.Property(p => p.Kdv).HasColumnType("int");
            this.Property(p => p.Indirim).HasColumnType("int");
            this.Property(p => p.Toplam).HasColumnType("int");
            this.Property(p => p.DüzenlenmeTarihi).HasColumnType("datetime");
            this.Property(p => p.Sorumlu).HasColumnType("varchar");



        }
    }
}
