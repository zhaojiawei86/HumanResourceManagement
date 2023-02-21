using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly ISubmissionServiceAsync submissionServiceAsync;

        public SubmissionController(ISubmissionServiceAsync _submissionServiceAsync)
        {
            submissionServiceAsync = _submissionServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var submissionCollection = await submissionServiceAsync.GetAllAsync();
            return View(submissionCollection);
        }

        public IActionResult Create()

        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SubmissionRequestModel model)
        {
            if (ModelState.IsValid)
            {
                // add to db
                await submissionServiceAsync.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await submissionServiceAsync.GetByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SubmissionRequestModel model)
        {
            try
            {
                await submissionServiceAsync.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await submissionServiceAsync.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SubmissionRequestModel model)
        {
            await submissionServiceAsync.DeleteAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}

