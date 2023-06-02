using EyeD.Domain.Core.ValueObjects;
using Flunt.Validations;

namespace EyeD.Domain.ValueObjects;

public sealed class RecoverPassword : ValueObject
{
    public RecoverPassword(bool request, DateTime? expirationDate)
    {
        Request = request;
        ExpirationDate ??= expirationDate;

        AddNotifications(new Contract<RecoverPassword>()
            .Requires()
            .IsTrue(Validate(), "RecoverPassword.ExpirationDate", "The expiration date must be null when request is false otherwise must be a valid date.")
            );
    }


    public bool Request { get; private set; } = false;
    public DateTime? ExpirationDate { get; private set; } = null!;

    private bool Validate()
    {
        if (Request is false)
            return ExpirationDate is null;
        else
            return ExpirationDate is not null;
    }

}
