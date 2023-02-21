using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class CandidateController : Controller
    {
        private readonly IRoleServiceAsync candidateServiceAsync;

        public CandidateController(IRoleServiceAsync _candidateServiceAsync)
        {
            candidateServiceAsync = _candidateServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var candidateCollection = await candidateServiceAsync.GetAllAsync();
            return View(candidateCollection);
        }

        public IActionResult Create()

        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CandidateRequestModel model)
        {
            if (ModelState.IsValid)
            {
                // add to db
                await candidateServiceAsync.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await candidateServiceAsync.GetByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CandidateRequestModel model)
        {
            try
            {
                await candidateServiceAsync.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await candidateServiceAsync.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CandidateRequestModel model)
        {
            await candidateServiceAsync.DeleteAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}

