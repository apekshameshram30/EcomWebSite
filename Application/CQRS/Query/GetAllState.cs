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
    public class GetAllState:IRequest<List<State>>
    {

    }
    public class GetStateHandler:IRequestHandler<GetAllState, List<State>>
    {
        private readonly IApplicationDbContext _context;

        public  GetStateHandler(IApplicationDbContext context)
        {
            _context= context;
        }
        public async Task<List<State>> Handle(GetAllState request,CancellationToken cancellationToken)
        {
            var state = await _context.States.ToListAsync();
            return state;
        }

    }
}
