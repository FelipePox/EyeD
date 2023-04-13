using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects;

public sealed class NameTests
{
    [Theory]
    [InlineData("")]
    [InlineData("1")]
    [InlineData("ds")]
    [InlineData("     ")]
    [InlineData(StaticData.MAIS_DE_150_CHAR)]

    public void ShoulReturnError_WhenName_isInvalid(string name)
    {
        var n = new Name(name);
        Assert.False(n.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccess_WhenName_isValid()
    {
        var nome = new Name("Felipe");
        Assert.True(nome.IsValid); 
    }
}
