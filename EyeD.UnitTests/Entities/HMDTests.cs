using EyeD.Domain.Entities;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.Entities;

public sealed class HMDTests
{

    [Fact]
    public void ShoulReturnSuccessWhen_HMD_isValid()
    {
        var decription = new HMDs(
            new DescriptionFakeData().DescValido,
            new IPV4FakeData().IPV4Valido,
            new SKUFakeData().ValidSKU,
            new MacAddressFakeData().ValidMacAdress
            );

        Assert.True(decription.IsValid);
    }

    [Fact]
    public void ShoulReturnErrorWhen_Description_isInvalid()
    {
        var decription = new HMDs(
            new DescriptionFakeData().DescInvalido,
            new IPV4FakeData().IPV4Valido,
            new SKUFakeData().ValidSKU,
            new MacAddressFakeData().ValidMacAdress
            );

        Assert.False(decription.IsValid);
    }


    [Fact]
    public void ShoulReturnErrorWhen_IPV4_isInvalid()
    {
        var decription = new HMDs(
            new DescriptionFakeData().DescValido,
            new IPV4FakeData().IPV4Invalido,
            new SKUFakeData().ValidSKU,
            new MacAddressFakeData().ValidMacAdress
            );

        Assert.False(decription.IsValid);
    }

    [Fact]
    public void ShoulReturnErrorWhen_SKU_isInvalid()
    {
        var decription = new HMDs(
            new DescriptionFakeData().DescValido,
            new IPV4FakeData().IPV4Valido,
            new SKUFakeData().InvalidSKU,
            new MacAddressFakeData().ValidMacAdress
            );

        Assert.False(decription.IsValid);
    }

    [Fact]
    public void ShoulReturnErrorWhen_MAC_isInvalid()
    {
        var decription = new HMDs(
            new DescriptionFakeData().DescValido,
            new IPV4FakeData().IPV4Valido,
            new SKUFakeData().ValidSKU,
            new MacAddressFakeData().InvalidMacAdress
            );

        Assert.False(decription.IsValid);
    }
}


