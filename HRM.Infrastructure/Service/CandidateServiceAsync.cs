using System;
using System.ComponentModel.DataAnnotations;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Entity;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;

namespace HRM.Infrastructure.Service
{
	public class CandidateServiceAsync : ICandidateServiceAsync
	{
        private readonly ICandidateRepositoryAsync candidateRepositoryAsync;

        public CandidateServiceAsync(ICandidateRepositoryAsync _candidateRepositoryAsync)
		{
            candidateRepositoryAsync = _candidateRepositoryAsync;
        }

        // async for insert is not necessory, speed up
        public Task<int> AddCandidateAsync(CandidateRequestModel model)
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
            return candidateRepositoryAsync.InsertAsync(candidate);
        }

        public Task<int> DeleteCandidateAsync(int id)
        {
            return candidateRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CandidateResponseModel>> GetAllCandidatesAsync()
        {
            var result = await candidateRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new CandidateResponseModel()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Phone = x.Phone,
                    Email = x.Email,
                    currentAddress = x.currentAddress,
                    ResumeUrl = x.ResumeUrl
                });
            }
            return null;
            
        }

        public async Task<CandidateResponseModel> GetCandidateByIdAsync(int id)
        {
            var result = await candidateRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new CandidateResponseModel()
                {
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Phone = result.Phone,
                    Email = result.Email,
                    currentAddress = result.currentAddress,
                    ResumeUrl = result.ResumeUrl
                };
            }
            return null;
        }

        public async Task<int> UpdateCandidateAsync(CandidateRequestModel model)
        {
            Candidate candidate = new Candidate()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Phone = model.Phone,
                Email = model.Email,
                currentAddress = model.currentAddress,
                ResumeUrl = model.ResumeUrl
            };
            return await candidateRepositoryAsync.UpdateAsync(candidate);
        }
    }
}

