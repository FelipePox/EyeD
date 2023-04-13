using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects;

public sealed class PlateTests
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("a")]
    [InlineData(StaticData.MAIS_DE_16_CHAR)]

    public void ShouldReturnErrorWhen_Plate_isInvalid(string plate)
    {
      var p = new Plate(plate);
      Assert.False(p.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhen_Plate_isValid()
    {
        var p = new Plate("BRA-202");
        Assert.True(p.IsValid);
    }
}
