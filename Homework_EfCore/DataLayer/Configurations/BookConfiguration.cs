using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public sealed class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(q => q.BookId);

            builder.Property(q => q.BookId).HasDefaultValueSql("NEWID()");
            builder.Property(q => q.Name).HasMaxLength(50);

            builder.Property(q => q.AuthorId).IsRequired(false);

            builder.HasIndex(q => new
            {
                q.AuthorId,
                q.Name
            });

            builder.HasOne(q => q.Author)
                   .WithMany(q => q.Books)
                   .HasForeignKey(q => q.BookId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
