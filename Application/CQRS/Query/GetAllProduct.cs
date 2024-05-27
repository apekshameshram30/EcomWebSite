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

namespace Application.CQRS.Query
{
    public class GetAllProduct :IRequest<List<ProductDTO>>
    {

    }

    public class GetProductHandler : IRequestHandler<GetAllProduct,List<ProductDTO>>
    {
        private readonly IMapper _mapper;

        private readonly IApplicationDbContext _context;

        public GetProductHandler(IMapper mapper, IApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<ProductDTO>> Handle(GetAllProduct request, CancellationToken cancellationToken)
        {
            var productList = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductDTO>>(productList);
        }
    }
}
