using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Configurations
{
    public sealed class UserBookConfiguration : IEntityTypeConfiguration<UserBook>
    {
        public void Configure(EntityTypeBuilder<UserBook> builder)
        {
            builder.HasKey(q => q.UserBookId);

            builder.HasIndex(q => new { q.UserId, q.BookId }).IsUnique();

            builder.Property(q => q.UserId).IsRequired(false);
            builder.Property(q => q.BookId).IsRequired(false);

            builder.HasOne(q => q.User)
                   .WithMany(q => q.UserBooks)
                   .HasForeignKey(q => q.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(q => q.Book)
                   .WithMany(q => q.UserBooks)
                   .HasForeignKey(q => q.BookId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
