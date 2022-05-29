using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaSistem.Entites.Models
{
    public class ProductAndInvoiceProduct
    {
        public virtual IEnumerable<Product> Products { get; set; }
        
        public virtual IEnumerable<InvoiceAndProduct> InvoiceAndProducts { get; set; }
        
    
    }
}
