using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaSistem.Entites.Models
{
    public class Personnel
    {
        [Key]
        public int PersonelId { get; set; }
        public string PersonelName { get; set; }
        public string PersonelSurname { get; set; }
        public int PersonelTelephone { get; set; }
        public string PersonelPassword { get; set; }
        public string PersonelMail { get; set; }
        public string PersonelAddress { get; set; }
        public string PersonelEmploymentDate { get; set; }
        public int PersonelAge { get; set; }

        public int AuthorityId { get; set; }
        public virtual Authority Authority { get; set; }

        public bool PersonelStatus { get; set; }
        public int PersonelWage { get; set; }
    }
}
