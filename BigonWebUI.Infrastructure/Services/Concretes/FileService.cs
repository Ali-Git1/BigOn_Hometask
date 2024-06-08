using BigonApp.Infrastructure.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Infrastructure.Services.Concretes
{
    public class FileService:IFileService
    {
        private readonly IHostEnvironment _hostEnvironment;

        public FileService(IHostEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        public async Task<string> UploadAsync(IFormFile file)
        {
            var fileName = $"{Guid.NewGuid()} {Path.GetExtension(file.FileName)}";
            var phsycialPath = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "uploads", "images", fileName);

            using (FileStream fs = new FileStream(phsycialPath, FileMode.CreateNew, FileAccess.Write))
            {
                await file.CopyToAsync(fs);
            }

            return fileName;
        }
    }
}
