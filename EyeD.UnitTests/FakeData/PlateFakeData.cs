using EyeD.Domain.ValueObjects;

namespace EyeD.UnitTests.FakeData;

internal class PlateFakeData
{
    internal Plate InvalidPlate = new("");
    internal Plate ValidPlate = new("BRA-SE");
}
