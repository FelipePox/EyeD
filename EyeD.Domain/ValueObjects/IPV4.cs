using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects
{
    public sealed class IPV4 : ValueObject
    {
        public IPV4()
        {}
        public IPV4(string texto)
        {
            Texto = texto;
            AddNotifications(new Contract<IPV4>()
           .Requires()
           .IsNotNullOrWhiteSpace(Texto, "IPV4.Texto", "O IPV4 não pode ser vazio")
           .IsGreaterOrEqualsThan(Texto.Length, 5, "IPV4.Texto", "O IPV4 não pode conter menos de 5 caracteres.")
           .IsLowerOrEqualsThan(Texto.Length, 20, "IPV4.Texto", "O IPV4 não pode conter mais de 20 caracteres.")
         );

        }
        public string Texto { get; private set; }
    }
}
