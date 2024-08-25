using Exam.Data;
using Exam.Entities;
using Exam.Models;
using Exam.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Exam.Services;

public class ExamService : IExamService
{
    private readonly ApplicationDbContext _context;

    public ExamService(ApplicationDbContext context)
    {
        _context = context;
    }

    public void AddAnswerToQuestion(int id, QuestionType questionType, CreateAnswerViewModel answerModel)
    {
        if (questionType == QuestionType.MCQQuestion)
        {
            var question = _context.MCQQuestions.FirstOrDefault(x => x.Id == id);
            if (question is not null)
            {
                var answer = new Answer
                {
                    Correct = answerModel.IsCorrect,
                    Text = answerModel.Answer
                };

                question.Answers.Add(answer);
                _context.SaveChanges();
            }
        }
        else if (questionType == QuestionType.TrueOrFalseQuestion)
        {
            var question = _context.TFQuestions.FirstOrDefault(x => x.Id == id);
            if (question is not null)
            {
                var answer = new Answer
                {
                    Correct = answerModel.IsCorrect,
                    Text = answerModel.Answer
                };

                question.Answers.Add(answer);
                _context.SaveChanges();
            }
        }
    }


    public int AssignQuestionToExam(QuestionType questionType, ExamType examType, CreateQuestionViewModel question, int examId)
    {
        if (questionType == QuestionType.MCQQuestion)
        {
            var createdQuestion = new MCQQuestion
            {
                Body = question.Body,
                Mark = question.Mark
            };

            var entity = _context.MCQQuestions.Add(createdQuestion);
            _context.SaveChanges();

            if (examType == ExamType.Practical)
            {
                var exam = _context.PracticalExams.FirstOrDefault(x => x.Id == examId);
                if (exam is not null)
                {
                    var addedQuestion = _context.MCQQuestions.FirstOrDefault(x => x.Id == entity.Entity.Id);
                    exam.Questions.Add(addedQuestion!);
                    _context.SaveChanges();
                }
            }

            else if (examType == ExamType.Final)
            {
                var exam = _context.FinalExams.FirstOrDefault(x => x.Id == examId);
                if (exam is not null)
                {
                    var addedQuestion = _context.MCQQuestions.FirstOrDefault(x => x.Id == entity.Entity.Id);
                    exam.Questions.Add(addedQuestion!);
                    _context.SaveChanges();
                }
            }

            return entity.Entity.Id;
        }

        else if (questionType == QuestionType.TrueOrFalseQuestion)
        {
            var createdQuestion = new TFQuestion
            {
                Body = question.Body,
                Mark = question.Mark
            };

            var entity = _context.TFQuestions.Add(createdQuestion);
            _context.SaveChanges();

            if (examType == ExamType.Practical)
            {
                var exam = _context.PracticalExams.FirstOrDefault(x => x.Id == examId);
                if (exam is not null)
                {
                    var addedQuestion = _context.TFQuestions.FirstOrDefault(x => x.Id == entity.Entity.Id);
                    exam.Questions.Add(addedQuestion);
                    _context.SaveChanges();
                }
            }

            else if (examType == ExamType.Final)
            {
                var exam = _context.FinalExams.FirstOrDefault(x => x.Id == examId);
                if (exam is not null)
                {
                    var addedQuestion = _context.TFQuestions.FirstOrDefault(x => x.Id == entity.Entity.Id);
                    exam.Questions.Add(addedQuestion);
                    _context.SaveChanges();
                }
            }

            return entity.Entity.Id;
        }

        return 0;
    }

    public int CreateFinalExam(CreateExamViewModel model)
    {
        var exam = new FinalExam
        {
            Duration = model.Duration,
            NumberOfQuestions = model.NumberOfQuestions,
            SubjectId = model.SubjectId
        };

        _context.FinalExams.Add(exam);

        _context.SaveChanges();

        return exam.Id;
    }

    public int CreatePracticalExam(CreateExamViewModel model)
    {
        var exam = new PracticalExam
        {
            Duration = model.Duration,
            NumberOfQuestions = model.NumberOfQuestions,
            SubjectId = model.SubjectId
        };

        _context.PracticalExams.Add(exam);

        _context.SaveChanges();

        return exam.Id;
    }

