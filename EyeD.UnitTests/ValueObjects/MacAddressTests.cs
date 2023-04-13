using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects;

public sealed class MacAddressTests
{
    [Theory]
    [InlineData("")]
    [InlineData("     ")]
    [InlineData("a")]
    [InlineData("ad")]
    [InlineData("add")]
    [InlineData("asxs")]
    [InlineData("aaxsg")]
    [InlineData("aasxsd")]
    [InlineData("axsadda")]
    [InlineData("adasxsas")]
    [InlineData("acfghgfds")]
    [InlineData(StaticData.MAIS_DE_150_CHAR)]


    public void ShouldReturnError_WhenMacAddress_isInvalid(string macAddress)
    {
        var mac = new MacAddress(macAddress);
        Assert.False(mac.IsValid);
    }
}
