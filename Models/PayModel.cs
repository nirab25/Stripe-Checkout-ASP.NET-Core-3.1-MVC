using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StripeCheckout.Models
{
    public class PayModel
    {
        [Required]
        [Display(Name = "Cardholder Name")]
        public string CustomerName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "Card Number")]
        public string CardNumder { get; set; }

        [Required]
        [Display(Name = "Expiration Month")]
        public int Month { get; set; }

        [Required]
        [Display(Name = "Expiration Year")]
        public int Year { get; set; }

        [Required]
        public string CVC { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}
