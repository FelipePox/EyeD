using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects;

public sealed class Name : ValueObject
{
    public Name()
    { }

    public Name(string texto)
    {
        Texto = texto;
        AddNotifications(new Contract<Name>()
       .Requires()
       .IsNotNullOrWhiteSpace(Texto, "Name.Texto", "O nome não pode ser vazio.")
       .IsGreaterOrEqualsThan(Texto.Length, 3, "Name.Texto", "O nome não pode conter menos de 3 caracteres.")
       .IsLowerOrEqualsThan(Texto.Length, 60, "Name.Texto", "O nome não pode conter mais de 60 caracteres.")
       );
    }

    public string Texto { get; private set; }
    public override string ToString() => Texto;

}
