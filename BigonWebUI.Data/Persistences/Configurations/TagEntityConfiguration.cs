﻿using BigonApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonApp.Models.Persistences.Configurations
{
    public class TagEntityConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.HasKey(m => m.Id);



            builder.Property(m => m.Id).HasColumnType("int");
            builder.Property(m => m.Title).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            


            builder.ConfigurAsAuditable(); //configuration helperde yazilanlari cagirmaq ucun yaziriq

            builder.ToTable("Tags"); //burada ne ad yazilsa birbasa table yaradanda bu adda yaradacaq
        }
    }
}
