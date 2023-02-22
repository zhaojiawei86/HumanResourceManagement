using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRM.WebMVCApp.Controllers
{
    public class InterviewController : Controller
    {
        private readonly IInterviewServiceAsync interviewServiceAsync;
        private readonly ISubmissionServiceAsync submissionServiceAsync;
        private readonly IInterviewStatusServiceAsync interviewStatusServiceAsync;
        private readonly IInterviewTypeServiceAsync interviewTypeServiceAsync;
        private readonly IEmployeeServiceAsync employeeServiceAsync;

        public InterviewController(IInterviewServiceAsync _interviewServiceAsync,
                                    ISubmissionServiceAsync _submissionServiceAsync,
                                    IInterviewStatusServiceAsync _interviewStatusServiceAsync,
                                    IInterviewTypeServiceAsync _interviewTypeServiceAsync,
                                    IEmployeeServiceAsync _employeeServiceAsync)
        {
            interviewServiceAsync = _interviewServiceAsync;
            submissionServiceAsync = _submissionServiceAsync;
            interviewStatusServiceAsync = _interviewStatusServiceAsync;
            interviewTypeServiceAsync = _interviewTypeServiceAsync;
            employeeServiceAsync = _employeeServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var interviewCollection = await interviewServiceAsync.GetAllAsync();
            return View(interviewCollection);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.SubmissionList = new SelectList(await submissionServiceAsync.GetAllAsync(), "Id", "CandidateId", "JobRequirementId");
            ViewBag.InterviewStatusList = new SelectList(await interviewStatusServiceAsync.GetAllAsync(), "Id", "Title");
            ViewBag.InterviewTypeList = new SelectList(await interviewTypeServiceAsync.GetAllAsync(), "Id", "Title");
            ViewBag.EmployeeList = new SelectList(await employeeServiceAsync.GetAllAsync(), "Id", "FirstName");
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
            ViewBag.SubmissionList = new SelectList(await submissionServiceAsync.GetAllAsync(), "Id", "CandidateId", "JobRequirementId");
            ViewBag.InterviewStatusList = new SelectList(await interviewStatusServiceAsync.GetAllAsync(), "Id", "Title");
            ViewBag.InterviewTypeList = new SelectList(await interviewTypeServiceAsync.GetAllAsync(), "Id", "Title");
            ViewBag.EmployeeList = new SelectList(await employeeServiceAsync.GetAllAsync(), "Id", "FirstName");
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

