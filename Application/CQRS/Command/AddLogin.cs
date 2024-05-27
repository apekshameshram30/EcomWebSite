using Application.DTOs;
using Application.Interface;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Command
{
    public class AddLogin :IRequest<string>
    {
        public LoginDTO? loginDto { get; set; } 
    }
    public class AddloginHandler : IRequestHandler<AddLogin, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;


        public AddloginHandler(IApplicationDbContext context, IMapper mapper ) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Handle(AddLogin request,CancellationToken cancellationToken)
        {
            var user = await _context.Register.FirstOrDefaultAsync(a => a.Username == request.loginDto.UserName);
            if (user != null)
            {
                return "Login Successfull";
            }
          
            return "Login fails Try Again";
           
        }
    }
}
