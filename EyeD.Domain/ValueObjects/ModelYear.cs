using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects
{
   public sealed class ModelYear : ValueObject
    {
        public ModelYear()
        {
            
        }
        public ModelYear(string texto)
        {
            Texto = texto;
            AddNotifications(new Contract<ModelYear>()
           .Requires()
           .IsNotNullOrWhiteSpace(Texto, "ModelYear.Texto", "A descrição não pode ser vazia")
           .IsLowerOrEqualsThan(Texto.Length, 4, "ModelYear.Texto", "O modelo ano do carro não pode contar mais de 4 caracteres")
          );
        }
        public string Texto { get; private set; }
    }
}
