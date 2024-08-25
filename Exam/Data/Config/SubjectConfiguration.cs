using Exam.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Data.Config;

public class SubjectConfiguration : IEntityTypeConfiguration<Subject>
{
    public void Configure(EntityTypeBuilder<Subject> builder)
    {
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id).ValueGeneratedOnAdd();

        builder.Property(s => s.Name)
            .HasColumnType("varchar")
            .HasMaxLength(50)
            .IsRequired();

        builder.ToTable("Subjects");

        builder.HasData(SeedDatabaseHelper.LoadSubjects());
    }


}
