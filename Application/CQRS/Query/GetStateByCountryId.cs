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
    public class GetStateByCountryId :IRequest<List<State>>
    {
        public int CountryId { get; set; }
    }
    public class GetSByCIdHandler:IRequestHandler<GetStateByCountryId, List<State>>
    {
        private readonly IApplicationDbContext _context;

        public GetSByCIdHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<State>> Handle(GetStateByCountryId request, CancellationToken cancellationToken)
        {
            var state = await _context.States.Where(state => state.CountryId == request.CountryId).ToListAsync();
            return state;
        }
    }
}
