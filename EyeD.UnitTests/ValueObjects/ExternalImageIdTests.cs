using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects
{
    public sealed class ExternalImageIdTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("Ab")]
        [InlineData("     ")]
        [InlineData(StaticData.MAIS_DE_150_CHAR)]

        public void ShouldReturn_Error_When_ExternalImageId_IsInvalid(string imageId)
        {
           var externalId = new ExternalImageId(imageId);
            Assert.False(externalId.IsValid);
        }

        [Fact]
        public void ShouldReturn_Success_When_ExternalImageId_IsValid()
        {
            var externalId = new ExternalImageId("dfhcjd-dokeiue4");
            Assert.True(externalId.IsValid);
        }
    }
}
