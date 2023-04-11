using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects;

public sealed class DescriptionTests
{
    [Theory]
    [InlineData("")]
    [InlineData("")]
    [InlineData("     ")]
    [InlineData(StaticData.MAIS_DE_150_CHAR)]

   public void ShouldReturn_Error_WhenDescrpiton_IsInvalid(string description)
    {
        var desc = new Description(description);

        Assert.False(desc.IsValid);
    }

    [Fact]
    public void ShouldReturn_Success_DescriptionIsValid()
    {
        var desct = new Description("A melhor descrição de todas");
        Assert.True(desct.IsValid); 
    }
}
