using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects;

public sealed class ReferenceDocument : ValueObject
{
    public ReferenceDocument()
    {}
    public ReferenceDocument(string texto)
    {
        Texto = texto;

        AddNotifications(new Contract<ReferenceDocument>()
     .Requires()
     .IsNotNullOrWhiteSpace(Texto, "ReferenceDocument.Texto", "O ReferenceDocument não pode ser vazia")
     .IsGreaterOrEqualsThan(Texto.Length, 4, "ReferenceDocument.Texto", "O ReferenceDocument não pode conter menos de 4 caracteres.")
     .IsLowerOrEqualsThan(Texto.Length, 15, "ReferenceDocument.Texto", "O ReferenceDocument não pode conter mais de 15 caracteres.")
       );
    }
    public string Texto { get; private set; }
}
