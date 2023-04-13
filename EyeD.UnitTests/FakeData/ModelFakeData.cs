using EyeD.Domain.ValueObjects;

namespace EyeD.UnitTests.FakeData;

internal sealed class ModelFakeData
{
    internal Model ModelInvalid = new("");
    internal Model ModelValid = new("FordMustang-2020");
}
