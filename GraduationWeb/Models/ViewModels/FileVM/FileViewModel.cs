using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWeb.Models.ViewModels.FileVM
{
    public class FileViewModel
    {
        public IFormFile FormFile { get; set; }
    }
}
