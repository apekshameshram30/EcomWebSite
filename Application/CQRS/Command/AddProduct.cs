using Application.DTOs;
using Application.Interface;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Command
{
    public class AddProduct :IRequest<string>
    {
        public ProductDTO? productDto { get; set; }
    }

    public class AddProductHandler:IRequestHandler<AddProduct, string>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
       // private readonly IFileService _fileService;
       // private readonly IImageFile _imageFile;

        public AddProductHandler(IApplicationDbContext context, IMapper mapper
            //, IFileService fileService, IImageFile imageFile
            )
        {
            _context = context;
            _mapper = mapper;
           // _fileService = fileService;
           // _imageFile = imageFile;
        }

        public async Task<string> Handle(AddProduct request, CancellationToken cancellationToken)
        {
            
            var addProduct = _mapper.Map<Product>(request.productDto);

            //Have to Generate ProductCode
            addProduct.ProductCode = GenerateCode();

            if (addProduct.SellingPrice <= addProduct.PurchasePrice)
            {
                return "Fails";
            }
            _context.Products.Add(addProduct);
            await _context.SaveChangesAsync();

            return "Add Product Successfully";

        }
        private string GenerateCode()
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@#$%&*";

            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            while (stringBuilder.Length < 6)
            {
                stringBuilder.Append(validChars[random.Next(validChars.Length)]);
            }
            return stringBuilder.ToString();
        }
    }
}
