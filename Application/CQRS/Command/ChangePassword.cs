using Application.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Command
{
    public class ChangePassword :IRequest<string>
    {
        public string? Email { get; set; }
        public string? OldPassword { get; set; }
        public string? NewPassword { get; set; } 
        public string? ConfermPassword { get; set; }
    }

    public class ChangePasswordHandler:IRequestHandler<ChangePassword, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public ChangePasswordHandler(IApplicationDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<string> Handle(ChangePassword request,CancellationToken cancellationToken)
        {
            var user= await _context.Register.FirstOrDefaultAsync(r=>r.Email== request.Email);

            if (user == null|| user.Password!= request.OldPassword)
            {
                return "invalid Email or Password";
            }
            if(request.NewPassword!= request.ConfermPassword)
            {
                return "New Password and Conferm Password are not Same";
            }

            user.Password = request.NewPassword;
            await _context.SaveChangesAsync();
            _emailService.SendEmailAsync(user.Email, "PassWord Change Successfully", $"Dear {user.FirstName} your UserName is {user.Username} and New Password is:", request.NewPassword);
            return "Password Change Successfull";
        }
    }
}
