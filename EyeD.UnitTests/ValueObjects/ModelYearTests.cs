using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects;

public sealed class ModelYearTests
{
    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("12")]
    [InlineData("123")]
    [InlineData("   ")]
    [InlineData(StaticData.MAIS_DE_150_CHAR)]
    public void ShouldReturnError_WhenModelYear_isInvalid(string modelYear)
    {
        var model = new ModelYear(modelYear);
        Assert.False(model.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccess_WhenModelYear_isValid()
    {
        var model = new ModelYear("2020");
        Assert.True(model.IsValid);
    }

}
