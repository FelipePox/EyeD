using EyeD.Domain.ValueObjects;

namespace EyeD.UnitTests.FakeData;

internal sealed class MacAddressFakeData
{
    internal MacAddress InvalidMacAdress = new("");
    internal MacAddress ValidMacAdress = new("ewdhdsiocxcxd");

}
