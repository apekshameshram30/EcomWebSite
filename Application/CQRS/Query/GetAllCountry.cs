using Application.Interface;
using AutoMapper;
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
    public class GetAllCountry:IRequest<List<Country>>
    {
    }
    public class GetCountryHandler:IRequestHandler<GetAllCountry, List<Country>>
    {
        private readonly IApplicationDbContext _context;
       // private readonly IMapper _mapper;

        public GetCountryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
           // _mapper = mapper;
        }

        public async Task<List<Country>> Handle(GetAllCountry request, CancellationToken cancellationToken)
        {
            var country = await _context.Countries.ToListAsync();
            return country;
        }
    }
}
