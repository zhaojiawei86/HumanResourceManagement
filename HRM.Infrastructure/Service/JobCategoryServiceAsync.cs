using System;
using System.ComponentModel.DataAnnotations;
using HRM.ApplicationCore.Contract.Repository;
using HRM.ApplicationCore.Contract.Service;
using HRM.ApplicationCore.Entity;
using HRM.ApplicationCore.Model.Request;
using HRM.ApplicationCore.Model.Response;

namespace HRM.Infrastructure.Service
{
	public class JobCategoryServiceAsync : IJobCategoryServiceAsync
    {
        private readonly IJobCategoryRepositoryAsync jobCategoryRepositoryAsync;

        public JobCategoryServiceAsync(IJobCategoryRepositoryAsync _jobCategoryRepositoryAsync)
		{
            jobCategoryRepositoryAsync = _jobCategoryRepositoryAsync;
        }

        // async for insert is not necessory, speed up
        public Task<int> AddAsync(JobCategoryRequestModel model)
        {
            JobCategory jobCategory = new JobCategory()
            {
                Title = model.Title,
                IsActive = model.IsActive
            };
            return jobCategoryRepositoryAsync.InsertAsync(jobCategory);
        }

        public Task<int> DeleteAsync(int id)
        {
            return jobCategoryRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobCategoryResponseModel>> GetAllAsync()
        {
            var result = await jobCategoryRepositoryAsync.GetAllAsync();
            if (result != null)
            {
                return result.ToList().Select(x => new JobCategoryResponseModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    IsActive = x.IsActive
                });
            }
            return null;
            
        }

        public async Task<JobCategoryResponseModel> GetByIdAsync(int id)
        {
            var result = await jobCategoryRepositoryAsync.GetByIdAsync(id);
            if (result != null)
            {
                return new JobCategoryResponseModel()
                {
                    Id = result.Id,
                    Title = result.Title,
                    IsActive = result.IsActive
                };
            }
            return null;
        }

        public async Task<int> UpdateAsync(JobCategoryRequestModel model)
        {
            JobCategory jobCategory = new JobCategory()
            {
                Id = model.Id,
                Title = model.Title,
                IsActive = model.IsActive
            };
            return await jobCategoryRepositoryAsync.UpdateAsync(jobCategory);
        }
    }
}

