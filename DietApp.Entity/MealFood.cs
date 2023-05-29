using DietApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Entity
{
    public class MealFood : BaseEntity
    {
        public double Portion { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int FoodId { get; set; }
        public virtual Food Food { get; set; }
        public int MealId { get; set; }
        public virtual Meal Meal { get; set; }
        public MealFood()
        {
            IsActive = true;
        }
    }
}
