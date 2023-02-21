using System;
using System.ComponentModel.DataAnnotations;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Entity;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;
using HRM.Infrastructure.Repository;

namespace HRM.Infrastructure.Service
{
	public class FeedbackServiceAsync : IFeedbackServiceAsync
    {
        private readonly IFeedbackRepositoryAsync feedbackRepositoryAsync;

        public FeedbackServiceAsync(IFeedbackRepositoryAsync _feedbackRepositoryAsync)
		{
            feedbackRepositoryAsync = _feedbackRepositoryAsync;
        }

        // async for insert is not necessory, speed up
        public Task<int> AddAsync(FeedbackRequestModel model)
        {
            Feedback feedback = new Feedback()
            {
                InterviewId = model.InterviewId,
                Description = model.Description
            };
            return feedbackRepositoryAsync.InsertAsync(feedback);
        }

        public Task<int> DeleteAsync(int id)
        {
            return feedbackRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<FeedbackResponseModel>> GetAllAsync()
        {
            var result = await feedbackRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new FeedbackResponseModel()
                {
                    Id = x.Id,
                    InterviewId = x.InterviewId,
                    Description = x.Description
                });
            }
            return null;
            
        }

        public async Task<FeedbackResponseModel> GetByIdAsync(int id)
        {
            var result = await feedbackRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new FeedbackResponseModel()
                {
                    Id = result.Id,
                    InterviewId = result.InterviewId,
                    Description = result.Description
                };
            }
            return null;
        }

        public async Task<int> UpdateAsync(FeedbackRequestModel model)
        {
            Feedback feedback = new Feedback()
            {
                Id = model.Id,
                InterviewId = model.InterviewId,
                Description = model.Description
            };
            return await feedbackRepositoryAsync.UpdateAsync(feedback);
        }
    }
}

