using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRM.WebMVCApp.Controllers
{
    public class JobRequirementController : Controller
    {
        private readonly IJobRequirementServiceAsync jobRequirementServiceAsync;
        private readonly IJobCategoryServiceAsync jobCategoryServiceAsync;

        public JobRequirementController(IJobRequirementServiceAsync _jobRequirementServiceAsync,
                                        IJobCategoryServiceAsync jobCategoryServiceAsync)
        {
            jobRequirementServiceAsync = _jobRequirementServiceAsync;
            this.jobCategoryServiceAsync = jobCategoryServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var jobRequirementCollection = await jobRequirementServiceAsync.GetAllAsync();
            return View(jobRequirementCollection);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.JobCategoryList = new SelectList(await jobCategoryServiceAsync.GetAllAsync(), "Id", "Title");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JobRequirementRequestModel model)
        {
            if (ModelState.IsValid)
            {
                // add to db
                await jobRequirementServiceAsync.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.JobCategoryList = new SelectList(await jobCategoryServiceAsync.GetAllAsync(), "Id", "Title");
            var result = await jobRequirementServiceAsync.GetByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(JobRequirementRequestModel model)
        {
            try
            {
                await jobRequirementServiceAsync.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await jobRequirementServiceAsync.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(JobRequirementRequestModel model)
        {
            await jobRequirementServiceAsync.DeleteAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}

