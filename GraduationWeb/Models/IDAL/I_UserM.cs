using GraduationWeb.Models.DB;
using GraduationWeb.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace GraduationWeb.Models.IDAL
{
    public interface I_UserM
    {
        TableUser GetUserInfo(string user);

        bool AddNewUser(TableUser user);

        bool DeleteUser(string user);

        bool UpdateUserInfo(UpdateUserInfoVM user);

        string UserLoginCheck(LoginApproach user);
    }
}
