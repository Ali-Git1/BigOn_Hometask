using BigonApp.Infrastructure.Services.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        public async Task<string> ChangeFileAsync(IFormFile file, string oldFileName, bool isArchive = false)
        {
            if (file == null)
            {
                return oldFileName;
            }

            var folder = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot", "uploads", "images");

            FileInfo fi =new  FileInfo(Path.Combine(folder,oldFileName));

            if(fi.Exists && isArchive)
            {
                var newFileName = $"archive{oldFileName}";

                fi.MoveTo(Path.Combine(folder, newFileName));
            }
            else if(fi.Exists && !isArchive)
            {
                fi.Delete();
            }

            return await UploadAsync(file);
           
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
