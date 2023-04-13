using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects;

public sealed class PasswordTests
{
    [Theory]
    [InlineData("")]
    [InlineData("a")]
    [InlineData("dc")]
    [InlineData("dsa")]
    [InlineData("dasd")]
    [InlineData("dasda")]
    [InlineData("dasdaw.7")]
    [InlineData("Dasdasdd7")]
    [InlineData("dasdasdasda.")]
    [InlineData("sdasdasdasd8")]
    [InlineData("dasdadasdasdD")]
    [InlineData("  ")]
    [InlineData(StaticData.MAIS_DE_16_CHAR)]

    public void ShoulReturnError_WhenPassword_isInvalid(string password)
    {
        var senha = new Password(password);
        Assert.False(senha.IsValid);
    }


    [Fact]
    public void ShouldReturnSuccess_WhenPassword_isValid()
    {
        var senha = new Password("Senha7.");
        Assert.True(senha.IsValid);
    }
}
