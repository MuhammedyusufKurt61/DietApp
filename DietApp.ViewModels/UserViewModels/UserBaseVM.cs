using Online2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.ViewModels.UserViewModels
{
    public class UserBaseVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public UserTypes UserTypes { get; set; }
    }
}
