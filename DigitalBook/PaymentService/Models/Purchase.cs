using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaymentService.Models
{
    public partial class Purchase
    {
        public int PurchaseId { get; set; }
        [Required]
        public string? EmailId { get; set; }
        public int? BookId { get; set; }
        public DateTime? PurchaseDate { get; set; }
        [Required]
        public string? PaymentMode { get; set; }

        public virtual Book? Book { get; set; }
    }
}
