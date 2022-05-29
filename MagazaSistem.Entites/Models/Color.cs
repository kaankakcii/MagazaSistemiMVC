using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaSistem.Entites.Models
{
    public class Color
    {
        public int ColorId { get; set; }
        public string ColorName { get; set; }
        public bool ColorStatus { get; set; }
        public string colorHex { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
