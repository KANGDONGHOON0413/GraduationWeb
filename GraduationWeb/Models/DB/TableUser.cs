using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GraduationWeb.Models.DB
{
    public partial class TableUser
    {
        public TableUser()
        {
            TableSell = new HashSet<TableSell>();
        }
        [Required(ErrorMessage ="ID를 입력해주세요.")]
        public string Id { get; set; }
        [Required(ErrorMessage = "PW를 입력해주세요.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "이름을 입력해주세요.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "전화번호를 입력해주세요.")]
        public string Phone { get; set; }
        public byte[] Image { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public virtual ICollection<TableSell> TableSell { get; set; }
    }
}
