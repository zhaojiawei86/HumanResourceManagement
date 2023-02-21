using System;
using System.ComponentModel.DataAnnotations;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Entity;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;

namespace HRM.Infrastructure.Service
{
	public class InterviewTypeServiceAsync : IInterviewTypeServiceAsync
    {
        private readonly IInterviewTypeRepositoryAsync interviewTypeRepositoryAsync;

        public InterviewTypeServiceAsync(IInterviewTypeRepositoryAsync _interviewTypeRepositoryAsync)
		{
            interviewTypeRepositoryAsync = _interviewTypeRepositoryAsync;
        }

        // async for insert is not necessory, speed up
        public Task<int> AddAsync(InterviewTypeRequestModel model)
        {
            InterviewType interviewType = new InterviewType()
            {
                Title = model.Title,
                IsActive = model.IsActive
            };
            return interviewTypeRepositoryAsync.InsertAsync(interviewType);
        }

        public Task<int> DeleteAsync(int id)
        {
            return interviewTypeRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllAsync()
        {
            var result = await interviewTypeRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewTypeResponseModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsActive = x.IsActive
                });
            }
            return null;
            
        }

        public async Task<InterviewTypeResponseModel> GetByIdAsync(int id)
        {
            var result = await interviewTypeRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewTypeResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public async Task<int> UpdateAsync(InterviewTypeRequestModel model)
        {
            InterviewType interviewType = new InterviewType()
            {
                Id = model.Id,
                Title = model.Title,
                IsActive = model.IsActive
            };
            return await interviewTypeRepositoryAsync.UpdateAsync(interviewType);
        }
    }
}

