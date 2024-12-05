using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Techcareer.Models.Entities;

namespace Techcareer.DataAccess.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
  public void Configure(EntityTypeBuilder<Course> builder)
  {
    builder.ToTable("Courses").HasKey(c => c.Id);
    builder.Property(c => c.Id).HasColumnName("CourseId");
    builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate");
    builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
    builder.Property(c => c.Title).HasColumnName("Title");
    builder.Property(c => c.Instructor).HasColumnName("Instructor");
    builder.Property(c => c.Description).HasColumnName("Description");
    builder.Property(c => c.Category).HasColumnName("Category");
    builder.Property(c => c.Image).HasColumnName("Image");
    builder.Property(c => c.Level).HasColumnName("Level");
    builder.Property(c => c.Duration).HasColumnName("Duration");
    builder.Property(c => c.HasCertificate).HasColumnName("HasCertificate");

    builder
      .HasMany(c => c.Users)
      .WithMany(u => u.Courses)
      .UsingEntity<Dictionary<string, object>>(
      "CourseUser",
      c => c.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade),
      u => u.HasOne<Course>().WithMany().HasForeignKey("CourseId").OnDelete(DeleteBehavior.Cascade));
  }
}
