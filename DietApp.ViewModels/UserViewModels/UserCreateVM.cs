using Online2.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DietApp.ViewModels.UserViewModels
{
    public class UserCreateVM
    {
        [Required(ErrorMessage = "Lütfen Kullanıcı Adı Giriniz")]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lütfen Email Adresi Giriniz")]        
        [Display(Name = "Email")]        
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Geçersiz email formatı.")]      
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Şifre Giriniz")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        public UserTypes UserTypes => UserTypes.Standart;
        public DateTime CreateDate => DateTime.Now;
    }
}
