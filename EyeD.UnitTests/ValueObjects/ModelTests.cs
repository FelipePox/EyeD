using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects;

public sealed class ModelTests
{
    [Theory]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("sd")]
    [InlineData("scc")]
    [InlineData("dddd")]
  
    [InlineData(StaticData.MAIS_DE_150_CHAR)]

    public void ShoulReturnError_WhenModel_isInvalid(string model)
    {
        var m = new Model(model);
        Assert.False(m.IsValid);
    }


    [Fact]
    public void ShouldReturnSuccess_WhenModel_isValid()
    {
        var model = new Model("FordMustang-2020");
        Assert.True(model.IsValid);
    }
}
