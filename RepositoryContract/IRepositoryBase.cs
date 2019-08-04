using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace RepositoryContract
{

    /// <summary>
    /// IRepositoryBase
    /// </summary>
    /// <remarks>This is base interface for repository pattern.</remarks>
    public interface IRepositoryBase<T>
    {
        Task<IEnumerable<T>> GetAll(int page, int size);
        Task<long> GetCount();
        Task<T> Get(string id);
        Task Create(T entity);
        Task<ReplaceOneResult> Update(string id, T entity);
        Task<DeleteResult> Delete(string id);
    }
}
