using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class RegistrationDTO
    {
        //public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }= null!;
        public string? Email { get; set; }
        public string? UserType { get; set; }
        public DateTime DOB { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public int Zipcode { get; set; }

        // public string? Image { get; set; }

        [NotMapped]
        public IFormFile? image { get; set; }
        public int StateId { get; set; }
        public int CountryId { get; set; }
       
    }
}
