using DietApp.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DietApp.DAL.Concrete.Context.Configurations
{
    public class BaseConfiguration<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {            
            builder
                .Property(x => x.Id)
                .UseIdentityColumn();
            builder
                .Property(x => x.CreateOn)
                .HasColumnType("datetime")
                .IsRequired();
            builder
                .Property(x => x.UpdateOn)
                .HasColumnType("datetime")
                .IsRequired(false);
            builder
                .Property(x => x.IsActive)
                .HasColumnType("bit");
            builder
                .HasKey(x => x.Id);
        }
    }
}
