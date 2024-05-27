using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class PaymentDTO
    {
        public decimal Amount { get; set; }
        public string? Currency { get; set; }
        public string? PaymentMethod { get; set; }
        public int CardNumber { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

    }
}
