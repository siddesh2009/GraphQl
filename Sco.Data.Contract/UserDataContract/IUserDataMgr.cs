using Sco.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sco.Data.Contract
{
    public interface IUserDataMgr
    {
        List<scouser> GetAllUsers();

        IQueryable<scouser> GetAllUsersQuerable();
    }
}
