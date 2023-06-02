using DietApp.DAL.Abstract;
using DietApp.DAL.Base.EntityFramework;
using DietApp.DAL.Concrete.Context;
using DietApp.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.DAL.Concrete.Repositories
{
    public class CategoryRepository : EFRepositoryBase<Category, DietAppDbContext>, ICategoryDAL
    {
        public CategoryRepository(DietAppDbContext db) : base(db)
        {
        }
    }
}
