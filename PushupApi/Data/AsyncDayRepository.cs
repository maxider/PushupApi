using LiteDB;
using PushupApi.Models;

namespace PushupApi.Data;

public class AsyncDayRepository : BaseDbConnector, IAsyncRepository<PushupDay> {
    public async Task<PushupDay> GetById(int id) {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<PushupDay>(PushupDay.DAY_COLLECTION);
        var day = await Task.Run(() => collection.FindById(id));
        return day;
    }

    public Task<IEnumerable<PushupDay>> GetAll() => throw new NotImplementedException();
    public Task<bool> ContainsById(int id) => throw new NotImplementedException();

    public async Task<PushupDay> Insert(PushupDay entity) {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<PushupDay>(PushupDay.DAY_COLLECTION);
        await Task.Run(() => {
            collection.Insert(entity);
            return Task.CompletedTask;
        });
        return entity;
    }

    public async Task<bool> Update(PushupDay entity) {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<PushupDay>(PushupDay.DAY_COLLECTION);
        bool update = false;
        await Task.Run(() => {
            update = collection.Update(entity);
            return Task.CompletedTask;
        });
        return update;
    }
}