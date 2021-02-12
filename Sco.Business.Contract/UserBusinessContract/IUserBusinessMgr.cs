using Sco.Data.Model;
using Sco.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sco.Business.Contract
{
    public interface IUserBusinessMgr
    {
        List<UserDetailViewModel> GetAllUsers();

        List<scouser> GetAllUsersQuerable();
    }
}
