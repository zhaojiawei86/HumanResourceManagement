using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class InterviewStatusController : Controller
    {
        private readonly IInterviewStatusServiceAsync interviewStatusServiceAsync;

        public InterviewStatusController(IInterviewStatusServiceAsync _interviewStatusServiceAsync)
        {
            interviewStatusServiceAsync = _interviewStatusServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var interviewStatusCollection = await interviewStatusServiceAsync.GetAllAsync();
            return View(interviewStatusCollection);
        }

        public IActionResult Create()

        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InterviewStatusRequestModel model)
        {
            if (ModelState.IsValid)
            {
                // add to db
                await interviewStatusServiceAsync.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await interviewStatusServiceAsync.GetByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(InterviewStatusRequestModel model)
        {
            try
            {
                await interviewStatusServiceAsync.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await interviewStatusServiceAsync.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(InterviewStatusRequestModel model)
        {
            await interviewStatusServiceAsync.DeleteAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}

