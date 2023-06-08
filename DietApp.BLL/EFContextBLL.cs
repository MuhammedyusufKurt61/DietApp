using DietApp.BLL.Abstract;
using DietApp.BLL.Concrete;
using DietApp.DAL;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.BLL
{
    public static class EFContextBLL
    {        
        public static void AddScopeBLL(this IServiceCollection services)
        {
            services.AddScopedDal();
            services.AddScoped<IUserBLL, UserService>();
        }
    }
}
