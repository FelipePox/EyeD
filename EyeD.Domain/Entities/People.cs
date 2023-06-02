using EyeD.Domain.Core.Entities;
using EyeD.Domain.ValueObjects;

namespace EyeD.Domain.Entities;

public sealed class People : Entity
{
    private People()
    { }

    public People(FullName name, FaceId faceId, ImageId imageId, ExternalImageId externalImageId, ReferenceDocument referenceDocument, URL imagem,Description motivo) : base()
    {
        Name = name;
        FaceId = faceId;
        ImageId = imageId;
        ExternalImageId = externalImageId;
        ReferenceDocument = referenceDocument;
        Imagem = imagem;
        Motivo = motivo;
        AddNotifications(Name, FaceId, ImageId, ExternalImageId, ReferenceDocument, Imagem, Motivo);
    }
    public FullName Name { get; private set; } = null!;
    public FaceId FaceId { get; private set; } = null!;
    public ImageId ImageId { get; private set; } = null!;
    public ExternalImageId ExternalImageId { get; private set; } = null!;
    public ReferenceDocument ReferenceDocument { get; private set; } = null!;
    public URL Imagem { get; private set; } = null!;
    public Description Motivo { get; private set; } = null!;

    public void Update(
        FullName name,
        FaceId faceId,
        ImageId imageId,
        ExternalImageId externalImageId,
        ReferenceDocument referenceDocument,
        URL imagem,
        Description motivo
        )
    {
        Name = name;
        FaceId = faceId;
        ImageId = imageId;
        ExternalImageId = externalImageId;
        ReferenceDocument = referenceDocument;
        Imagem = imagem;
        Motivo = motivo;

        AddNotifications(Name, FaceId, ImageId, ExternalImageId, ReferenceDocument,Imagem,Motivo);

        if (IsValid)
            AtualizadoEm = DateTime.Now.ToLocalTime();
    }
}
