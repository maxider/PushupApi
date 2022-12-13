using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PushupApi.Data;
using PushupApi.Models;

namespace Tests;

public class MockRepository : IAsyncRepository<User>, IAsyncRepository<PushupPlan>, IAsyncRepository<PushupDay> {
    private Dictionary<int, User> users;
    private Dictionary<int, PushupPlan> plans;
    private Dictionary<int, PushupDay> days;

    private int idCounter = 1;

    public MockRepository(Dictionary<int, User> users, Dictionary<int, PushupPlan> plans, Dictionary<int, PushupDay> days) {
        this.users = users;
        this.plans = plans;
        this.days = days;
    }

    public MockRepository() : this(new Dictionary<int, User>(), new Dictionary<int, PushupPlan>(), new Dictionary<int, PushupDay>()) {
    }

    #region User

    public Task<User> GetById(int id) => Task.FromResult(users[id]);
    public Task<bool> ContainsById(int id) => Task.FromResult(users.ContainsKey(id));
    Task<IEnumerable<User>> IAsyncRepository<User>.GetAll() => Task.FromResult(users.Values.AsEnumerable());
    public Task<User> Insert(User entity) => Task.FromResult(users[idCounter++]);

    public Task<bool> Update(User entity) {
        if (!users.ContainsKey(entity.ID)) return Task.FromResult(false);
        users[entity.ID] = entity;
        return Task.FromResult(true);
    }

    #endregion

    #region Plan

    Task<bool> IAsyncRepository<PushupPlan>.ContainsById(int id) => throw new NotImplementedException();
    Task<IEnumerable<PushupPlan>> IAsyncRepository<PushupPlan>.GetAll() => throw new NotImplementedException();
    public Task<PushupPlan> Insert(PushupPlan entity) => throw new NotImplementedException();
    public Task<bool> Update(PushupPlan entity) => throw new NotImplementedException();
    Task<PushupPlan> IAsyncRepository<PushupPlan>.GetById(int id) => throw new NotImplementedException();

    #endregion

    #region Day

    Task<IEnumerable<PushupDay>> IAsyncRepository<PushupDay>.GetAll() => throw new NotImplementedException();
    Task<bool> IAsyncRepository<PushupDay>.ContainsById(int id) => throw new NotImplementedException();
    public Task<PushupDay> Insert(PushupDay entity) => throw new NotImplementedException();
    public Task<bool> Update(PushupDay entity) => throw new NotImplementedException();
    Task<PushupDay> IAsyncRepository<PushupDay>.GetById(int id) => throw new NotImplementedException();

    #endregion
}