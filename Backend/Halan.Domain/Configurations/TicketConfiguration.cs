using Halan.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Halan.Domain.Configurations
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Id)
                   .ValueGeneratedNever();

            builder.Property(e => e.PhoneNumber)
                   .HasColumnType("nvarchar(256)");

            builder.Property(e => e.Governorate)
                   .HasColumnType("nvarchar(256)");

            builder.Property(e => e.District)
                   .HasColumnType("nvarchar(256)");

            builder.Property(e => e.City)
                   .HasColumnType("nvarchar(256)");
        }
    }
}
