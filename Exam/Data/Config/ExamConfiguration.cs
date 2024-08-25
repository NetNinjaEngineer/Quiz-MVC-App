using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.Config;

public class ExamConfiguration : IEntityTypeConfiguration<Entities.Exam>
{
    public void Configure(EntityTypeBuilder<Entities.Exam> builder)
    {
        builder.HasOne(x => x.Subject)
            .WithMany(x => x.Exams)
            .HasForeignKey(x => x.SubjectId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(x => x.Duration)
            .HasColumnType("time")
            .IsRequired();

        builder.UseTpcMappingStrategy();
    }
}
