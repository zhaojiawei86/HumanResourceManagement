﻿using System;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;

namespace HRM.ApplicationCore.Contract.Service
{
	public interface IEmployeeTypeServiceAsync : IServiceAsync<EmployeeTypeRequestModel, EmployeeTypeResponseModel>
    {
	}
}

