using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects
{
    public sealed class FaceId : ValueObject
    {
        public FaceId()
        {}
        public FaceId(string texto)
        {
            Texto = texto;

            AddNotifications(new Contract<FaceId>()
           .Requires()
           .IsNotNullOrWhiteSpace(Texto, "FaceId.Texto", "O FaceId não pode ser vazia")
           .IsGreaterOrEqualsThan(Texto.Length, 10, "FaceId.Texto", "O FaceID não pode conter menos de 10 caracteres.")
           .IsLowerOrEqualsThan(Texto.Length, 36, "FaceId.Texto", "O FaceId não pode conter mais de 36 caracteres.")
             );
        }
        public string Texto { get; private set; }
    }
}
