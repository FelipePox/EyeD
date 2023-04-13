using EyeD.Domain.Entities;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.Entities;

public sealed class PeopleTests
{

    [Fact]
    public void ShouldReturnSuccessWhen_PeopleIsValid()
    {
        var nome = new People(
            new FullNameFakeData().FullNameValido,
            new FaceIdFakeData().ValidFaceId,
            new ImageIdFakeData().ImageIdValido,
            new ExternalImageIdFakeData().ExternalImageIdValido,
            new ReferenceDocumentFakeData().ValidReferenceDocumente

            );

        Assert.True(nome.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhen_fullNameIsInvalid()
    {
        var nome = new People(
            new FullNameFakeData().FullNameInvalido,
            new FaceIdFakeData().ValidFaceId,
            new ImageIdFakeData().ImageIdValido,
            new ExternalImageIdFakeData().ExternalImageIdValido,
            new ReferenceDocumentFakeData().ValidReferenceDocumente

            );

        Assert.False( nome.IsValid );
    }

    [Fact]
    public void ShouldReturnErrorWhen_faceIdIsInvalid()
    {
        var face = new People(
            new FullNameFakeData().FullNameValido,
            new FaceIdFakeData().InvalidFaceId,
            new ImageIdFakeData().ImageIdValido,
            new ExternalImageIdFakeData().ExternalImageIdValido,
            new ReferenceDocumentFakeData().ValidReferenceDocumente

            );

        Assert.False(face.IsValid);
    }


    [Fact]
    public void ShouldReturnErrorWhen_imageIdIsInvalid()
    {
        var image = new People(
            new FullNameFakeData().FullNameValido,
            new FaceIdFakeData().ValidFaceId,
            new ImageIdFakeData().ImageIdInvalido,
            new ExternalImageIdFakeData().ExternalImageIdValido,
            new ReferenceDocumentFakeData().ValidReferenceDocumente

            );

        Assert.False(image.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhen_externalImageIdIsInvalid()
    {
        var externalImage = new People(
            new FullNameFakeData().FullNameValido,
            new FaceIdFakeData().ValidFaceId,
            new ImageIdFakeData().ImageIdValido,
            new ExternalImageIdFakeData().ExternalImageIdInvalido,
            new ReferenceDocumentFakeData().ValidReferenceDocumente

            );

        Assert.False(externalImage.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhen_referenceDocumentsIdIsInvalid()
    {
        var referenceDoc = new People(
            new FullNameFakeData().FullNameValido,
            new FaceIdFakeData().ValidFaceId,
            new ImageIdFakeData().ImageIdValido,
            new ExternalImageIdFakeData().ExternalImageIdValido,
            new ReferenceDocumentFakeData().InvalidReferenceDocumente

            );

        Assert.False(referenceDoc.IsValid);
    }
}
