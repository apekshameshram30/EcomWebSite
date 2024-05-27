using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public  class SendOTP
    {
        [Key]
        public int Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }    
        public string Otp { get; set; }

    }
}
