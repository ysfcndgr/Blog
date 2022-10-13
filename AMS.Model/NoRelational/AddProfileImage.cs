using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Model.NoRelational
{
    public static class AddProfileImage
    {
        public static string ImageAdd(IFormFile image)
        {
            var extension = Path.GetExtension(image.FileName);
            var newImageName = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/WriterImageFiles/",
                newImageName);
            var stream = new FileStream(location, FileMode.Create);
            image.CopyTo(stream);
            return newImageName;
        }
    }
}
