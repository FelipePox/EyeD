    using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects;

public sealed class Email : ValueObject
{
    private Email()
    { }

    public Email(string endereco)
    {
        Endereco = endereco;

        AddNotifications(new Contract<Email>()
            .Requires()
            .IsNotNullOrWhiteSpace(Endereco, "Email.Endereco", "O email não pode ser vazio.")
            .IsEmail(Endereco, "Email.Endereco", "Email inválido.")
            );
    }

    public string Endereco { get; private set; }
}
