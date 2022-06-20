using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagazaSistem.Entites.Models
{
    public class MoneyCase
    {
        [Key]
        public int MoneyCaseId { get; set; }

        [Required(ErrorMessage = "Lütfen Kasa İsmi İsmini Giriniz.")]
        public string MoneyCaseName { get; set; }
        public string MoneyCaseAdres { get; set; }
        public bool MoneyCaseStatus { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
