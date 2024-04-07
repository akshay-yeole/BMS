using BMS.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BMS.Sql.EntityConfiguration
{
    public class LibraryTransactionConfiguration : IEntityTypeConfiguration<LibraryTransaction>
    {
        public void Configure(EntityTypeBuilder<LibraryTransaction> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.ReturnedDate)
           .IsRequired(false)
           .HasDefaultValueSql("NULL");
        }
    }
}
