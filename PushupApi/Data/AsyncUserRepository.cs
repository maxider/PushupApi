using com.csutil;
using LiteDB;
using PushupApi.Models;
using PushupApi.Models.Helpers;
using Zio;

namespace PushupApi.Data;

public class BaseDbConnector {
    protected readonly ConnectionString ConnectionString;

    public BaseDbConnector(FileEntry dbFile = null) {
        var curFolder = DirectoryHelpers.GetCurrentDirectoryEntry();
        var file = dbFile ?? curFolder.CreateSubdirectory("./Database").GetChild("Database.db");
        ConnectionString = new ConnectionString(file.GetFullFileSystemPath());
    }
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
        var user = await Task.Run(() => collection.FindById(id));
        if (user == null)
            throw new EntryNotFoundException();
        return user;
    }

    public async Task<IEnumerable<User>> GetAll() {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<User>(USERS_COLLECTION);
        return await Task.Run(() => collection.FindAll());
    }

    public Task<bool> ContainsById(int id) => throw new NotImplementedException();

    public async Task<User> Insert(User user) {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<User>(USERS_COLLECTION);
        await Task.Run(() => collection.Insert(user));
        return user;
    }

    public async Task<User> Update(User user) {
        using var db = new LiteDatabase(ConnectionString);
        var collection = db.GetCollection<User>(USERS_COLLECTION);
        await Task.Run(() => collection.Update(user));
        return user;
    }
}