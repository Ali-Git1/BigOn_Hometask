using BigonApp.Infrastructure.Entities;
using BigonApp.Models.Persistences.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonApp.WebUI.Models.Persistences.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        { 
            builder.HasKey(m => m.Id);



            builder.Property(m => m.Id).HasColumnType("int");
            builder.Property(m => m.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(m => m.ParentId).HasColumnType("int");
            builder.ConfigurAsAuditable();

            builder.ToTable("Category"); //burada ne ad yazilsa birbasa table yaradanda bu adda yaradacaq










        }

        
    }
}
