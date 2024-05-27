using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class PaymentGateway
    {
        [Key]
        public int PaymentId { get; set; }
        public decimal Amount { get; set; }
        public string? Currency {  get; set; }
        public string? PaymentMethod {  get; set; }
        public int CardNumber   { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
