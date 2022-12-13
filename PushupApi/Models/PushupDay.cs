using LiteDB;

namespace PushupApi.Models;

public class PushupDay {
    public const string DAY_COLLECTION = "PushupDays";

    [BsonId]
    public int ID { get; set; }

    public float Percentage { get; set; }
    public TimeSpan Interval { get; set; }
    public bool IsTestDay { get; set; }

    protected bool Equals(PushupDay other) => ID == other.ID && Percentage.Equals(other.Percentage) && Interval.Equals(other.Interval) && IsTestDay == other.IsTestDay;

    public override bool Equals(object? obj) {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PushupDay)obj);
    }

    public override int GetHashCode() => HashCode.Combine(ID, Percentage, Interval, IsTestDay);
}