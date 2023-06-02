using EyeD.Domain.ValueObjects;

namespace EyeD.UnitTests.FakeData
{
    internal sealed class FullNameFakeData
    {
        internal FullName FullNameInvalido = new("");
        internal FullName FullNameValido = new("Felipe");
    }
}
