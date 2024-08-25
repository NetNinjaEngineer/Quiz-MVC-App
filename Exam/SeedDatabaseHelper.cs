using Exam.Entities;

namespace Exam;

public static class SeedDatabaseHelper
{
    public static List<Subject> LoadSubjects()
    {
        return
        [
            new() { Id = 1, Name = "C# Basics" },
            new() { Id = 2, Name = "Advanced C#"},
            new() { Id = 3, Name = "JavaScript Essentials" },
            new() { Id = 4, Name = "React Fundamentals" },
            new() { Id = 5, Name = "TypeScript for Beginners" },
            new() { Id = 6, Name = "Python Programming" },
            new() { Id = 7, Name = "Java Programming"},
            new() { Id = 8, Name = "SQL Basics"},
            new() { Id = 9, Name = "NoSQL Databases" },
            new() { Id = 10, Name = "Data Structures"},
            new() { Id = 11, Name = "Algorithms"},
            new() { Id = 12, Name = "Web Development"},
            new() { Id = 13, Name = "Mobile App Development" },
            new() { Id = 14, Name = "Cloud Computing" },
            new() { Id = 15, Name = "DevOps Practices"},
            new() { Id = 16, Name = "Cybersecurity Basics"},
            new() { Id = 17, Name = "Machine Learning"},
            new() { Id = 18, Name = "Artificial Intelligence"},
            new() { Id = 19, Name = "Blockchain Technology"},
            new() { Id = 20, Name = "Internet of Things (IoT)"},
            new() { Id = 21, Name = "Kotlin for Android Development"},
            new() { Id = 22, Name = "Swift Programming"},
            new() { Id = 23, Name = "Ruby on Rails"},
            new() { Id = 24, Name = "PHP for Web Development"},
            new() { Id = 25, Name = "Angular Development"},
            new() { Id = 26, Name = "Vue.js Fundamentals"}
        ];
    }

    public static List<FinalExam> LoadFinalExams()
    {
        return
        [
            new FinalExam
            {
                Id = 1,
                NumberOfQuestions = 3,
                SubjectId = 1,
                Questions = new List<Question>
                {
                    new MCQQuestion
                    {
                        Id = 1,
                        Body = "What is the correct syntax to output 'Hello World' in C#?",
                        Mark = 2,
                        FinalExamId = 1,
                        Answers = new List<Answer>
                        {
                            new Answer { Id = 1, Text = "Console.WriteLine('Hello World');", Correct = true },
                            new Answer { Id = 2, Text = "System.out.println('Hello World');", Correct = false },
                            new Answer { Id = 3, Text = "echo('Hello World');", Correct = false }
                        }
                    },
                    new TFQuestion
                    {
                        Id = 2,
                        Body = "C# is a statically-typed language.",
                        Mark = 1,
                        FinalExamId = 1,
                        Answers = new List<Answer>
                        {
                            new Answer { Id = 4, Text = "True", Correct = true },
                            new Answer { Id = 5, Text = "False", Correct = false }
                        }
                    }
                }
            },
            new FinalExam
            {
                Id = 2,
                NumberOfQuestions = 2,
                SubjectId = 1,
                Questions = new List<Question>
                {
                    new MCQQuestion
                    {
                        Id = 3,
                        Body = "Which of the following is NOT an access modifier in C#?",
                        Mark = 2,
                        FinalExamId = 2,
                        Answers = new List<Answer>
                        {
                            new Answer { Id = 6, Text = "public", Correct = false },
                            new Answer { Id = 7, Text = "private", Correct = false },
                            new Answer { Id = 8, Text = "protected", Correct = false },
                            new Answer { Id = 9, Text = "internalize", Correct = true }
                        }
                    },
                    new TFQuestion
                    {
                        Id = 4,
                        Body = "C# supports multiple inheritance.",
                        Mark = 1,
                        FinalExamId = 2,
                        Answers = new List<Answer>
                        {
                            new Answer { Id = 10, Text = "True", Correct = false },
                            new Answer { Id = 11, Text = "False", Correct = true }
                        }
                    }
                }
            }
        ];
    }

    public static List<PracticalExam> LoadPracticalExams()
    {
        return new List<PracticalExam>
        {
            new PracticalExam
            {
                Id = 1,
                NumberOfQuestions = 2,
                SubjectId = 6,
                Questions = new List<Question>
                {
                    new MCQQuestion
                    {
                        Id = 5,
                        Body = "Which of the following is a Python tuple?",
                        Mark = 2,
                        PracticalExamId = 1,
                        Answers = new List<Answer>
                        {
                            new Answer { Id = 12, Text = "(1, 2, 3)", Correct = true },
                            new Answer { Id = 13, Text = "[1, 2, 3]", Correct = false },
                            new Answer { Id = 14, Text = "{1, 2, 3}", Correct = false }
                        }
                    },
                    new TFQuestion
                    {
                        Id = 6,
                        Body = "Python uses indentation to define code blocks.",
                        Mark = 1,
                        PracticalExamId = 1,
                        Answers = new List<Answer>
                        {
                            new Answer { Id = 15, Text = "True", Correct = true },
                            new Answer { Id = 16, Text = "False", Correct = false }
                        }
                    }
                }
            }
        };
    }

}
