using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects;

public sealed class ImageIdTests
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("d")]
    [InlineData("ds")]
    [InlineData("sda")]
    [InlineData("sdas")]
    [InlineData("dsasd")]
    [InlineData("sdasda")]
    [InlineData("asdasda")]
    [InlineData("asdasdas")]
    [InlineData("asdasdasd")]
    [InlineData("     ")]
    [InlineData(StaticData.MAIS_DE_150_CHAR)]


    public void ShouldReturnError_WhenImageId_IsInvalid(string imageId)
    {
        var image = new ImageId(imageId);
        Assert.False(image.IsValid);
    }


    [Fact]
    public void ShouldReturnSuccess_WhenImageId_IsValid()
    {
        var image = new ImageId("shdjdkfjhdy6-d");
        Assert.True(image.IsValid);
    }
}
