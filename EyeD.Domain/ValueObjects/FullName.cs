using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects;

public sealed class FullName : ValueObject
{

    public FullName()
    {}
    public FullName(string primeiroNome)
    {
        PrimeiroNome = primeiroNome;

        AddNotifications(new Contract<FullName>()
       .Requires()
       .IsNotNullOrWhiteSpace(PrimeiroNome, "NomeCompleto.PrimeiroNome", "O primeiro nome não pode ser vazio.")
       .IsGreaterOrEqualsThan(PrimeiroNome.Length, 1, "NomeCompleto.PrimeiroNome", "O primeiro nome não pode conter menos de 1 caracteres.")
       .IsLowerOrEqualsThan(PrimeiroNome.Length, 60, "NomeCompleto.PrimeiroNome", "O  primeiro nome não pode conter mais de 60 caracteres.")
       );
    }
    public string PrimeiroNome { get; private set; } = null!;

}
