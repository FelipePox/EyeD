using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects
{
    public sealed class FullNameTests
    {
        [Fact]
        public void ShouldReturnSuccess_FullName_isValid()
        {
            var full = new FullName("Felipe");
            Assert.True(full.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("s")]
        [InlineData("     ")]
        [InlineData(StaticData.MAIS_DE_150_CHAR)]

        public void ShouldReturnError_PrimeiroName_isInvalid(string firstName)
        {
            var first = new FullName(firstName);
            Assert.False(first.IsValid);
        }

        [Theory]
        [InlineData("")]
        [InlineData("s")]
        [InlineData("     ")]
        [InlineData(StaticData.MAIS_DE_150_CHAR)]
        public void ShouldReturnError_SegundoName_isInvalid(string secondName)
        {
            var second = new FullName("Felipe");
            Assert.False(second.IsValid);
        }


        [Theory]
        [InlineData("")]
        [InlineData("s")]
        [InlineData("     ")]
        [InlineData(StaticData.MAIS_DE_150_CHAR)]
        public void ShouldReturnError_TerceiroName_isInvalid(string thirdName)
        {
            var third = new FullName("Felipe");
            Assert.False(third.IsValid);
        }

    }
}
