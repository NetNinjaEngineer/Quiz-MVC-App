using Exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.Config;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasOne(x => x.PracticalExam)
            .WithMany(x => x.Questions)
            .HasForeignKey(x => x.PracticalExamId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasOne(x => x.FinalExam)
              .WithMany(x => x.Questions)
              .HasForeignKey(x => x.FinalExamId)
              .IsRequired(false)
              .OnDelete(DeleteBehavior.SetNull);

        builder.UseTpcMappingStrategy();
    }
}
