using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.ViewModels.FoodViewModels
{
    public class FoodUpdateVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime UpdateDate => DateTime.Now;
    }
}
