using EyeD.Domain.Core.Entities;
using EyeD.Domain.ValueObjects;

namespace EyeD.Domain.Entities;

public sealed class People : Entity
{
    private People()
    { }

    public People(FullName name, FaceId faceId, ImageId imageId, ExternalImageId externalImageId, ReferenceDocument referenceDocument, URL imagem) : base()
    {
        Name = name;
        FaceId = faceId;
        ImageId = imageId;
        ExternalImageId = externalImageId;
        ReferenceDocument = referenceDocument;
        Imagem = imagem;
        AddNotifications(Name, FaceId, ImageId, ExternalImageId, ReferenceDocument, Imagem);
    }
    public FullName Name { get; private set; } = null!;
    public FaceId FaceId { get; private set; } = null!;
    public ImageId ImageId { get; private set; } = null!;
    public ExternalImageId ExternalImageId { get; private set; } = null!;
    public ReferenceDocument ReferenceDocument { get; private set; } = null!;
    public URL Imagem { get; private set; } = null!;

    public void Update(
        FullName name,
        FaceId faceId, 
        ImageId imageId, 
        ExternalImageId externalImageId,
        ReferenceDocument referenceDocument,
        URL imagem)
    {
        Name = name;
        FaceId = faceId;
        ImageId = imageId;
        ExternalImageId = externalImageId;
        ReferenceDocument = referenceDocument;
        Imagem = imagem;

        AddNotifications(Name, FaceId, ImageId, ExternalImageId, ReferenceDocument,Imagem);

        if (IsValid)
            AtualizadoEm = DateTime.Now.ToLocalTime();
    }
}
