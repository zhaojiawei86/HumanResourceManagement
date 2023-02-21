using System;
using System.ComponentModel.DataAnnotations;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Entity;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;

namespace HRM.Infrastructure.Service
{
	public class InterviewServiceAsync : IInterviewServiceAsync
    {
        private readonly IInterviewRepositoryAsync interviewRepositoryAsync;

        public InterviewServiceAsync(IInterviewRepositoryAsync _interviewRepositoryAsync)
		{
            interviewRepositoryAsync = _interviewRepositoryAsync;
        }

        // async for insert is not necessory, speed up
        public Task<int> AddAsync(InterviewRequestModel model)
        {
            Interview interview = new Interview()
            {
                SubmissionId = model.SubmissionId,
                InterviewDate = model.InterviewDate,
                InterviewRound = model.InterviewRound,
                InterviewTypeId = model.InterviewTypeId,
                InterviewStatusId = model.InterviewStatusId,
                InterviewerId = model.InterviewerId
            };
            return interviewRepositoryAsync.InsertAsync(interview);
        }

        public Task<int> DeleteAsync(int id)
        {
            return interviewRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<InterviewResponseModel>> GetAllAsync()
        {
            var result = await interviewRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new InterviewResponseModel()
                {
                    Id = x.Id,
                    SubmissionId = x.SubmissionId,
                    InterviewDate = x.InterviewDate,
                    InterviewRound = x.InterviewRound,
                    InterviewTypeId = x.InterviewTypeId,
                    InterviewStatusId = x.InterviewStatusId,
                    InterviewerId = x.InterviewerId
                });
            }
            return null;
            
        }

        public async Task<InterviewResponseModel> GetByIdAsync(int id)
        {
            var result = await interviewRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new InterviewResponseModel()
                {
                    Id = result.Id,
                    SubmissionId = result.SubmissionId,
                    InterviewRound = result.InterviewRound,
                    InterviewTypeId = result.InterviewTypeId,
                    InterviewStatusId = result.InterviewStatusId,
                    InterviewerId = result.InterviewerId
                };
            }
            return null;
        }

        public async Task<int> UpdateAsync(InterviewRequestModel model)
        {
            Interview interview = new Interview()
            {
                Id = model.Id,
                SubmissionId = model.SubmissionId,
                InterviewDate = model.InterviewDate,
                InterviewRound = model.InterviewRound,
                InterviewTypeId = model.InterviewTypeId,
                InterviewStatusId = model.InterviewStatusId,
                InterviewerId = model.InterviewerId
            };
            return await interviewRepositoryAsync.UpdateAsync(interview);
        }
    }
}

