using Microsoft.EntityFrameworkCore;using Microsoft.EntityFrameworkCore.Metadata.Builders;using Model;namespace Infrastructure.Data.Configs{public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>{public void Configure(EntityTypeBuilder<Enrollment> builder){builder.HasKey(x => x.Id);builder.HasOne(x => x.Student);builder.HasOne(x => x.Course); 
// builder.Navigation(x => x.Student)
 
// .IsRequired();
}}}