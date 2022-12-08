using PushupApi.Models;

namespace PushupApi.Data;

public interface IAsyncRepository<T> {
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<bool> ContainsById(int id);
    Task<T> Insert(T user);
    Task<T> Update(T user);
}