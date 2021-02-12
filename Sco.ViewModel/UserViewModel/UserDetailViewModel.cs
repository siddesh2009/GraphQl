using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sco.ViewModel
{
    public class UserDetailViewModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Password { get; set; }
        public string EmailId { get; set; }
    }
}
