using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaSistem.Entites.Models
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }

        [Required(ErrorMessage = "Lütfen Marka İsmini Giriniz.")]
        public string BrandName { get; set; }
        public string BrandImgUrl { get; set; }
        public bool BrandStatus { get; set; }
        public string Explanation { get; set; }
        public virtual ICollection<Product> Products { get; set; }


    }
}
