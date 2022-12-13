using com.csutil;
using LiteDB;
using PushupApi.Models;
using PushupApi.Models.Helpers;
using Zio;
using BsonMapper = UltraLiteDB.BsonMapper;

namespace PushupApi.Data;

public class BaseDbConnector {
    protected readonly ConnectionString ConnectionString;

    public BaseDbConnector(FileEntry dbFile = null) {
        var curFolder = DirectoryHelpers.GetCurrentDirectoryEntry();
        var file = dbFile ?? curFolder.CreateSubdirectory("./Database").GetChild("Database.db");
        ConnectionString = new ConnectionString(file.GetFullFileSystemPath());
    }

    public LiteDatabase Connect() => new LiteDatabase(ConnectionString);
}

public class AsyncUserRepository : BaseDbConnector, IAsyncRepository<User> {
    private const string USERS_COLLECTION = "Users";

    private IAsyncRepository<PushupPlan> planRepository;

    public AsyncUserRepository(IAsyncRepository<PushupPlan> planRepository) {
        this.planRepository = planRepository;
    }

    public async Task<User> GetById(int id) {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<User>(USERS_COLLECTION);
        var user = await Task.Run(() => IncludePrefix(collection).FindById(id));
        return user;
    }

    public async Task<IEnumerable<User>> GetAll() {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<User>(USERS_COLLECTION);
        return await Task.Run(() => IncludePrefix(collection).FindAll());
    }

    public Task<bool> ContainsById(int id) {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<User>(USERS_COLLECTION);
        return Task.Run(() => IncludePrefix(collection).Exists(u => u.ID == id));
    }

    public async Task<User> Insert(User entity) {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<User>(USERS_COLLECTION);
        await Task.Run(() => {
            IncludePrefix(collection).Insert(entity);
            return Task.CompletedTask;
        });
        return entity;
    }

    public async Task<bool> Update(User entity) {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<User>(USERS_COLLECTION);
        bool update = false;
        await Task.Run(() => {
            update = IncludePrefix(collection).Update(entity);
            return Task.CompletedTask;
        });
        return update;
    }

    private static ILiteCollection<User> IncludePrefix(ILiteCollection<User> collection) {
        return collection.Include(u => u.CurrentPlan).Include(u => u.CurrentPlan.Days);
    }
}