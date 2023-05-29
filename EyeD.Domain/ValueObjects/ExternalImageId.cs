using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects;

public sealed class ExternalImageId : ValueObject
{
    public ExternalImageId()
    {}

    public ExternalImageId(string texto)
    {
        Texto = texto;

        AddNotifications(new Contract<ExternalImageId>()
       .Requires()
       .IsNotNullOrWhiteSpace(Texto, "ExternalImageId.Texto", "O ExternalImageId não pode ser vazia")
       .IsGreaterOrEqualsThan(Texto.Length, 10, "ExternalImageId.Texto", "O ExternalImageId não pode conter menos de 10 caracteres.")
       .IsLowerOrEqualsThan(Texto.Length, 50, "ExternalImageId.Texto", "O ExternalImageId não pode conter mais de 50 caracteres.")
         );
    }
    public string Texto { get; private set; }
}
