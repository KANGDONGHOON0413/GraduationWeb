using GraduationWeb.Models.DB;
using GraduationWeb.Models.IDAL;
using GraduationWeb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace GraduationWeb.Models.DAL
{
    public class OrderM : I_OrderM
    {
        private readonly _201984001dbContext _context;

        public OrderM(_201984001dbContext context)
        {
            _context = context;
        }

        public List<OrderVM> GetOrderItemsToList()
        {
            throw new NotImplementedException();
        }
    }
}
