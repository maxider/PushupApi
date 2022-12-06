using PushupApi.Services;

namespace Tests;

public class RounderTests {
    [Fact]
    public void NormalRounding() {
        var rounder = new Rounder();
        int rounded = rounder.Round(1.2f);
        Assert.Equal(1, rounded);
        rounded = rounder.Round(1.5f);
        Assert.Equal(2, rounded);
        rounded = rounder.Round(1.7f);
        Assert.Equal(2, rounded);
    }

    [Fact]
    public void DownRounding() {
        var rounder = new Rounder(Rounder.RoundingType.Down);
        int rounded = rounder.Round(1.2f);
        Assert.Equal(1, rounded);
        rounded = rounder.Round(1.5f);
        Assert.Equal(1, rounded);
        rounded = rounder.Round(1.7f);
        Assert.Equal(1, rounded);
    }

    [Fact]
    public void UpRounding() {
        var rounder = new Rounder(Rounder.RoundingType.Up);
        int rounded = rounder.Round(1.2f);
        Assert.Equal(2, rounded);
        rounded = rounder.Round(1.5f);
        Assert.Equal(2, rounded);
        rounded = rounder.Round(1.7f);
        Assert.Equal(2, rounded);
    }
}