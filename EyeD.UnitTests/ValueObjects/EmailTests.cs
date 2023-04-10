using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects
{
    public sealed class EmailTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("Ab")]
        [InlineData("     ")]
        [InlineData("felipe.cardosogmail.com")]
        [InlineData("felipe.cardoso@gmail.")]
        [InlineData("felipe.cardoso@gmail")]
        [InlineData("felipe.cardoso@.com")]
        [InlineData("@gmail.com")]
        [InlineData(StaticData.MAIS_DE_150_CHAR)]

        public void ShouldReturn_Error_When_Email_IsInvalid(string endereco)
        {
            var email = new Email(endereco);

            Assert.False(email.IsValid);
        }


        [Fact]
        public void ShouldReturn_Success_When_Email_IsValid()
        {
            var email = new Email("felipe.cardoso@go-it.work");

            Assert.True(email.IsValid);
        }
    }
}
