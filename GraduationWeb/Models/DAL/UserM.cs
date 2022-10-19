using GraduationWeb.Models.DB;
using GraduationWeb.Models.IDAL;
using GraduationWeb.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GraduationWeb.Models.DAL
{
    public class UserM : I_UserM
    {
        private readonly _201984001dbContext _context;

        public UserM(_201984001dbContext context)
        {
            _context = context;
        }

        public bool AddNewUser(TableUser user)
        {
            try
            {
                _context.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public bool DeleteUser(string user)
        {
            try {
                _context.TableUser.Remove(_context.TableUser.FirstOrDefault(A => A.Id.Equals(user)));
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
    }

        public TableUser GetUserInfo(string userID)
        {
            TableUser userinfo = _context.TableUser.FirstOrDefault(A => A.Id.Equals(userID));
            return userinfo;
        }

        public bool UpdateUserInfo(TableUser user)
        {
            throw new NotImplementedException();
        }

        public string UserLoginCheck(LoginApproach user)
        {
            var UserCheck = _context.TableUser.FirstOrDefault(A => A.Id.Equals(user.ID) && A.Password.Equals(user.Password));
            if (UserCheck != null) return UserCheck.Name;
            return "";
        }
    }
}
