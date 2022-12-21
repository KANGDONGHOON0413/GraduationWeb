using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWeb.Models.ViewModels
{
    public class TableSellVM
    {

        public int SellNum { get; set; }

        [Required(ErrorMessage = "제품명을 입력하세요")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "제품 개수를 입력하세요")]
        public int ProductNum { get; set; }

        [Required(ErrorMessage ="제품의 가격을 입력하세요")]
        public int ProductPrice { get; set; }

        public string SellerId { get; set; }

        
        public string ProductDescription { get; set; }
        public byte[] ProductImage { get; set; }

        public IFormFile FormFile { get; set;}
    }
}
