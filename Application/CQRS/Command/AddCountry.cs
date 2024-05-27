using Application.DTOs;
using Application.Interface;
using AutoMapper;
using Domain.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Command
{
    public class AddCountry:IRequest<string>
    {
        public CountryDTO countryDto { get; set; }
    }
    public class AddCountryHandler : IRequestHandler<AddCountry, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AddCountryHandler( IApplicationDbContext context,IMapper mapper)
        {   
            _context = context;
            _mapper = mapper;
        }
        public async Task<string> Handle(AddCountry request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.countryDto?.CountryName))
            {
                return "Country name is null or empty";
            }

            var addCountry = _mapper.Map<Country>(request.countryDto);
            _context.Countries.Add(addCountry);
            await _context.SaveChangesAsync();

            return "Country Added";
        }

    }
}
