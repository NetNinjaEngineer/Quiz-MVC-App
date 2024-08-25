using Exam.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Data;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<PracticalExam> PracticalExams { get; set; }
    public DbSet<FinalExam> FinalExams { get; set; }
    public DbSet<TFQuestion> TFQuestions { get; set; }
    public DbSet<MCQQuestion> MCQQuestions { get; set; }

    private static void SeedQuestionsAndAnswers(ModelBuilder modelBuilder)
    {
        // MCQ Questions
        modelBuilder.Entity<MCQQuestion>().HasData(
            new MCQQuestion { Id = 1, Body = "What is the correct syntax to output 'Hello World' in C#?", Mark = 2, FinalExamId = 1 },
            new MCQQuestion { Id = 2, Body = "Which of the following is NOT an access modifier in C#?", Mark = 2, FinalExamId = 2 },
            new MCQQuestion { Id = 3, Body = "Which of the following is a Python tuple?", Mark = 2, PracticalExamId = 3 }
        );

        // TF Questions
        modelBuilder.Entity<TFQuestion>().HasData(
            new TFQuestion { Id = 4, Body = "C# is a statically-typed language.", Mark = 1, FinalExamId = 1 },
            new TFQuestion { Id = 5, Body = "C# supports multiple inheritance.", Mark = 1, FinalExamId = 2 },
            new TFQuestion { Id = 6, Body = "Python uses indentation to define code blocks.", Mark = 1, PracticalExamId = 3 }
        );

        // Answers
        modelBuilder.Entity<Answer>().HasData(
            // Answers for MCQ Questions
            new Answer { Id = 1, Text = "Console.WriteLine('Hello World');", Correct = true, MCQQuestionId = 1 },
            new Answer { Id = 2, Text = "System.out.println('Hello World');", Correct = false, MCQQuestionId = 1 },
            new Answer { Id = 3, Text = "echo('Hello World');", Correct = false, MCQQuestionId = 1 },

            new Answer { Id = 6, Text = "public", Correct = false, MCQQuestionId = 2 },
            new Answer { Id = 7, Text = "private", Correct = false, MCQQuestionId = 2 },
            new Answer { Id = 8, Text = "protected", Correct = false, MCQQuestionId = 2 },
            new Answer { Id = 9, Text = "internalize", Correct = true, MCQQuestionId = 2 },

            new Answer { Id = 12, Text = "(1, 2, 3)", Correct = true, MCQQuestionId = 3 },
            new Answer { Id = 13, Text = "[1, 2, 3]", Correct = false, MCQQuestionId = 3 },
            new Answer { Id = 14, Text = "{1, 2, 3}", Correct = false, MCQQuestionId = 3 },

            // Answers for TF Questions
            new Answer { Id = 4, Text = "True", Correct = true, TFQuestionId = 4 },
            new Answer { Id = 5, Text = "False", Correct = false, TFQuestionId = 4 },

            new Answer { Id = 10, Text = "True", Correct = false, TFQuestionId = 5 },
            new Answer { Id = 11, Text = "False", Correct = true, TFQuestionId = 5 },

            new Answer { Id = 15, Text = "True", Correct = true, TFQuestionId = 6 },
            new Answer { Id = 16, Text = "False", Correct = false, TFQuestionId = 6 }
        );
    }

    private static void SeedExams(ModelBuilder modelBuilder)
    {
        // Final Exams
        modelBuilder.Entity<FinalExam>().HasData(
            new FinalExam { Id = 1, NumberOfQuestions = 3, SubjectId = 1 },
            new FinalExam { Id = 2, NumberOfQuestions = 2, SubjectId = 2 }
        );

        // Practical Exams
        modelBuilder.Entity<PracticalExam>().HasData(
            new PracticalExam { Id = 3, NumberOfQuestions = 2, SubjectId = 6 }
        );
    }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SeedExams(modelBuilder);
        SeedQuestionsAndAnswers(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
