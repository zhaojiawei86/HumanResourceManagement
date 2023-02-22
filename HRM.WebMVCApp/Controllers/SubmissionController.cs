using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRM.WebMVCApp.Controllers
{
    public class SubmissionController : Controller
    {
        private readonly ISubmissionServiceAsync submissionServiceAsync;
        private readonly ICandidateServiceAsync candidateServiceAsync;
        private readonly IJobRequirementServiceAsync jobRequirementServiceAsync;

        public SubmissionController(ISubmissionServiceAsync _submissionServiceAsync,
                                    ICandidateServiceAsync _candidateServiceAsync,
                                    IJobRequirementServiceAsync _jobRequirementServiceAsync)
        {
            submissionServiceAsync = _submissionServiceAsync;
            candidateServiceAsync = _candidateServiceAsync;
            jobRequirementServiceAsync = _jobRequirementServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var submissionCollection = await submissionServiceAsync.GetAllAsync();
            return View(submissionCollection);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.JobRequirementList = new SelectList(await jobRequirementServiceAsync.GetAllAsync(), "Id", "Title");
            ViewBag.CandidateList = new SelectList(await candidateServiceAsync.GetAllAsync(), "Id", "FirstName");
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
            ViewBag.JobRequirementList = new SelectList(await jobRequirementServiceAsync.GetAllAsync(), "Id", "Title");
            ViewBag.CandidateList = new SelectList(await candidateServiceAsync.GetAllAsync(), "Id", "FirstName");
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

