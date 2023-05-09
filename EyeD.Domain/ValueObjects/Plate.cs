using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects
{
    public sealed class Plate : ValueObject
    {
        public Plate()
        {
            
        }
        public Plate(string texto)
        {
            Texto = texto;
            AddNotifications(new Contract<Plate>()
            .Requires()
            .IsNotNullOrWhiteSpace(Texto, "Plate.Texto", "A placa  não pode ser vazia")
            .IsGreaterOrEqualsThan(Texto.Length, 2, "Plate.Texto", "A placa não pode conter menos de 2 caracteres.")
            .IsLowerOrEqualsThan(Texto.Length, 7, "Plate.Texto", "A placa não pode conter mais de 7 caracteres.")
            );
        }
        public string Texto { get; private set; }
    }
}
