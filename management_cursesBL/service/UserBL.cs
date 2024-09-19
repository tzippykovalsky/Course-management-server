using management_cursesBL.Interface;
using management_cursesDL.EF.Models;
using management_cursesDL.Interface;
using managmant_cursesEntitis;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace management_cursesBL.service
{
    public class UserBL:IUserBL
    {
        private readonly IUserDL _userDL;
        //private readonly AppSettings _appSettings;
        public UserBL(IUserDL userDL)
            
        {
            _userDL = userDL;
            //_appSettings = options.Value;
          
        }

        public BaseResponse<User> SighIn(User user)
        {
          
            _userDL.SighIn(user);

            return new BaseResponse<User>
            {
                Data = user,
                IsSucsses = true,
                StatusCode = 200,
                Message = "The user is SighIn succsesfuly",

            };

        }

        public BaseResponse<User> Login(string password, string email)
        {
            User userFromDB = _userDL.LogIn(email);

            if (userFromDB != null)
            {
                {
                    return new BaseResponse<User>
                    {
                        Data = userFromDB,
                        IsSucsses = true,
                        StatusCode = 200,
                        Message = "The user is SighIn succsesfuly",

                    };
                }
            }
            return new BaseResponse<User>
            {
                Data = null,
                IsSucsses = false,
                StatusCode = 404,
                Message = "not found the user",

            }; ;
        }

        //public BaseResponse<User> LogOut()
        //{
        //    _httpContextAccessor.HttpContext.
        //      Response.Cookies.Delete(CookiesKeys.AccessToken);
        //    return new BaseResponse<User>
        //    {
        //        Data = null,
        //        IsSucsses = true,
        //        StatusCode = 200,
        //        Message = "The LogOut succsess",

        //    };
        //}

    }

}

