using Application.Interface;

namespace ECom.Implementation
{
    public class FileService : IFileService
    {
        private readonly IApplicationDbContext _environment;
        public FileService(IApplicationDbContext environment)
        {
            _environment = environment;
        }
        public Task<string> SaveImage(IFormFile imageFile)
        {
            try
            {
                var path = Path.Combine("wwwroot", "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var ext = Path.GetExtension(imageFile.FileName);
                string uniqueString = Guid.NewGuid().ToString();
                var newFileName = uniqueString + ext;
                var fileWithPath = Path.Combine(path, newFileName);

                using (var stream = new FileStream(fileWithPath, FileMode.Create))
                {
                    imageFile.CopyTo(stream);
                }

                return Task.FromResult(newFileName); 
            }
            catch 
            {
                throw;
            }
        }
    }
}