using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;

namespace HRM.WebMVCApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserServiceAsync userServiceAsync;

        public UserController(IUserServiceAsync _userServiceAsync)
        {
            userServiceAsync = _userServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var userCollection = await userServiceAsync.GetAllAsync();
            return View(userCollection);
        }

        public IActionResult Create()

        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserRequestModel model)
        {
            if (ModelState.IsValid)
            {
                // add to db
                await userServiceAsync.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var result = await userServiceAsync.GetByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserRequestModel model)
        {
            try
            {
                await userServiceAsync.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await userServiceAsync.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UserRequestModel model)
        {
            await userServiceAsync.DeleteAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}

