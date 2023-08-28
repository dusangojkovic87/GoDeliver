using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Authentication.API.Exceptions;

namespace Restaurant.API.Util.UploadImage
{
    public static class UploadImageHelper
    {

        public static string UploadImage(IFormFile image, string uploadPath, string filename, string contentType)
        {

            try
            {
                string uniqueFilename = $"{Guid.NewGuid()}{filename}";

                string fullPath = Path.Combine(uploadPath, uniqueFilename);

                if (!contentType.Equals("image/png") || !contentType.Equals("image/jpg"))
                {
                    throw new CustomValidationException(new List<string> { "Image must be in png or jpg format" });


                }


                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    image.CopyTo(stream);

                }

                return uniqueFilename;

            }
            catch (System.Exception)
            {
                throw new CustomValidationException(new List<string> { "Error,on image upload!" });
            }


        }


    }
}