using GraduationWeb.Models.DB;
using GraduationWeb.Models.IDAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraduationWeb.Models.DAL
{
    public class ProductM : IDAL.I_ProductM
    {
        private readonly DB.TableManager _context;

        public ProductM(DB.TableManager context)
        {
            _context = context;
        }

        public string DeleteProduct(int itemId)
        {
            try
            {
                _context.TableSell.Remove(_context.TableSell.Find(itemId));
                _context.SaveChanges();
            }
            catch (SqlException)
            {
                return "서버연결 오류";
            }
            catch (Exception)
            {
                return "오류 발생";
            }
            return "항목이 삭제되었습니다.";
        }

        public string InputProduct(TableSell items)
        {
            try
            {
                _context.TableSell.Add(items);
                _context.SaveChanges();
            }
            catch (SqlException)
            {
                return "서버연결 오류";
            }
            catch (Exception)
            {
                return "오류 발생";
            }
            return "물품이 판매리스트에 추가되었습니다.";
        }

        public List<TableSell> ShowAllProduct(int pageNum)
        {
            int pgnum = 40 * (pageNum - 1);
            List<TableSell> query = _context.TableSell.Select(A => A).Skip(pgnum).Take(40).ToList();
           
            return query;
        }

        public List<TableSell> ShowMyProduct(string userId)
        {
            List<TableSell> sells = (List<TableSell>)_context.TableSell.Select(A => A.SellerId.Equals(userId));

            return sells;
        }

        public string UpdateProduct(TableSell items)
        {
            try
            {
                var item = _context.TableSell.Find(items.SellNum);
                item = items;
                _context.SaveChanges();
            }
            catch (SqlException)
            {
                return "서버연결 오류";
            }
            catch (Exception)
            {
                return "오류 발생";
            }
            return "물품이 업데이트 되었습니다.";
        }
    }
}
