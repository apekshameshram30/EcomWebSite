using Application.Interface;
using Domain.Entity;
using Infrastructure;

namespace Web.Implementation
{
    public class ImageFile :IImageFile
    {
      private readonly ApplicationDbContext _context;

        public ImageFile(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Registration model)
        {
            try
            {
                _context.Register.Add(model);
                _context.SaveChanges();
                return true;
            }
            catch 
            {
                return false;
            }
        }


    }
}
