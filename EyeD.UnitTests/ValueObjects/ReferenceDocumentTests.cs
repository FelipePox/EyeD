using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects;

public sealed class ReferenceDocumentTests
{
    [Theory]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("ss")]
    [InlineData("sss")]
    [InlineData("aaaa")]
    [InlineData("aaaaa")]
    [InlineData("ssssss")]
    [InlineData("sssssss")]
    [InlineData("ssssssss")]
    [InlineData("sssssssss")]
    [InlineData("   ")]
    [InlineData(StaticData.MAIS_DE_16_CHAR)]

    public void ShoulReturnErrorWhen_ReferenceDocument_isInvalid(string document)
    {
        var d = new ReferenceDocument(document);
        Assert.False(d.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhen_ReferenceDocument_isValid()
    {
        var d = new ReferenceDocument("djdkdldkdjsk");
        Assert.True(d.IsValid);
    }
}
