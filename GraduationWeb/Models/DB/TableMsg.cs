using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GraduationWeb.Models.DB
{
    public partial class TableMsg
    {
        public string ReceiverId { get; set; }
        public string Msg { get; set; }
        public bool MsgTitle { get; set; }
        public string ProductName { get; set; }
        public int? ProductNum { get; set; }
    }
}
