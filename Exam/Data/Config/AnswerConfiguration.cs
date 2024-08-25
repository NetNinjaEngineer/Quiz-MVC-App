using Exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.Config;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();

        builder.Property(x => x.Text)
            .HasMaxLength(50)
            .IsRequired();

        builder.HasOne(x => x.TFQuestion)
            .WithMany(x => x.Answers)
            .HasForeignKey(x => x.TFQuestionId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);


        builder.HasOne(x => x.MCQQuestion)
            .WithMany(x => x.Answers)
            .HasForeignKey(x => x.MCQQuestionId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.SetNull);

        builder.ToTable("Answers");
    }
}
