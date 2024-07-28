using Halan.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halan.Domain.Configurations
{
    public abstract class EntityTrackerBaseConfiguration<TBase> : IEntityTypeConfiguration<TBase> where TBase : EntityTrackerBase
    {
        public virtual void Configure(EntityTypeBuilder<TBase> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(t => t.Id)
                   .HasColumnName("id")
                   .IsRequired();

            builder.Property(b => b.CreatedDate)
                   .HasColumnName("created_date");

            builder.Property(b => b.UpdatedDate)
                   .HasColumnName("updated_date");
        }
    }
}
