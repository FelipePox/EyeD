using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects;

public sealed class URL : ValueObject
{
    public URL()
    { }

    public URL(string texto)
    {
        Texto = texto;

        AddNotifications(new Contract<URL>()
            .Requires()
            .IsUrl(Texto, "URL.Texto", "Url inválida.")
            );
    }

    public string Texto { get; private set; }

    public override string ToString() => Texto;

}
