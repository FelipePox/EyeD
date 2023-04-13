using EyeD.Domain.ValueObjects;

namespace EyeD.UnitTests.FakeData;

internal sealed class IPV4FakeData
{
    internal IPV4 IPV4Invalido = new("dasddaadasdadadasdasdasdasdadsadasdadadasda");
    internal IPV4 IPV4Valido = new("192.168.15.40");
}
