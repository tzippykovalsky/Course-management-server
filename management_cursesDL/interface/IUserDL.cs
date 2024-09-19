using management_cursesDL.EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_cursesDL.Interface
{
    public interface IUserDL
    {
        void SighIn(User user);
        User LogIn(string email);
        User GetUser(int id);
    }
}
