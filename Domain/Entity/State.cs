using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entity
{
    public class State
    {
        [Key]
        public int Id { get; set; }
        public string? StateName { get; set; }

        public int CountryId { get; set; }
        public Country? Country { get; set; }
    }
}
