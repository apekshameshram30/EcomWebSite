using Application.DTOs;
using Application.Interface;
using AutoMapper;
using Domain.Entity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.CQRS.Command
{
    public class AddRegistration:IRequest<object>
    {
        public RegistrationDTO? registrationDto { get; set; }
    }
    public class AddHandler : IRequestHandler<AddRegistration, object>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
       private readonly IEmailService _emailService;
        private readonly IFileService _fileService;
        private readonly IImageFile _imageFile;

        public AddHandler(IApplicationDbContext context, IMapper mapper
                         , IEmailService emailService
                         , IFileService fileService,
                           IImageFile imageFile
                           )
        {
            _context = context;
            _mapper = mapper;
            _emailService = emailService;
            _fileService = fileService;
            _imageFile = imageFile;
        }

        public async Task<object> Handle(AddRegistration request, CancellationToken cancellationToken)
        {
            if(request.registrationDto!= null && request.registrationDto.image != null)
            {
                var sampleRegistr = await _context.Register.FirstOrDefaultAsync(a =>
               request.registrationDto != null && a.FirstName == request.registrationDto.FirstName);
                string fileName = null;

                if (sampleRegistr == null
                    // && request.registrationDto.image != null
                    )
                {
                    fileName = await _fileService.SaveImage(request.registrationDto.image);
                    var username = GenerateUsername(request.registrationDto.LastName, request.registrationDto.FirstName, request.registrationDto.DOB);
                    var password = GeneratePassword();
                    var registr = _mapper.Map<Registration>(request.registrationDto);
                    registr.Username = username;
                    registr.Password = password;
                    registr.Image = fileName;

                    _context.Register.Add(registr);

                    await _context.SaveChangesAsync();
                    await SendWelcomeEmail(registr);
                }
            }
            return new { msg = "Added Successfully" };

        }

                       

        #region Private Method
        private string GenerateUsername(string lastname, string firstname, DateTime Dob)
        {
            var dobFormat = Dob.ToString("ddMMyy");

            var username = $"EC_{lastname.ToUpper()}{firstname.ToUpper()[0]}{dobFormat}";

            return username;
        }

        private string GeneratePassword()
        {
            const string passFormat = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            StringBuilder stringBuilder = new StringBuilder();
            Random random = new Random();
            while(stringBuilder.Length < 8)
            {
                stringBuilder.Append(passFormat[random.Next(passFormat.Length)]);
            }
            return stringBuilder.ToString();

        }
        #endregion
        private async Task SendWelcomeEmail(Registration registration)
        {
            _emailService.SendEmailAsync(registration.Email, registration.FirstName, registration.Username, registration.Password);
        }
    }
}
