using Application.Interface;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Query
{
    public class GetRegistrationById:IRequest<List<Registration>>
    {
        public int Id { get; set; }
    }
    public class GetRegistrationByIdHandler:IRequestHandler<GetRegistrationById, List<Registration>>
    {
        private readonly IApplicationDbContext _context;

        public GetRegistrationByIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Registration>> Handle(GetRegistrationById request,  CancellationToken cancellationToken)
        {
            var registerId = await _context.Register.Where(r => r.Id == request.Id).ToListAsync();

            return registerId;
        }
    }
}
