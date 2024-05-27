using Application.Interface;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Clients;

namespace Application.CQRS.Command
{
    public class VerificationOfOtp :IRequest<string>
    {
        public VerifyOtp? verifyOTP {  get; set; }
    }
    public class VerifyOtpHandler : IRequestHandler<VerificationOfOtp, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly ITwilioRestClient _client;

        public VerifyOtpHandler(IApplicationDbContext context, ITwilioRestClient client)
        {
            _context = context;
            _client = client;
        }
        public async Task<string> Handle(VerificationOfOtp request, CancellationToken cancellation)
        {
            var otp = await _context.sendOTPs.FirstOrDefaultAsync(o => o.Otp == request.verifyOTP.Opt);

            if(otp != null)
            {
                _context.sendOTPs.Remove(otp);
                await _context.SaveChangesAsync();
                return "Successfull";
            }
            else
            {
                return "Fails";
            }
           
        }


    }
}
