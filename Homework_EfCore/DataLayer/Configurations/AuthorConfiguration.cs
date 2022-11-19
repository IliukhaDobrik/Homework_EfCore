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
    public sealed class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.HasKey(q => q.AuthorId);

            builder.Property(q => q.AuthorId).HasDefaultValueSql("NEWID()");
            builder.Property(q => q.FirstName).HasMaxLength(50);
            builder.Property(q => q.LastName).HasMaxLength(50);
            builder.Property(q => q.Country).HasMaxLength(50);

            builder.HasIndex(q => new
            {
                q.FirstName,
                q.LastName,
                q.Country
            });
        }
    }
}
