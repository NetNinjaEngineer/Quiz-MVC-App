using Exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.Config;

public class MCQQuestionConfiguration : IEntityTypeConfiguration<MCQQuestion>
{
    public void Configure(EntityTypeBuilder<MCQQuestion> builder)
    {

    }
}
