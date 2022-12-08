using PushupApi.Models;

namespace PushupApi.Data;

public class AsyncDayRepository : BaseDbConnector, IAsyncRepository<PushupDay> {
    public Task<PushupDay> GetById(int id) => throw new NotImplementedException();

    public Task<IEnumerable<PushupDay>> GetAll() => throw new NotImplementedException();
    public Task<bool> ContainsById(int id) => throw new NotImplementedException();

    public Task<PushupDay> Insert(PushupDay user) => throw new NotImplementedException();

    public Task<PushupDay> Update(PushupDay user) => throw new NotImplementedException();
}