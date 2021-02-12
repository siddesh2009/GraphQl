using Sco.Business.Contract;
using Sco.Data.Contract;
using Sco.Data.Model;
using Sco.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sco.Business.Logic.UserBusinessLogic
{
    public class UserBusinessMgr : IUserBusinessMgr
    {
        private readonly IUserDataMgr _userDataMgr;

        public UserBusinessMgr(IUserDataMgr userDataMgr)
        {
            _userDataMgr = userDataMgr;
        }

        public List<UserDetailViewModel> GetAllUsers()
        {
            List<scouser> modelUsersList = _userDataMgr.GetAllUsers();
            List<UserDetailViewModel> uiUserList = new List<UserDetailViewModel>();
            for (int i = 0; i < modelUsersList.Count; i++)
            {
                UserDetailViewModel userDetailViewModel = new UserDetailViewModel();
                userDetailViewModel.FirstName = modelUsersList[i].FirstName;
                userDetailViewModel.LastName = modelUsersList[i].LastName;
                userDetailViewModel.EmailId = modelUsersList[i].EmailId;
                userDetailViewModel.UserId = modelUsersList[i].ScoUserId;
                
                uiUserList.Add(userDetailViewModel);
            }
            return uiUserList;
        }

        public List<scouser> GetAllUsersQuerable()
        {
            List<scouser> modelUsersList = _userDataMgr.GetAllUsersQuerable().ToList();
            
            return modelUsersList;
        }
    }
}
