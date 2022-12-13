using LiteDB;
using PushupApi.Models;

namespace PushupApi.Data;

public class AsyncPlanRepository : BaseDbConnector, IAsyncRepository<PushupPlan> {
    public async Task<PushupPlan> GetById(int id) {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<PushupPlan>(PushupPlan.PLAN_COLLECTION);
        return await Task.Run((() => collection.Include(p => p.Days).FindById(id)));
    }

    public async Task<IEnumerable<PushupPlan>> GetAll() {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<PushupPlan>(PushupPlan.PLAN_COLLECTION);
        return await Task.Run((() => collection.Include(p => p.Days).FindAll()));
    }

    public async Task<bool> ContainsById(int id) {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<PushupPlan>(PushupPlan.PLAN_COLLECTION);
        return await Task.Run(() => collection.Include(p => p.Days).Exists(b => b.ID == id));
    }

    public async Task<PushupPlan> Insert(PushupPlan entity) {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<PushupPlan>(PushupPlan.PLAN_COLLECTION);
        await Task.Run((() => collection.Include(p => p.Days).Insert(entity)));
        return entity;
    }

    public async Task<bool> Update(PushupPlan entity) {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<PushupPlan>(PushupPlan.PLAN_COLLECTION);
        return await Task.Run((() => collection.Include(p => p.Days).Update(entity)));
    }
}