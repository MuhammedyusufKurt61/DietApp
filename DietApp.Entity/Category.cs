using DietApp.Core;
using Online2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.Entity
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
        public Category()
        {
            IsActive = true;
            Foods = new HashSet<Food>();
        }
    }
}
