using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaSistem.Entites.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public float InvoiceNo { get; set; }
        public int AraToplam { get; set; }
        public int  Kdv { get; set; }
        public int Indirim { get; set; }
        public int Toplam { get; set; }
        public DateTime DüzenlenmeTarihi { get; set; }
        public String Sorumlu { get; set; }





        public virtual ICollection<InvoiceAndProduct> InvoiceAndProducts { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
