using GraphQL;
using GraphQL.Types;
using GraphQlV1.GraphQl.Types;
using Sco.Business.Contract;
using Sco.Data.Model;
using Sco.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQlV1.Queries
{
    public class UserDetailQuery: ObjectGraphType
    {
        //public UserDetailQuery(IUserBusinessMgr userBusinessMgr)
        //{
        //    Name = nameof(UserDetailQuery);
        //    Field<ListGraphType<UserDetailType>>(
        //        name: "SampleUser1",
        //        resolve: context => userBusinessMgr.GetAllUsers());
        //}

        public UserDetailQuery(IUserBusinessMgr userBusinessMgr)
        {
            Name = nameof(UserDetailQuery);
            Field<ListGraphType<UserDetailType>>(
                name: "SampleUser1",
                resolve: context => userBusinessMgr.GetAllUsersQuerable());
            Field<ListGraphType<UserDetailType>>(
                name: "SampleUser2",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "firstName"}),
                resolve: context => 
                    {
                        var argFirstName = context.GetArgument<string>("firstName");
                        return userBusinessMgr.GetAllUsersQuerable().Where(a => a.FirstName == argFirstName).ToList(); 
                    });
            Field<ListGraphType<UserDetailType>>(
                name: "SampleUser3",
                arguments: new QueryArguments(new QueryArgument<IdGraphType> { Name = "firstName" }),
                resolve: context =>
                {
                    var argFirstName = context.GetArgument<string>("firstName");
                    return userBusinessMgr.GetAllUsersQuerable().Where(a => a.FirstName.Contains(argFirstName)).ToList();
                });
        }
    }
}
