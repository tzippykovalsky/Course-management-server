using management_cursesDL.EF.Contexts;
using management_cursesDL.EF.Models;
using management_cursesDL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace management_cursesDL.service
{
    public class UserDL:IUserDL
    {
        private readonly CoursesManagementContext _coursesManagementContext;
        public UserDL(CoursesManagementContext queueManagmentContext)
        {
            _coursesManagementContext = queueManagmentContext;
        }

        public void SighIn(User user)
        {
            //להוסיף וולידצית על ה-email   
            _coursesManagementContext.Users.Add(user);
            _coursesManagementContext.SaveChanges();
        }

        public User LogIn(string email)
        {
            User user = _coursesManagementContext.Users.AsNoTracking().Where(x => x.Email == email).FirstOrDefault();
            return user;
        }
        public User GetUser(int id)
        {
            return _coursesManagementContext.Users.AsNoTracking().Where(x => x.UserId == id).FirstOrDefault();
        }
    }
}

