using ASPCoreSPA.Helper;
using ASPCoreSPA.Interface;
using ASPCoreSPA.Models;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class USerController : ControllerBase
    {

        #region Variables
        private readonly IUserModel _user;
        #endregion

        #region Constructor
        public USerController(IUserModel user)
        {
            _user = user;
        }
        #endregion

        #region Get Methods
        [HttpGet]
        public Response Get()
        {
            return _user.SigIn(new UserModel
            {
                Name = "Test",
                Password = "No hack"
            });
        }
        #endregion

    }
}