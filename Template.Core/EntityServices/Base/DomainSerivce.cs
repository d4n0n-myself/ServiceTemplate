using System.Collections.Generic;
using System.Threading.Tasks;
using Template.Database;
using Template.Models.Entities.Base;

namespace Template.Core.EntityServices.Base
{
	public class BaseDomainService<T> where T : HaveId
	{
		protected readonly IRepository Repository;

		public BaseDomainService(IRepository repository)
		{
			Repository = repository;
		}

		public async Task DeleteAsync(long id) 
		{
			await Repository.DeleteAsync<T>(id);
		}

		public async Task<T> GetAsync(long entityId)
		{
			return await Repository.GetAsync<T>(entityId);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			return await Repository.GetAllAsync<T>();
		}

		public virtual async Task SaveAsync(T entity)
		{
			await Repository.SaveAsync(entity);
		}

		public virtual async Task UpdateAsync(T entity)
		{
			await Repository.UpdateAsync(entity);
		}
	}
}