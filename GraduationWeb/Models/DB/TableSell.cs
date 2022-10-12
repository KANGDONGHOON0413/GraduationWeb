using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GraduationWeb.Models.DB
{
    public partial class TableSell
    {
        public TableSell()
        {
            TableOrder = new HashSet<TableOrder>();
        }

        public int SellNum { get; set; }
        public string ProductName { get; set; }
        public int ProductNum { get; set; }
        public int ProductPrice { get; set; }
        public string SellerId { get; set; }
        public string ProductDescription { get; set; }
        public byte[] ProductImage { get; set; }

        public virtual TableUser Seller { get; set; }
        public virtual ICollection<TableOrder> TableOrder { get; set; }
    }
}
