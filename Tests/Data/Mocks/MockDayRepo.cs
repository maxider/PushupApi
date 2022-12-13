using PushupApi.Data;
using PushupApi.Models;

namespace Tests;

public class MockDayRepo : IAsyncRepository<PushupDay> {
    private Dictionary<int, PushupDay> days = new Dictionary<int, PushupDay>();
    private int idCounter = 1;

    public Task<PushupDay> GetById(int id) => Task.FromResult(days[id]);

    public Task<IEnumerable<PushupDay>> GetAll() => throw new NotImplementedException();

    public Task<bool> ContainsById(int id) => throw new NotImplementedException();

    public Task<PushupDay> Insert(PushupDay entity) {
        entity.ID = idCounter++;
        days[entity.ID] = entity;
        return Task.FromResult(entity);
    }

    public Task<bool> Update(PushupDay entity) => throw new NotImplementedException();
}