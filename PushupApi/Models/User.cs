using LiteDB;
using PushupApi.Data;

namespace PushupApi.Models;

public class User {
    [BsonId]
    public int ID { get; set; }

    public string Name { get; set; }
    public int MaxPushupCount { get; set; }
    public int CurrentDayInPlan { get; set; }

    [BsonRef(PushupPlan.PLAN_COLLECTION)]
    public PushupPlan? CurrentPlan { get; set; }

    protected bool Equals(User other) => ID == other?.ID && Name == other.Name && MaxPushupCount == other.MaxPushupCount && CurrentDayInPlan == other.CurrentDayInPlan && CurrentPlan == other.CurrentPlan;

    public override bool Equals(object? obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((User)obj);
    }

    public override int GetHashCode() => HashCode.Combine(ID, Name, MaxPushupCount, CurrentDayInPlan, CurrentPlan);
}