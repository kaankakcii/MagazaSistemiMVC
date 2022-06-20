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

        [Required(ErrorMessage = "Lütfen Personel İsmini Giriniz.")]
        public string PersonelName { get; set; }
        public string PersonelSurname { get; set; }

        [Required(ErrorMessage = "Lütfen Personel Telefonu Giriniz.")]
        public int PersonelTelephone { get; set; }
        public string PersonelPassword { get; set; }

        [Required(ErrorMessage = "Lütfen Personel Mail Adresinizi Giriniz.")]
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
