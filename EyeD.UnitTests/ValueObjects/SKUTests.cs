using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;
using Xunit;

namespace EyeD.UnitTests.ValueObjects;

public sealed class SKUTests
{
    [Theory]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("ss")]
    [InlineData("sss")]
    [InlineData("dsds")]
    [InlineData("    ")]
    [InlineData(StaticData.MAIS_DE_16_CHAR)]

    public void ShouldReturnErrorWhen_SKU_isInvalid(string sku)
    {
        var s = new SKU(sku);
        Assert.False(s.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhen_SKU_isValid()
    {
        var sku = new SKU("djsldjddd-d");
        Assert.True(sku.IsValid);
    }

}
