using PushupApi.Data;
using PushupApi.Models;

namespace Tests;

public class MockRepository : IAsyncRepository<User>, IAsyncRepository<PushupPlan>, IAsyncRepository<PushupDay> {
    private Dictionary<int, User> users;
    private Dictionary<int, PushupPlan> plans;
    private Dictionary<int, PushupDay> days;


    public MockRepository(Dictionary<int, User> users, Dictionary<int, PushupPlan> plans, Dictionary<int, PushupDay> days) {
        this.users = users;
        this.plans = plans;
        this.days  = days;
    }

    public MockRepository() : this(new Dictionary<int, User>(), new Dictionary<int, PushupPlan>(), new Dictionary<int, PushupDay>()) {
    }

    Task<User> IAsyncRepository<User>.GetById(int id) => throw new NotImplementedException();

    Task<IEnumerable<PushupDay>> IAsyncRepository<PushupDay>.GetAll() => throw new NotImplementedException();
    Task<bool> IAsyncRepository<PushupDay>.ContainsById(int id) => throw new NotImplementedException();

    Task<bool> IAsyncRepository<PushupPlan>.ContainsById(int id) => throw new NotImplementedException();

    Task<bool> IAsyncRepository<User>.ContainsById(int id) => throw new NotImplementedException();

    public Task<PushupDay> Insert(PushupDay user) => throw new NotImplementedException();

    public Task<PushupDay> Update(PushupDay user) => throw new NotImplementedException();

    Task<PushupDay> IAsyncRepository<PushupDay>.GetById(int id) => throw new NotImplementedException();

    Task<IEnumerable<PushupPlan>> IAsyncRepository<PushupPlan>.GetAll() => throw new NotImplementedException();

    public Task<PushupPlan> Insert(PushupPlan user) => throw new NotImplementedException();

    public Task<PushupPlan> Update(PushupPlan user) => throw new NotImplementedException();

    Task<PushupPlan> IAsyncRepository<PushupPlan>.GetById(int id) => throw new NotImplementedException();

    Task<IEnumerable<User>> IAsyncRepository<User>.GetAll() => throw new NotImplementedException();

    public Task<User> Insert(User user) => throw new NotImplementedException();

    public Task<User> Update(User user) => throw new NotImplementedException();
}