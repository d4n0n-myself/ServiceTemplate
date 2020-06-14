using System.Threading.Tasks;
using Template.Models.Entities.Base;

namespace Template.Database
{
	public interface IRepository
	{
		Task<bool> DeleteAsync<T>(long? id) where T : HaveId;
		Task<T> GetAsync<T>(long? id) where T : HaveId;
		Task<T[]> GetAllAsync<T>() where T : HaveId;
		Task<bool> SaveAsync<T>(T entity) where T : HaveId;
		Task<bool> UpdateAsync<T>(T entity) where T : HaveId;
	}
}