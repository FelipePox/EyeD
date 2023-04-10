using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects;

public sealed class BrandTests
{
    [Theory]
    [InlineData("")]
    [InlineData("     ")]
    [InlineData(StaticData.MAIS_DE_150_CHAR)]

    public void ShouldReturn_Error_When_BrandIsInvalid(string brand)
    {
        var marca = new Brand(brand);

        Assert.False(marca.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_When_BrandIsVallid()
    {
        var marca = new Brand("Lamborghini1000");

        Assert.True(marca.IsValid);
    }

}
