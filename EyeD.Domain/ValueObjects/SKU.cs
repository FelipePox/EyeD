using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects;

public sealed class SKU : ValueObject
{
    public SKU()
    {}
    public SKU(string texo)
    {
        Texto = texo;
        AddNotifications(new Contract<SKU>()
       .Requires()
       .IsNotNullOrWhiteSpace(Texto, "SKU.Texto", "O SKU não pode ser vazio")
       .IsGreaterOrEqualsThan(Texto.Length, 5, "SKU.Texto", "O SKU não pode conter menos de 5 caracteres.")
       .IsLowerOrEqualsThan(Texto.Length, 25, "SKU.Texto", " o SKU não pode conter mais de 25 caracteres.")
      );
    }

    public string Texto { get; private set; }
}
