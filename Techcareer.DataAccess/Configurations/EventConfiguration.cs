using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Techcareer.Models.Entities;

namespace Techcareer.DataAccess.Configurations;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
  public void Configure(EntityTypeBuilder<Event> builder)
  {
    builder.ToTable("Events").HasKey(e => e.Id);
    builder.Property(e => e.Id).HasColumnName("EventId");
    builder.Property(e => e.CreatedDate).HasColumnName("CreatedDate");
    builder.Property(e => e.UpdatedDate).HasColumnName("UpdatedDate");
    builder.Property(e => e.Title).HasColumnName("Title");
    builder.Property(e => e.Description).HasColumnName("Description");
    builder.Property(e => e.Tag).HasColumnName("Tag");
    builder.Property(e => e.Image).HasColumnName("Image");
    builder.Property(e => e.Deadline).HasColumnName("Deadline");

    builder
      .HasMany(e => e.Users)
      .WithMany(u => u.Events)
      .UsingEntity<Dictionary<string, object>>(
        "EventUser",
        e => e.HasOne<User>().WithMany().HasForeignKey("UserId").OnDelete(DeleteBehavior.Cascade),
        u => u.HasOne<Event>().WithMany().HasForeignKey("EventId").OnDelete(DeleteBehavior.Cascade));
  }
}
