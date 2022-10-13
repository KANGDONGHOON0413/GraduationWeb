using GraduationWeb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWeb.Models.IDAL
{
    public interface I_OrderM
    {
        public List<OrderVM> GetOrderItemsToList();
    }
}
