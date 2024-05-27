using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interface
{
    public  interface IFileService
    {
        public Task<string> SaveImage(IFormFile imageFile);
       
    }
}
