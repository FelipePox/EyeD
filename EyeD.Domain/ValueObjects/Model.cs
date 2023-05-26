using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects
{
   public sealed class Model : ValueObject
    {
        public Model()
        {}

        public Model(string texto)
        {
            Texto = texto;

            AddNotifications(new Contract<Model>()
           .Requires()
           .IsNotNullOrWhiteSpace(Texto, "Model.Texto", "O modelo do carro não pode ser vazia")
           .IsGreaterOrEqualsThan(Texto.Length, 2, "Model.Texto", "O modelo do carro não pode conter menos de 2 caracteres.")
           .IsLowerOrEqualsThan(Texto.Length, 60, "Model.Texto", "O modelo do carro não pode conter mais de 60 caracteres.")
            );
        }
        public string Texto { get; private set; }

    }
}
