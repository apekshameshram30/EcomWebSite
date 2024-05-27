using Application.DTOs;
using Application.Interface;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Command
{
    public class UpdateProduct:IRequest<string>
    {
        public int ProductId { get; set; }
        public ProductDTO? ProductDto { get; set; }
    }
    public class UpdateProductHandler:IRequestHandler<UpdateProduct, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateProduct request,CancellationToken cancellationToken)
        {
            var updateProduct= await _context.Products.FindAsync(request.ProductId);
            if (updateProduct == null)
            {
                return "Product Not Found";
            }
            _mapper.Map(request.ProductDto, updateProduct);
            await _context.SaveChangesAsync();
            return "Product Update Successfully";
        }
    }

}
