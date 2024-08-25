using Exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.Config;

public class PracticalExamConfiguration : IEntityTypeConfiguration<FinalExam>
{
    public void Configure(EntityTypeBuilder<FinalExam> builder)
    {
    }
}


