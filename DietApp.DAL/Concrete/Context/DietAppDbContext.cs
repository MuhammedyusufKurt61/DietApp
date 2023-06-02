using DietApp.DAL.Concrete.Context.Configurations;
using DietApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace DietApp.DAL.Concrete.Context
{
    public class DietAppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-444JFM3\SQLSERVER2019; Database=DietAppDb; Trusted_Connection = True;");
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MealFood> MealsFoods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new UserConfiguration())
                .ApplyConfiguration(new MealConfiguration())
                .ApplyConfiguration(new CategoryConfiguration())
                .ApplyConfiguration(new FoodConfiguration())
                .ApplyConfiguration(new MealFoodConfiguration());
        }
    }
}
