using DietApp.Core;
using Online2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Entity
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserTypes UserTypes { get; set; }
        public virtual ICollection<MealFood> MealFoods { get; set; }

        public User()
        {
            IsActive = true;
            MealFoods = new HashSet<MealFood>();
        }
    }
}
