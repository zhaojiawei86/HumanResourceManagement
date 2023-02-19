using System;
using HRM.ApplicationCore.Model.Request;

namespace HRM.ApplicationCore.Contract.Service
{
	public interface ICandidateServiceAsync
	{
		Task<int> AddCandidateAsync(CandidateRequestModel model);
		Task<int> DeleteCandidateAsync(CandidateRequestModel model);
		Task<int> UpdateCandidateAsync(CandidateRequestModel model);
		Task<CandidateRequestModel> GetCandidateByIdAsync(int id);
		Task<IEnumerable<CandidateRequestModel>> GetAllCandidatesAsync();
	}
}

