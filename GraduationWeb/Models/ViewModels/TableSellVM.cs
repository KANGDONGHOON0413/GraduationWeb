using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWeb.Models.ViewModels
{
    public class TableSellVM
    {

        public int SellNum { get; set; }
        public string ProductName { get; set; }
        public int ProductNum { get; set; }
        public int ProductPrice { get; set; }
        public string SellerId { get; set; }
        public string ProductDescription { get; set; }
        public byte[] ProductImage { get; set; }

        public IFormFile FormFile { get; set;}
    }
}
