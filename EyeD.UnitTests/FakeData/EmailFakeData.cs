using EyeD.Domain.ValueObjects;

namespace TastyFoods.UnitTests.FakeData;

internal sealed class EmailFakeData
{
    internal Email EmailInvalido = new("");
    internal Email EmailValido = new("felipe.cardoso@go-it.work");
}