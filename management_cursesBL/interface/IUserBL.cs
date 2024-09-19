using management_cursesDL.EF.Models;
using managmant_cursesEntitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_cursesBL.Interface
{
    public interface IUserBL
    {
        BaseResponse<User> SighIn(User user);
        BaseResponse<User> Login(string password, string email);
    }
}
