using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interface
{
    public interface IEmailService
    {
        void SendEmailAsync(string _emailTo, string _name, string _username, string _password);
    }
}
