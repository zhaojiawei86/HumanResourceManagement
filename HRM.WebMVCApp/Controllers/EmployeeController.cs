using System;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using static System.Net.Mime.MediaTypeNames;

namespace HRM.WebMVCApp.Controllers
{
	public class EmployeeController : Controller
    {
        private readonly IEmployeeServiceAsync employeeServiceAsync;
        private readonly IEmployeeRoleServiceAsync employeeRoleServiceAsync;
        private readonly IEmployeeTypeServiceAsync employeeTypeServiceAsync;
        private readonly IEmployeeStatusServiceAsync employeeStatusServiceAsync;

        public EmployeeController(IEmployeeServiceAsync _employeeServiceAsync,
                                  IEmployeeRoleServiceAsync employeeRoleServiceAsync,
                                  IEmployeeTypeServiceAsync employeeTypeServiceAsync,
                                  IEmployeeStatusServiceAsync employeeStatusServiceAsync)
        {
            employeeServiceAsync = _employeeServiceAsync;
            this.employeeRoleServiceAsync = employeeRoleServiceAsync;
            this.employeeTypeServiceAsync = employeeTypeServiceAsync;
            this.employeeStatusServiceAsync = employeeStatusServiceAsync;
        }
        public async Task<IActionResult> Index()
        {
            var employeeCollection = await employeeServiceAsync.GetAllAsync();
            return View(employeeCollection);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.EmployeeRoleList = new SelectList(await employeeRoleServiceAsync.GetAllAsync(), "Id", "Title");
            ViewBag.EmployeeTypeList = new SelectList(await employeeTypeServiceAsync.GetAllAsync(), "Id", "Title");
            ViewBag.EmployeeStatusList = new SelectList(await employeeStatusServiceAsync.GetAllAsync(), "Id", "Title");
            ViewBag.EmployeeList = new SelectList(await employeeServiceAsync.GetAllAsync(), "Id", "FirstName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeRequestModel model)
        {
            if (ModelState.IsValid)
            {
                // add to db
                await employeeServiceAsync.AddAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.EmployeeRoleList = new SelectList(await employeeRoleServiceAsync.GetAllAsync(), "Id", "Title");
            ViewBag.EmployeeTypeList = new SelectList(await employeeTypeServiceAsync.GetAllAsync(), "Id", "Title");
            ViewBag.EmployeeStatusList = new SelectList(await employeeStatusServiceAsync.GetAllAsync(), "Id", "Title");
            ViewBag.EmployeeList = new SelectList(await employeeServiceAsync.GetAllAsync(), "Id", "FirstName");
            var result = await employeeServiceAsync.GetByIdAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeRequestModel model)
        {

            try
            {
                await employeeServiceAsync.UpdateAsync(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await employeeServiceAsync.GetByIdAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeRequestModel model)
        {
            await employeeServiceAsync.DeleteAsync(model.Id);
            return RedirectToAction("Index");

        }
    }
}

