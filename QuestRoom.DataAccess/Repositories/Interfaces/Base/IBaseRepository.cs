namespace QuestRoom.DataAccess.Repositories.Interfaces.Base
{
    public interface IBaseRepository<T> : IDisposable
    {
        Task<T> GetByIDAsync(int id);
        Task InsertAsync(T item);
        Task DeleteAsync(int id);
        void Update(T item);
    }
}
