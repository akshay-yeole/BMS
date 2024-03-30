using BMS.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BMS.Sql.EntityConfiguration
{
    public class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            // Configure primary key
            builder.HasKey(bc => bc.CategoryId);

            // Configure other properties
            builder.Property(bc => bc.CategoryName)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
