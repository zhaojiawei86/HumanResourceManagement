using System;
using System.ComponentModel.DataAnnotations;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Entity;
using HRM.ApplicationCore.Model.Request;

namespace HRM.Infrastructure.Service
{
	public class CandidateServiceAsync : ICandidateServiceAsync
	{
        private readonly ICandidateRepositoryAsync candidateRepositoryAsync;

        public CandidateServiceAsync(ICandidateRepositoryAsync _candidateRepositoryAsync)
		{
            candidateRepositoryAsync = _candidateRepositoryAsync;
        }

        public async Task<int> AddCandidateAsync(CandidateRequestModel model)
        {
            Candidate candidate = new Candidate()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                Email = model.Email,
                currentAddress = model.currentAddress,
                ResumeUrl = model.ResumeUrl
            };
            return await candidateRepositoryAsync.InsertAsync(candidate);
        }

        public Task<int> DeleteCandidateAsync(CandidateRequestModel model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CandidateRequestModel>> GetAllCandidatesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CandidateRequestModel> GetCandidateByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateCandidateAsync(CandidateRequestModel model)
        {
            throw new NotImplementedException();
        }
    }
}

