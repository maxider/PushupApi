using PushupApi.Data;
using PushupApi.Models;

namespace Tests;

public class MockPlanRepo : IAsyncRepository<PushupPlan> {
    private Dictionary<int, PushupPlan> plans;
    private int idCounter = 1;

    public MockPlanRepo() {
        this.plans = new Dictionary<int, PushupPlan>();
    }

    public Task<PushupPlan> GetById(int id) => Task.FromResult(plans[id]);
    public Task<bool> ContainsById(int id) => Task.FromResult(plans.ContainsKey(id));
    public Task<IEnumerable<PushupPlan>> GetAll() => Task.FromResult(plans.Values.AsEnumerable());

    public Task<PushupPlan> Insert(PushupPlan entity) {
        entity.ID = idCounter++;
        plans[entity.ID] = entity;
        return Task.FromResult(entity);
    }

    public Task<bool> Update(PushupPlan entity) {
        if (!plans.ContainsKey(entity.ID)) return Task.FromResult(false);
        plans[entity.ID] = entity;
        return Task.FromResult(true);
    }
}