using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects;

public sealed class IPV4Tests
{
    [Theory]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("ds")]
    [InlineData("dsx")]
    [InlineData("dsdf")]
    [InlineData("     ")]
    [InlineData(StaticData.MAIS_DE_150_CHAR)]
    [InlineData(StaticData.MAIS_DE_16_CHAR)]
    public void ShouldReturnError_WhenIPV4_isInvalid(string ipv4)
    {
        var ip = new IPV4(ipv4);
        Assert.False(ip.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccess_WhenIPV4_isValid()
    {
        var ip = new IPV4("192.168.15.40");
        Assert.True(ip.IsValid);    
    }
}
