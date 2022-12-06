namespace PushupApi.Services;

public class Rounder : IRounder {
    private readonly RoundingType roundingType;

    public Rounder(RoundingType roundingType = RoundingType.Normal) {
        this.roundingType = roundingType;
    }

    public int Round(float amount) {
        switch (roundingType) {
            case RoundingType.Down:
                return (int)Math.Floor(amount);
            case RoundingType.Normal:
                return (int)Math.Round(amount);
            case RoundingType.Up:
                return (int)Math.Ceiling(amount);
            default:
                throw new InvalidOperationException($"No rounding is defined for RoundingType: '{roundingType}'");
        }
    }

    public enum RoundingType {
        Down,
        Normal,
        Up
    }
}