using ASPCoreSPA.Helper;
using ASPCoreSPA.Models;

namespace ASPCoreSPA.Interface
{
    public interface IUserModel
    {
        long Id { get; set; }
        string Token { get; set; }
        string Name { get; set; }
        string Password { get; set; }
        Response SigIn(UserModel pUserModel);
    }
}
