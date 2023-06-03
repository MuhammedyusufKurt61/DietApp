using DietApp.BLL.Abstract;
using DietApp.DAL.Abstract;
using DietApp.Entity;
using DietApp.System;
using DietApp.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DietApp.BLL.Concrete
{
    public class UserService : IUserBLL
    {
        private readonly IUserDAL _userDAL;
        public UserService(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public bool AnyUser(UserCreateVM vm)
        {
            bool validUser = _userDAL.GetAll(x => x.IsActive).Any(x => x.Email == vm.Email && x.Password == vm.Password);
            return validUser;
        }

        public ResultService<User> CreateUser(UserCreateVM vm)
        {
            ResultService<User> result = new ResultService<User>();
            bool checkUser = AnyUser(vm);
            bool checkEmail = IsValidEmail(vm.Email);
            if (checkEmail)
            {
                if (!checkUser)
                {
                    User newUser = new User()
                    {
                        UserName = vm.UserName,
                        Email = vm.Email,
                        Password = vm.Password,
                        UserTypes = vm.UserTypes,
                        CreateOn = vm.CreateDate
                    };
                    User addUser = _userDAL.Add(newUser);
                    result.Data = addUser ?? newUser;
                    if (addUser == null)
                    {
                        result.AddError("Bir hata oluştu", "Kayıt işlemi başarısız");
                    }
                }
                else
                {
                    result.Data = null;
                    result.AddError("Ekleme Başarısız", "Kayıt zaten var");
                }
            }
            else
            {
                result.Data = null;
                result.AddError("Ekleme işlemi Başarısız", "Email formatı uygun değil");
            }

            return result;
        }

        public ResultService<User> DeleteUser(UserBaseVM vm)
        {
            ResultService<User> result = new ResultService<User>();
            User user = _userDAL.Get(x => x.IsActive && x.Id.Equals(vm.Id));

            try
            {
                user.IsActive = false;
                _userDAL.Delete(user);

                result.Data = null;
            }
            catch (Exception)
            {
                result.Data = null;
                result.AddError("Silme işlemi başarısız", "Kayıt bulunamadı");
            }
            return result;
        }

        public ResultService<User> GetUserById(int id)
        {
            ResultService<User> result = new ResultService<User>();
            try
            {
                result.Data = _userDAL.Get(x => x.Id.Equals(id));
            }
            catch (Exception)
            {
                result.AddError("Hata", "Kayıt Bulunamadı");
            }
            return result;
        }

        public ResultService<User> GetUserByUserName(string userName)
        {
            ResultService<User> result = new ResultService<User>();
            User user = _userDAL.Get(x => x.UserName.Equals(userName));
            if (user != null)
            {
                result.Data = user;
            }
            else
            {
                result.Data = null;
                result.AddError("Hata", "Kullanıcı bulunamadı.");
            }
            return result;
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"[\w+-]+(?:.[\w+-]+)@[\w+-]+(?:.[\w+-]+)(?:.[a-zA-Z]{2,4})";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        public ResultService<User> Login(UserLoginVM vm)
        {
            ResultService<User> result = new ResultService<User>();
            User user = _userDAL.Get(x => x.UserName.Equals(vm.UserName) && x.Password.Equals(vm.Password));
            if (user != null)
            {
                result.Data = user;
            }
            else
            {
                result.Data = null;
                result.AddError("Giriş Başarısız", "Kullanıcı Bulunamadı");
            }
            return result;
        }

        public ResultService<User> UpdateUser(UserUpdateVM vm)
        {
            ResultService<User> result = new ResultService<User>();
            try
            {
                User user = _userDAL.Get(x => x.Id.Equals(vm.UserId) && x.IsActive);

                user.UserName = vm.UserName;
                user.Password = vm.Password;
                user.Email = vm.Email;
                user.UpdateOn = vm.UpdateDate;

                User updateUser = _userDAL.Update(user);
                result.Data = updateUser ?? user;
                if (updateUser == null)
                {
                    result.AddError("Hata", "Güncelleme Başarısız");
                }
            }
            catch (Exception)
            {

                result.Data = null;
                result.AddError("Güncelleme Başarısız", "Kayıt Bulunamadı");
            }
            return result;
        }
    }
}
