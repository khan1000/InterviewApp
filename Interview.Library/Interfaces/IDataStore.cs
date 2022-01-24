using System.Threading.Tasks;
using System.Collections.Generic;

namespace InterviewApp.Interfaces
{
    public interface IDataStore<T>
    {
        Task<bool> AddItemAsync(T item);

        Task<bool> UpdateItemAsync(T item);

        Task<bool> DeleteItemAsync(string id);

        Task<T?> GetItemAsync(string id);

        Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
    }
}
