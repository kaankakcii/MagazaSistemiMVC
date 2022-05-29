using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaSistem.Entites.Models
{
    public class InvoiceAndProduct
    {
     
            [Key]
            public int InvoiceAndProductId { get; set; }
            public int InvoiceId { get; set; }
            public virtual Invoice Invoice { get; set; }
            public int ProductId { get; set; }  
            public virtual Product Product { get; set; }
            public int ToplamFiyat { get; set; }



    }
}
