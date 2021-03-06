using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaSistem.Entites.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Lütfen Ürünün ismini Giriniz.")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Lütfen Ürünün Stok Kodu Bilgisini Giriniz.")]
        public string ProductStockCode { get; set; }

        public int ProductStockAmount { get; set; }
        public int ProductPrice { get; set; }

        [Required(ErrorMessage = "Lütfen Ürünün Bardok Bilgisini Giriniz.")]
        public int ProductBarcode { get; set; }

        public int ProductDiscountedPrice { get; set; }
        public bool ProductStatus { get; set; }


        [Required(ErrorMessage = "Lütfen Ürünün Resmini Giriniz.")]
        public string ProductImage { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<InvoiceAndProduct> InvoiceAndProducts { get; set; }

        public int ProductPurchasePrice { get; set; }

        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

        public int ColorId { get; set; }
        public virtual Color Color { get; set; }

        public int SubcategoryId { get; set; }
        public virtual Subcategory Subcategory { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


    }
}
