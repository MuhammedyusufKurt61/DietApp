using DietApp.DAL.Abstract;
using DietApp.DAL.Base.EntityFramework;
using DietApp.DAL.Concrete.Context;
using DietApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.DAL.Concrete.Repositories
{
    public class MealRepository : EFRepositoryBase<Meal, DietAppDbContext>, IMealDAL
    {
        public MealRepository(DietAppDbContext db) : base(db)
        {
        }
    }
}
