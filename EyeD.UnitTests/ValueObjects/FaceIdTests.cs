using EyeD.Domain.ValueObjects;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.ValueObjects
{
    public sealed class FaceIdTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("Ab")]
        [InlineData("Abcdefkjo")]
        [InlineData("Abcdjo")]
        [InlineData("Abcdefo")]
        [InlineData("     ")]
        [InlineData(StaticData.MAIS_DE_150_CHAR)]

        public void ShouldReturn_Error_When_FaceId_IsInvalid(string faceId)
        {
            var face = new FaceId(faceId);
            Assert.False(face.IsValid);
        }
    }
}
