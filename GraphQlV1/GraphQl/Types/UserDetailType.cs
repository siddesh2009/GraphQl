using GraphQL.Types;
using Sco.Data.Model;
using Sco.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlV1.GraphQl.Types
{
    public class UserDetailType: ObjectGraphType<scouser>
    {
        public UserDetailType()
        {
            Name = "SampleUser";

            Field(x => x.ScoUserId, type: typeof(IdGraphType)).Description("The ID of the User.");
            Field(x => x.FirstName).Description("The firstname of the User");
            Field(x => x.LastName).Description("The lastname of the User");
            Field(x => x.EmailId).Description("The emailId of the User");
        }
    }
}
