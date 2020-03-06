using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ASPCoreSPA.Helper;
using ASPCoreSPA.Interface;
using DataLayer;

namespace ASPCoreSPA.Models
{
    public class UserModel : IUserModel
    {

        #region Property
        public long Id { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        #endregion

        #region Methods
        public Response SigIn(UserModel pUserModel)
        {
            if (pUserModel == null)
                return new Response { IsSuccessful = false, Data = null, Message = "User Not Found" };

            if (string.IsNullOrEmpty(pUserModel.Name) || string.IsNullOrEmpty(pUserModel.Password))
                return new Response { IsSuccessful = false, Data = null, Message = "Enter all the required information" };

            UserModel user = Connection.Instance.Query<UserModel>(SQLStatatement.UserSigIn,
                new List<SQLParameter> {
                    new SQLParameter { Name = "name", Value = pUserModel.Name, Direction = ParameterDirection.Input },
                    new SQLParameter { Name = "password", Value = pUserModel.Password, Direction = ParameterDirection.Input }
            }).SingleOrDefault();

            if (user == null)
                return new Response { IsSuccessful = false, Data = null, Message = "User Not Found" };

            return new Response
            {
                IsSuccessful = true,
                Data = new UserModel
                {
                    Token = Guid.NewGuid().ToString(),
                    Name = user.Name
                },
                Message = string.Empty
            };
        }

        Response IUserModel.SigIn(UserModel pUserModel)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}