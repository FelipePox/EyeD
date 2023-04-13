using EyeD.Domain.ValueObjects;

namespace EyeD.UnitTests.FakeData;

internal sealed class NameFakeData
{
    internal Name InvalidName = new("");
    internal Name ValidName = new("Felipe");
}