    public IEnumerable<ExamViewModel> GetAllExamsAsync()
    {
        var finalExams = _context.FinalExams
                                        .Include(x => x.Questions)
                                        .Include(x => x.Subject)
                                       .AsEnumerable()
                                       .Select(e => new ExamViewModel
                                       {
                                           ExamId = e.Id,
                                           ExamType = ExamType.Final,
                                           Duration = e.Duration,
                                           NumberOfQuestions = e.NumberOfQuestions,
                                           Subject = e.Subject?.Name,
                                           Questions = e.Questions.Select(q => new QuestionViewModel
                                           {
                                               Body = q.Body,
                                               QuestionId = q.Id,
                                               Mark = q.Mark,
                                               Answers = q.Answers.Select(x => new AnswerViewModel
                                               {
                                                   AnswerId = x.Id,
                                                   IsCorrect = x.Correct,

                                               }).ToList()
                                           }).ToList()
                                       });

        var practicalExams = _context.PracticalExams
                                            .Include(x => x.Questions)
                                            .Include(x => x.Subject)
                                           .AsEnumerable()
                                           .Select(e => new ExamViewModel
                                           {
                                               ExamId = e.Id,
                                               ExamType = ExamType.Practical,
                                               Duration = e.Duration,
                                               Subject = e.Subject?.Name,
                                               NumberOfQuestions = e.NumberOfQuestions,
                                               Questions = e.Questions.Select(q => new QuestionViewModel
                                               {
                                                   Body = q.Body,
                                                   QuestionId = q.Id,
                                                   Mark = q.Mark,
                                                   Answers = q.Answers.Select(x => new AnswerViewModel
                                                   {
                                                       AnswerId = x.Id,
                                                       IsCorrect = x.Correct,

                                                   }).ToList()
                                               }).ToList()
                                           })
                                            .ToList();

        var allExams = finalExams.UnionBy(practicalExams, x => x.ExamId).ToList();

        return allExams;
    }

    public async Task<IEnumerable<SubjectViewModel>> GetAllSubjectsAsync()
    {
        return await _context.Subjects.Select(x => new SubjectViewModel
        {
            Id = x.Id,
            SubjectName = x.Name!
        }).ToListAsync();
    }

    public async Task<int> GetQuestionsCountAsync(int examId, ExamType examType)
    {
        var questionsCount = 0;
        Entities.Exam? currentExam = default!;
        if (examType == ExamType.Final)
        {
            currentExam = await _context.FinalExams.FirstOrDefaultAsync(x => x.Id == examId);
            if (currentExam is not null)
            {
                questionsCount = currentExam.Questions.Count;
            }
        }
        else if (examType == ExamType.Practical)
        {
            currentExam = await _context.PracticalExams.FirstOrDefaultAsync(x => x.Id == examId);
            if (currentExam is not null)
            {
                questionsCount = currentExam.Questions.Count;
            }
        }

        return questionsCount;
    }

    public async Task<ExamViewModel?> GetSingleExamAsync(int examId)
    {
        var practicalExam = _context.PracticalExams
            .Include(e => e.Subject)
            .Include(e => e.Questions)
                .ThenInclude(q => (q as MCQQuestion).Answers)
            .Include(e => e.Questions)
                .ThenInclude(q => (q as TFQuestion).Answers)
            .Where(e => e.Id == examId)
            .AsEnumerable()
            .Select(e => new ExamViewModel
            {
                ExamId = e.Id,
                Duration = e.Duration,
                NumberOfQuestions = e.NumberOfQuestions,
                Subject = e.Subject!.Name,
                Questions = e.Questions.Select(q => new QuestionViewModel
                {
                    QuestionId = q.Id,
                    Body = q.Body!,
                    Mark = q.Mark,
                    Answers = q.Answers.Select(a => new AnswerViewModel
                    {
                        AnswerId = a.Id,
                        Text = a.Text,
                        IsCorrect = a.Correct
                    }).ToList()
                }).ToList()
            })
            .FirstOrDefault();

        if (practicalExam != null)
        {
            return practicalExam;
        }

        var finalExam = _context.FinalExams
            .Include(e => e.Subject)
            .Include(e => e.Questions)
                .ThenInclude(q => (q as MCQQuestion).Answers)
            .Include(e => e.Questions)
                .ThenInclude(q => (q as TFQuestion).Answers)
            .Where(e => e.Id == examId)
            .AsEnumerable()
            .Select(e => new ExamViewModel
            {
                ExamId = e.Id,
                Duration = e.Duration,
                NumberOfQuestions = e.NumberOfQuestions,
                Subject = e.Subject!.Name,
                Questions = e.Questions.Select(q => new QuestionViewModel
                {
                    QuestionId = q.Id,
                    Body = q.Body!,
                    Mark = q.Mark,
                    Answers = q.Answers.Select(a => new AnswerViewModel
                    {
                        AnswerId = a.Id,
                        Text = a.Text,
                        IsCorrect = a.Correct
                    }).ToList()
                }).ToList()
            }).FirstOrDefault();

        return finalExam;
    }
}
