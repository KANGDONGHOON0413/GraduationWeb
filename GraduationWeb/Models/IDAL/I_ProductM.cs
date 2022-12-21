using GraduationWeb.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWeb.Models.IDAL
{
    public interface I_ProductM
    {
        string InputProduct(TableSell items);
        string UpdateProduct(TableSell items);
        string DeleteProduct(int itemId);
        List<TableSell> ShowMyProduct(string userId);

        List<TableSell> ShowAllProduct(int pageNum);

    }
}
