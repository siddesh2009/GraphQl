using Sco.Data.Contract;
using Sco.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sco.Data.Logic
{
    public class UserDataMgr : IUserDataMgr
    {
        private readonly ScoDbContext _dbContext;

        public UserDataMgr(ScoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<scouser> GetAllUsers()
        {
            return _dbContext.scousers.ToList();
        }

        public IQueryable<scouser> GetAllUsersQuerable()
        {
            return _dbContext.scousers.AsQueryable();
        }
    }
}
