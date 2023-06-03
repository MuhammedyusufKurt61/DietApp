using DietApp.Entity;
using DietApp.System;
using DietApp.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.BLL.Abstract
{
    public interface IUserBLL : IBaseBLL<User>
    {
        ResultService<User> CreateUser(UserCreateVM vm);
        ResultService<User> UpdateUser(UserUpdateVM vm);
        ResultService<User> DeleteUser(UserBaseVM vm);
        ResultService<User> Login(UserLoginVM vm);
        bool AnyUser(UserCreateVM vm);
        bool IsValidEmail(string email);
        ResultService<User> GetUserByUserName(string userName);
        ResultService<User> GetUserById(int id);
    }
}
