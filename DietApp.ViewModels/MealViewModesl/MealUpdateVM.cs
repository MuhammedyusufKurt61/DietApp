using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.ViewModels.MealViewModesl
{
    public class MealUpdateVM
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public DateTime UpdateDate => DateTime.Now;
    }
}
