using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaSistem.Entites.Models
{
   public class Subcategory
    {
        [Key]
        public int SubcategoryId { get; set; }
        public string SubcategoryName { get; set; }
        public bool SubcategoryStatus { get; set; }
        public string Explanation { get; set; }
        public int CategoryId { get; set; }
        public string ImageUrl { get; set; }
        
        public virtual Category Category { get; set; }

        public virtual ICollection<Product> Products { get; set; }


    }
}
