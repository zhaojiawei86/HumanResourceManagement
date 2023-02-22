using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRM.WebMVCApp.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackServiceAsync feedbackServiceAsync;
        private readonly IInterviewServiceAsync interviewServiceAsync;

        public FeedbackController(IFeedbackServiceAsync _feedbackServiceAsync,
                                    IInterviewServiceAsync _interviewServiceAsync)
        {
            feedbackServiceAsync = _feedbackServiceAsync;
            interviewServiceAsync = _interviewServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var feedbackCollection = await feedbackServiceAsync.GetAllAsync();
            return View(feedbackCollection);
        }

        public async Task<IActionResult> Create()

        {
            ViewBag.InterviewList = new SelectList(await interviewServiceAsync.GetAllAsync(), "Id", "Id");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(FeedbackRequestModel model)
        {
            if (ModelState.IsValid)
            {
                // add to db
                await feedbackServiceAsync.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.InterviewList = new SelectList(await interviewServiceAsync.GetAllAsync(), "Id", "Id");
            var result = await feedbackServiceAsync.GetByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(FeedbackRequestModel model)
        {
            try
            {
                await feedbackServiceAsync.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await feedbackServiceAsync.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(FeedbackRequestModel model)
        {
            await feedbackServiceAsync.DeleteAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}

