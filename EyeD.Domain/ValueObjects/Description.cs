using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects;

public sealed class Description : ValueObject
{
    public Description()
    {}
    public Description(string texto)
    {
        Texto = texto;
        AddNotifications(new Contract<Description>()
        .Requires()
        .IsNotNullOrWhiteSpace(Texto, "Description.Texto", "A descrição não pode ser vazia")
        .IsGreaterOrEqualsThan(Texto.Length, 2, "Description.Texto", "A descrição não pode conter menos de 2 caracteres.")
        .IsLowerOrEqualsThan(Texto.Length, 200, "Description.Texto", "A descrição não pode conter mais de 200 caracteres.")
        );
    }

    public string Texto { get; private set; }

}
