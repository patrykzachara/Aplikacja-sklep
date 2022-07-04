using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.Models
{
    public class SummaryOfCustomerPurchases
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public List<ProductSale> Sales { get; set; }
        public DateTime SellDate { get; set; }
    }
}
