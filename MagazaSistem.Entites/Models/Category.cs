using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaSistem.Entites.Models
{
    public class Category
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryStatus { get; set; }
        public string Explanation { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Subcategory> Subcategories { get; set; }
    }
}
