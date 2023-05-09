using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects;

public sealed class ImageId : ValueObject
{
    public ImageId()
    {}

    public ImageId(string texto)
    {
        Texto = texto;

        AddNotifications(new Contract<ImageId>()
       .Requires()
       .IsNotNullOrWhiteSpace(Texto, "ImageId.Texto", "O FaceId não pode ser vazia")
       .IsGreaterOrEqualsThan(Texto.Length, 10, "ImageId.Texto", "O FaceID não pode conter menos de 10 caracteres.")
       .IsLowerOrEqualsThan(Texto.Length, 50, "ImageId.Texto", "O FaceUd não pode conter mais de 50 caracteres.")
         );
    }
    public string Texto { get; private set; }
}
