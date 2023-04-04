using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects
{
    public sealed class FullName : ValueObject
    {

        public FullName()
        {
            
        }
        public FullName(string primeiroNome, string segundoNome, string terceirtoNome)
        {
            PrimeiroNome = primeiroNome;
            SegundoNome = segundoNome;
            TerceiroNome = terceirtoNome;

            AddNotifications(new Contract<FullName>()
           .Requires()
           .IsNotNullOrWhiteSpace(PrimeiroNome, "NomeCompleto.PrimeiroNome", "O nome não pode ser vazio.")
           .IsGreaterOrEqualsThan(PrimeiroNome.Length, 10, "NomeCompleto.PrimeiroNome", "O primeiro nome não pode conter menos de 3 caracteres.")
           .IsLowerOrEqualsThan(PrimeiroNome.Length, 20, "NomeCompleto.PrimeiroNome", "O  primeiro nome não pode conter mais de 20 caracteres.")

           .IsNotNullOrWhiteSpace(SegundoNome, "NomeCompleto.SegundoNome", "O segundo nome não pode ser vazio.")
           .IsGreaterOrEqualsThan(SegundoNome.Length, 10, "NomeCompleto.SegundoNome", "O segundo nome não pode conter menos de 3 caracteres.")
           .IsLowerOrEqualsThan(SegundoNome.Length, 50, "NomeCompleto.SegundoNome", "O segundo nome não pode conter mais de 50 caracteres.")

           .IsNotNullOrWhiteSpace(SegundoNome, "NomeCompleto.TerceiroNome", "O segundo nome não pode ser vazio.")
           .IsGreaterOrEqualsThan(SegundoNome.Length, 10, "NomeCompleto.TerceiroNome", "O terceiro nome não pode conter menos de 3 caracteres.")
           .IsLowerOrEqualsThan(SegundoNome.Length, 35, "NomeCompleto.TerceiroNome", "O terceiro nome não pode conter mais de 35 caracteres.")
           );
        }
        public string PrimeiroNome { get; private set; }
        public string SegundoNome { get; private set; }
        public string TerceiroNome { get; private set; }

    }
}
