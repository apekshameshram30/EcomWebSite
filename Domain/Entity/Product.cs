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
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductImage { get; set; }
        [NotMapped]
        public IFormFile? formFile { get; set; }
        public string? Category { get; set; }
        public string? Brand { get; set; }
        public float? SellingPrice { get; set; }
        public float? PurchasePrice { get; set; }
        public DateTime? SellingDate { get; set; }
        public int Stock {  get; set; }
    }
}
