using GraduationWeb.Models.DB;
using GraduationWeb.Models.IDAL;
using GraduationWeb.Models.ViewModels;
using System;
using System.Linq;

namespace GraduationWeb.Models.DAL
{
    public class UserM : I_UserM
    {
        private readonly _201984001dbContext _context;

        public UserM(_201984001dbContext context )
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

        public bool UpdateUserInfo(UpdateUserInfoVM user)
        {
            TableUser changedItems = (from Items in _context.TableUser
                                      where Items.Id.Equals(user.Id)
                                      select Items).Single();
            if (user.Name != null) changedItems.Name = user.Name;
            if (!string.IsNullOrEmpty(user.Password))
            {
                if(user.Password.Length >5)
                changedItems.Password = user.Password;        
            }
            if (user.Phone.Length >= 8) changedItems.Phone = user.Phone;
            if(user.Image.Length > 0)
            {
                changedItems.Image = user.Image;
            }
            _context.SaveChanges();
            
            return true;
        }

        public string UserLoginCheck(LoginApproach user)
        {
            var UserCheck = _context.TableUser.FirstOrDefault(A => A.Id.Equals(user.ID) && A.Password.Equals(user.Password));
            if (UserCheck != null) return UserCheck.Name;
            return "";
        }
    }
}
