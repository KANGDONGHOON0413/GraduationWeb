using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GraduationWeb.Models.DB
{
    public partial class TableReceipt
    {
        public int OrderNum { get; set; }
        public string OrdererId { get; set; }
        public string SellerId { get; set; }
        public string SellerPhone { get; set; }
        public string OrdererName { get; set; }
        public string OrdererPhone { get; set; }
        public string OrdererAddress { get; set; }
        public string ProductName { get; set; }
        public int ProductNum { get; set; }
        public int TotalPay { get; set; }
        public string OrderTime { get; set; }
        public string CommitTime { get; set; }
    }
}
