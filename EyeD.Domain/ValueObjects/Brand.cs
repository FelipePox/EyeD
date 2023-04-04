using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects
{
    public sealed class Brand : ValueObject
    {
        public Brand()
        {}

        public Brand(string texto)
        {

            Texto = texto;

            AddNotifications(new Contract<Brand>()
           .Requires()
           .IsNotNullOrWhiteSpace(Texto, "Brand.Texto", "A marca não pode ser vazia")
           .IsGreaterOrEqualsThan(Texto.Length, 2, "Brand.Texto", "A marca pode conter menos de 2 caracteres.")
           .IsLowerOrEqualsThan(Texto.Length, 7, "Brand.Texto", "A marca não pode conter mais de 60 caracteres.")
           );
        }

        public string Texto { get; private set; }
    }
}
