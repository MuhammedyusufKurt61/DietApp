using DietApp.DAL.Abstract;
using DietApp.DAL.Concrete.Context;
using DietApp.DAL.Concrete.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.DAL
{
    public static class EFContextDAL
    {
        public static void AddScopedDal(this IServiceCollection services)
        {
            services.AddDbContext<DietAppDbContext>()
                    .AddScoped<ICategoryDAL, CategoryRepository>()
                    .AddScoped<IFoodDAL, FoodRepository>()
                    .AddScoped<IMealDAL, MealRepository>()
                    .AddScoped<IUserDAL, UserRepository>()
                    .AddScoped<IMealFoodDAL, MealFoodRepository>();
        }
    }
}
