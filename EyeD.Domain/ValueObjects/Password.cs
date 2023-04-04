using EyeD.Domain.Core.ValueObjects;
using EyeD.Domain.Helpers;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects
{
    public sealed class Password : ValueObject
    {
        public Password()
        {
            
        }
        public Password(string texto)
        {
            Texto = texto;

            AddNotifications(new Contract<Password>()
                .Requires()
                .IsNotNullOrWhiteSpace(Texto, "Password.Texto", "A senha não pode ser vazia.")
                .IsGreaterOrEqualsThan(Texto.Length, 6, "Password.Texto", "A senha não pode conter menos de 6 caracteres")
                .IsLowerOrEqualsThan(Texto.Length, 16, "Password.Texto", "A senha não pode conter mais de 16 caracteres")
                .IsTrue(Validate(), "Password.Texto", "A senha precisa conter pelo menos uma letra maiúscula, uma letra minúscula, um número e um caractere especial.")
                );
        }
        public string Texto { get; private set; }

        public bool Validate()
        {
            if (Texto.HasUpperCase() &&
                Texto.HasLowerCase() &&
                Texto.HasNumber() &&
                Texto.HasSpecialChar())
                return true;

            return false;
        }
    }
}
