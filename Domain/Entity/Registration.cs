using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? UserType { get; set; }
        public DateTime DOB { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public int Zipcode { get; set; }


        public string? StateId { get; set; }
        public State? State {  get; set; }
        public int? CountryId { get; set; }
        public Country? Country { get; set; }



        [NotMapped]
        public IFormFile? image { get; set; }
        public string? Image { get; set; }
    }

    
     
}
