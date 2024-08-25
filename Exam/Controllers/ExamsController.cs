using Exam.Models;
using Exam.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Controllers;
public class ExamsController : Controller
{
    private readonly IExamService _examService;

    public ExamsController(IExamService examService)
    {
        _examService = examService;
    }

    #region Get all Exams
    [HttpGet]
    public IActionResult Index()
    {
        var allExams = _examService.GetAllExamsAsync();
        return View(allExams);
    }
    #endregion

    #region Make Exam
    [HttpGet]
    public async Task<IActionResult> StartExam(int examId)
    {
        var existingExam = await _examService.GetSingleExamAsync(examId);

        if (existingExam is null)
        {
            return NotFound();
        }

        TempData["examId"] = existingExam.ExamId;

        return RedirectToAction("ExamPage", new { examId = existingExam.ExamId });
    }

    public async Task<IActionResult> ExamPage(int examId)
    {
        var existingExam = await _examService.GetSingleExamAsync(examId);

        if (existingExam is null)
        {
            return NotFound();
        }

        return View(existingExam);
    }
    #endregion


    #region Create Exam
    public async Task<IActionResult> Create()
    {
        ViewBag.Subjects = await _examService.GetAllSubjectsAsync();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreateExamViewModel model)
    {
        if (ModelState.IsValid)
        {
            var examId = 0;
            if (model.ExamType == ExamType.Final)
            {
                examId = _examService.CreateFinalExam(model);
            }
            else if (model.ExamType == ExamType.Practical)
            {
                examId = _examService.CreatePracticalExam(model);
            }

            return RedirectToAction("AssignQuestion", new { examId, model.ExamType });
        }
        return View(model);
    }
    #endregion

    #region Add Answer
    public IActionResult AddAnswer(int questionId, QuestionType questionType)
    {
        var model = new CreateAnswerViewModel
        {
            QuestionId = questionId,
            QuestionType = questionType
        };

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddAnswer(CreateAnswerViewModel model)
    {
        if (ModelState.IsValid)
        {
            _examService.AddAnswerToQuestion(model.QuestionId, model.QuestionType, new CreateAnswerViewModel
            {
                Answer = model.Answer,
                IsCorrect = model.IsCorrect
            });


            return RedirectToAction("AddAnswer", new { questionId = model.QuestionId, questionType = model.QuestionType });
        }

        return View(model);
    }
    #endregion

    #region Add Question
    // GET: Exam/AssignQuestion
    public IActionResult AssignQuestion(int examId, ExamType examType)
    {
        var model = new AssignQuestionViewModel
        {
            ExamId = examId,
            ExamType = examType
        };

        return View(model);
    }

    // POST: Exam/AssignQuestion
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AssignQuestion(AssignQuestionViewModel model)
    {
        if (ModelState.IsValid)
        {
            int questionsAddedCount = HttpContext.Session.GetInt32("QuestionsAddedCount") ?? 0;

            var questionId = _examService.AssignQuestionToExam(model.QuestionType, model.ExamType, model.CreateQuestionViewModel, model.ExamId);

            questionsAddedCount++;
            HttpContext.Session.SetInt32("QuestionsAddedCount", questionsAddedCount);

            var numberOfQuestions = await _examService.GetQuestionsCountAsync(model.ExamId, model.ExamType);

            //// Check if the number of questions added meets or exceeds the number specified
            //if (questionsAddedCount >= numberOfQuestions)
            //{
            //    HttpContext.Session.Remove("QuestionsAddedCount");
            //    return RedirectToAction("Index", "Home");
            //}

            return RedirectToAction("AddAnswer", new { questionId = questionId, questionType = model.QuestionType });
        }
        return View(model);
    }
    #endregion

    [HttpPost]
    public async Task<IActionResult> SubmitExam(ExamViewModel model)
    {
        var exam = await _examService.GetSingleExamAsync(model.ExamId);

        if (exam == null)
        {
            return NotFound();
        }

        int score = 0;

        foreach (var submittedQuestion in model.Questions)
        {
            var question = exam.Questions.FirstOrDefault(q => q.QuestionId == submittedQuestion.QuestionId);
            if (question != null)
            {
                var correctAnswer = question.Answers.FirstOrDefault(a => a.IsCorrect);
                if (correctAnswer != null && correctAnswer.AnswerId == submittedQuestion.SelectedAnswerId)
                {
                    score += question.Mark;
                }
            }
        }

        return RedirectToAction("Result", new { score });
    }


    public IActionResult Result(int score)
    {
        return View(score);
    }

    public IActionResult AddQuestionToExam(int examId)
    {
        HttpContext.Session.SetInt32("examId", examId);
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddQuestionToExam(AddQuestionToExamViewModel model)
    {
        var examId = HttpContext.Session.GetInt32("examId");

        if (!examId.HasValue)
            return NotFound();

        var exam = await _examService.GetSingleExamAsync(examId.Value);

        if (exam == null)
            return NotFound();

        var createExamModel = new CreateQuestionViewModel
        {
            Mark = model.Mark,
            Body = model.Body
        };

        // get the count of questions for this exam to be tracked
        var questionsCount = await _examService.GetQuestionsCountAsync(examId.Value, exam.ExamType);

        if (questionsCount == exam.NumberOfQuestions)
        {
            TempData["MaxLimit"] = "You have reatched the maximum number of questions for this exam";
            return RedirectToAction(nameof(Index));
        }

        var id = _examService.AssignQuestionToExam(model.QuestionType, exam.ExamType, createExamModel, exam.ExamId);

        return RedirectToAction(nameof(AddAnswer), new { questionId = id, questionType = model.QuestionType });
    }

}
