using LiteDB;

namespace PushupApi.Models;

public class PushupPlan {
    public const string PLAN_COLLECTION = "PushupPlans";
    [BsonId]
    public int ID { get; set; }

    [BsonRef(PushupDay.DAY_COLLECTION)]
    public List<PushupDay> Days { get; set; }

    protected bool Equals(PushupPlan other) => ID == other.ID;

    public override bool Equals(object? obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PushupPlan)obj);
    }

    public override int GetHashCode() => ID;
}