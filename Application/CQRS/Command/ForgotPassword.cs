using Application.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entity;

namespace Application.CQRS.Command
{
    public class ForgotPassword:IRequest<string>
    {
        public string? Email { get; set; }
    }
    public class ForgotPasswordHandler:IRequestHandler<ForgotPassword, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IEmailService _emailService;

        public ForgotPasswordHandler(IApplicationDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<string> Handle(ForgotPassword request,CancellationToken cancellationToken)
        {
            var user=  await _context.Register.FirstOrDefaultAsync(e =>e.Email== request.Email);

            if (user==null)
            {
                return "Email not found";
            }
            string newPassword = GeneratePassword();
            user.Password = newPassword;

            await _context.SaveChangesAsync();

            await SendNewPasswordEmail(user.Email, user.FirstName, newPassword);

            return "done";
        }

        private string GeneratePassword()
        {
            const string passFormat = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            while (stringBuilder.Length < 8)
            {
                stringBuilder.Append(passFormat[random.Next(passFormat.Length)]);
            }
            return stringBuilder.ToString();
        }

        private async Task SendNewPasswordEmail(string email, string firstName, string newPassword)
        {
            _emailService.SendEmailAsync(email, "Password Reset", $"Dear {firstName}, Your new password is: ", newPassword);

        }

    }
}
