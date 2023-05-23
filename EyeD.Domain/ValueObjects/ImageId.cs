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
       .IsNotNullOrWhiteSpace(Texto, "ImageId.Texto", "O ImageId não pode ser vazia")
       .IsGreaterOrEqualsThan(Texto.Length, 10, "ImageId.Texto", "O ImageId não pode conter menos de 10 caracteres.")
       .IsLowerOrEqualsThan(Texto.Length, 36, "ImageId.Texto", "O ImageId não pode conter mais de 36 caracteres.")
         );
    }
    public string Texto { get; private set; }
}
