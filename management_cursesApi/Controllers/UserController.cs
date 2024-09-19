using management_cursesBL.Interface;
using management_cursesDL.EF.Models;
using managmant_cursesEntitis;
using Microsoft.AspNetCore.Mvc;

namespace management_cursesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController:ControllerBase
    { 
            private readonly IUserBL _userBL;
            public UserController(IUserBL userBl)
            {
                _userBL = userBl;
            }

            [HttpPost]
            public IActionResult SighIn(User user)
            {
                try
                {
                    _userBL.SighIn(user);
                    BaseResponse<User> baseResponse = _userBL.SighIn(user);
                    if (baseResponse.IsSucsses)
                        return StatusCode(baseResponse.StatusCode, baseResponse.Data);
                    return StatusCode(baseResponse.StatusCode, baseResponse.Message);
                }
                catch (Exception ex)
                {
                    //_logger.LogError($"Error on SighIn, Message: {ex.Message}," +
                    //                        $" InnerException: {ex.InnerException}, StackTrace: {ex.StackTrace}");
                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
                }
            }
            [HttpGet]
            public IActionResult LogIn(string password, string email)
            {
                try
                {
                    BaseResponse<User> baseResponse = _userBL.Login(password, email);
                    if (baseResponse.IsSucsses)
                        return StatusCode(baseResponse.StatusCode, baseResponse.Data);
                    return StatusCode(baseResponse.StatusCode, baseResponse.Message);

                }
                catch (Exception ex)
                {
                    //_logger.LogError($"Error on Login, Message: {ex.Message}," +
                    //        $" InnerException: {ex.InnerException}, StackTrace: {ex.StackTrace}");

                    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

                }
            }
    }
}
