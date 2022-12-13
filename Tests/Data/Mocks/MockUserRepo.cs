using PushupApi.Data;
using PushupApi.Models;

namespace Tests;

public class MockUserRepo : IAsyncRepository<User> {
    private Dictionary<int, User> users;
    private int idCounter = 1;

    public MockUserRepo() {
        this.users = new Dictionary<int, User>();
    }

    Task<User> IAsyncRepository<User>.GetById(int id) => Task.FromResult(users[id]);
    Task<bool> IAsyncRepository<User>.ContainsById(int id) => Task.FromResult(users.ContainsKey(id));
    Task<IEnumerable<User>> IAsyncRepository<User>.GetAll() => Task.FromResult(users.Values.AsEnumerable());

    public Task<User> Insert(User entity) {
        entity.ID = idCounter++;
        users[entity.ID] = entity;
        return Task.FromResult(entity);
    }

    public Task<bool> Update(User entity) {
        if (!users.ContainsKey(entity.ID)) return Task.FromResult(false);
        users[entity.ID] = entity;
        return Task.FromResult(true);
    }
}