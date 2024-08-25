using Exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.Config;

public class TFQuestionConfiguration : IEntityTypeConfiguration<TFQuestion>
{
    public void Configure(EntityTypeBuilder<TFQuestion> builder)
    {
    }
}
