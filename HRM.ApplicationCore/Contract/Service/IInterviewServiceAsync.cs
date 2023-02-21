using System;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;

namespace HRM.ApplicationCore.Contract.Service
{
	public interface IInterviewServiceAsync : IServiceAsync<InterviewRequestModel, InterviewResponseModel>
    {
	}
}

