using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWeb.Models.ViewModels
{
    public class UpdateUserInfoVM
    {
        public string Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public byte[] Image { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
