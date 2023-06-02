using DietApp.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.EntityFrameworkCore;
using Online2.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DietApp.DAL.Concrete.Context.Configurations
{
    public class UserConfiguration : BaseConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.UserName).IsRequired().HasMaxLength(130);
            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Password).IsRequired();
            builder.Property(x => x.UserTypes).HasConversion(new EnumToStringConverter<UserTypes>());
            builder.HasMany(x => x.MealFoods).WithOne(x => x.User).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new User()
            {
                Id = 1,
                UserName = "Admin",
                Email = "admin@gmail.com",
                Password = "123456",
                UserTypes = UserTypes.Admin,
                CreateOn = DateTime.Now,
                IsActive = true,
            });
        }
    }
}
