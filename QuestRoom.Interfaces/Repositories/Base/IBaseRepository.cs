using QuestRoom.ViewModel.Common;
using System.Linq.Expressions;

namespace QuestRoom.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> : IDisposable
    {
        public Task<ApiResultViewModel<D>> GetApiResponce<D>(Expression<Func<T, D>> selector,
            int pageIndex,
            int pageSize,
            IEnumerable<SortingRequest> sortingRequests = null,
            IEnumerable<FilterRequest> filterRequests = null);

        Task<bool> IsExistAny(int id);
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T item);
        Task DeleteAsync(int id);
        void Update(T item);
    }
}
