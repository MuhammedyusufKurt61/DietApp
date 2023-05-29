using DietApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Entity
{
    public class Food : BaseEntity
    {
        public string FoodName { get; set; }
        public string Description { get; set; }
        public double Calorie { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<MealFood> MealFoods { get; set; }

        

       
        



        public Food()
        {
            IsActive = true;
            MealFoods = new HashSet<MealFood>();
        }
    }
}
