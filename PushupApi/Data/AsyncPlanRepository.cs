using LiteDB;
using PushupApi.Models;

namespace PushupApi.Data;

public class AsyncPlanRepository : BaseDbConnector, IAsyncRepository<PushupPlan> {
    public Task<PushupPlan> GetById(int id) => throw new NotImplementedException();

    public Task<IEnumerable<PushupPlan>> GetAll() => throw new NotImplementedException();
    public Task<bool> ContainsById(int id) => throw new NotImplementedException();

    public Task<PushupPlan> Insert(PushupPlan user) => throw new NotImplementedException();

    public Task<PushupPlan> Update(PushupPlan user) => throw new NotImplementedException();
}