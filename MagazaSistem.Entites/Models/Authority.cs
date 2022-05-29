using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaSistem.Entites.Models
{
    public class Authority
    {
        public int AuthorityId { get; set; }
        public string AuthorityName { get; set; }
        public bool AuthorityStatus { get; set; }
        public virtual ICollection<Personnel> Personnels { get; set; }
    }
}
