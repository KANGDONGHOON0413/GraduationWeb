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
        [Required]
        public string Id { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        public byte[] Image { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public virtual ICollection<TableSell> TableSell { get; set; }
    }
}
