using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Entities.HelpersModels
{
    public class ConvertToImage
    {
        public static string ConvertToImg(IFormFile file)
        {
            if (file == null)
                return null;
            string str = null;
            if (file.Length > 0)
            {
                using(var ms=new MemoryStream())
                {
                    file.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    str += $"data: {file.ContentType};base64,";
                    str += Convert.ToBase64String(fileBytes);
                }
            }
            return str;
        }
    }
}
