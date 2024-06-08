using BigonApp.Infrastructure.Entities;
using BigonApp.Models.Persistences.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigonApp.Data.Persistences.Configurations
{
    public class BlogPostEntityConfiguration : IEntityTypeConfiguration<BlogPost>
    {
        public void Configure(EntityTypeBuilder<BlogPost> builder)
        {
           

            builder.Property(m=>m.Id).HasColumnType("int");
            builder.Property(m => m.Title).HasColumnType("nvarchar").HasMaxLength(200).IsRequired();
            builder.Property(m => m.Body).HasColumnType("nvarchar(max)").IsRequired();
            builder.Property(m => m.FilePath).HasColumnType("nvarchar").IsRequired().HasMaxLength(50);
            builder.Property(m => m.CategoryId).HasColumnType("int").IsRequired();
            builder.Property(m => m.PublishedAt).HasColumnType("datetime");
            builder.Property(m => m.PublishedBy).HasColumnType("int");

            builder.HasKey(m => m.Id);

            builder.ConfigurAsAuditable();

            builder.ToTable("BlogPosts");


            builder.HasIndex(m=>m.Slug).IsUnique();


            builder.HasOne<Category>()
                .WithMany()
                .HasForeignKey(m => m.CategoryId)
                .HasPrincipalKey(m => m.Id)
                .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
