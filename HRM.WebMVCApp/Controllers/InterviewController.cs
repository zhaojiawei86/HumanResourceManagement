using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class InterviewController : Controller
    {
        private readonly IInterviewServiceAsync interviewServiceAsync;

        public InterviewController(IInterviewServiceAsync _interviewServiceAsync)
        {
            interviewServiceAsync = _interviewServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var interviewCollection = await interviewServiceAsync.GetAllAsync();
            return View(interviewCollection);
        }

        public IActionResult Create()

        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InterviewRequestModel model)
        {
            if (ModelState.IsValid)
            {
                // add to db
                await interviewServiceAsync.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await interviewServiceAsync.GetByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(InterviewRequestModel model)
        {
            try
            {
                await interviewServiceAsync.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await interviewServiceAsync.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(InterviewRequestModel model)
        {
            await interviewServiceAsync.DeleteAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}

