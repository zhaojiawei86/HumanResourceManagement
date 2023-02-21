using System;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;

namespace HRM.ApplicationCore.Contract.Service
{
	public interface ICandidateServiceAsync
	{
		Task<int> AddCandidateAsync(CandidateRequestModel model);
		Task<int> DeleteCandidateAsync(int id);
		Task<int> UpdateCandidateAsync(CandidateRequestModel model);
		Task<CandidateResponseModel> GetCandidateByIdAsync(int id);
		Task<IEnumerable<CandidateResponseModel>> GetAllCandidatesAsync();
	}
}

