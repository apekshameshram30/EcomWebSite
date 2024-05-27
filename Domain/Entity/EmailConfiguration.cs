using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class EmailConfiguration
    {
        public string From { get; set; } = null!;

        public string SmtpServer { get; set; } = null!;

        public string Port { get; set; } = null!;

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
