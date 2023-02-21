using System;
using System.ComponentModel.DataAnnotations;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Entity;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;

namespace HRM.Infrastructure.Service
{
	public class InterviewStatusServiceAsync : IInterviewStatusServiceAsync
    {
        private readonly IInterviewStatusRepositoryAsync interviewStatusRepositoryAsync;

        public InterviewStatusServiceAsync(IInterviewStatusRepositoryAsync _interviewStatusRepositoryAsync)
		{
            interviewStatusRepositoryAsync = _interviewStatusRepositoryAsync;
        }

        // async for insert is not necessory, speed up
        public Task<int> AddAsync(InterviewStatusRequestModel model)
        {
            InterviewStatus interviewStatus = new InterviewStatus()
            {
                Title = model.Title,
                IsActive = model.IsActive
            };
            return interviewStatusRepositoryAsync.InsertAsync(interviewStatus);
        }

        public Task<int> DeleteAsync(int id)
        {
            return interviewStatusRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewStatusResponseModel>> GetAllAsync()
        {
            var result = await interviewStatusRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewStatusResponseModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsActive = x.IsActive
                });
            }
            return null;
            
        }

        public async Task<InterviewStatusResponseModel> GetByIdAsync(int id)
        {
            var result = await interviewStatusRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewStatusResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public async Task<int> UpdateAsync(InterviewStatusRequestModel model)
        {
            InterviewStatus interviewStatus = new InterviewStatus()
            {
                Id = model.Id,
                Title = model.Title,
                IsActive = model.IsActive
            };
            return await interviewStatusRepositoryAsync.UpdateAsync(interviewStatus);
        }
    }
}

