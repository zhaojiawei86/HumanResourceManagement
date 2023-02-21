using System;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;

namespace HRM.ApplicationCore.Contract.Service
{
	public interface IEmployeeRoleServiceAsync : IServiceAsync<EmployeeRoleRequestModel, EmployeeRoleResponseModel>
    {
	}
}

