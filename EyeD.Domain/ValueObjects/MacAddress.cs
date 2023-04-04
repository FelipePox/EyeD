using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects
{
    public sealed class MacAddress : ValueObject
    {
        public MacAddress()
        {}
        public MacAddress(string texto)
        {
         Texto = texto;
            AddNotifications(new Contract<MacAddress>()
               .Requires()
               .IsNotNullOrWhiteSpace(Texto, "MacAddress.Texto", "O MacAddress não pode ser vazio")
               .IsGreaterOrEqualsThan(Texto.Length, 10, "MacAddress.Texto", "O MacAdress não pode conter menos de 10 caracteres.")
               .IsLowerOrEqualsThan(Texto.Length, 17, "MacAddress.Texto", "O MacAddress não pode conter mais de 17 caracteres.")
               );
        }
        public string Texto { get; private set; }
    }
}
