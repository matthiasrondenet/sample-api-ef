using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Model;

namespace Infrastructure.Data.Configs
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.StartDate)
                   .IsRequired();

            builder.Property(x => x.Capacity);

            builder.Metadata.FindNavigation(nameof(Course.Enrollments))
                   .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
