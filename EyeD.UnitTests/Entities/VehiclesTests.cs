using EyeD.Domain.Entities;
using EyeD.UnitTests.FakeData;

namespace EyeD.UnitTests.Entities;

public sealed class VehiclesTests
{
    [Fact]
    public void ShouldReturnErrorWhen_Plate_isInvalid()
    {
        var plate = new Vehicles(
            new PlateFakeData().InvalidPlate,
            new ModelFakeData().ModelValid,
            new BrandFakeData().BrandValido,
            new ModelYearFakeData().ValidModelYear
            );

        Assert.False(plate.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhen_Model_isInvalid()
    {
        var plate = new Vehicles(
            new PlateFakeData().ValidPlate,
            new ModelFakeData().ModelInvalid,
            new BrandFakeData().BrandValido,
            new ModelYearFakeData().ValidModelYear
            );

        Assert.False(plate.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhen_Brand_isInvalid()
    {
        var plate = new Vehicles(
            new PlateFakeData().ValidPlate,
            new ModelFakeData().ModelValid,
            new BrandFakeData().BrandInvalido,
            new ModelYearFakeData().ValidModelYear
            );

        Assert.False(plate.IsValid);
    }

    [Fact]
    public void ShouldReturnErrorWhen_modelYear_isInvalid()
    {
        var plate = new Vehicles(
            new PlateFakeData().ValidPlate,
            new ModelFakeData().ModelValid,
            new BrandFakeData().BrandValido,
            new ModelYearFakeData().InvalidModelYear
            );

        Assert.False(plate.IsValid);
    }

    [Fact]
    public void ShouldReturnSuccessWhen_Vehcile_isValid()
    {
        var plate = new Vehicles(
            new PlateFakeData().ValidPlate,
            new ModelFakeData().ModelValid,
            new BrandFakeData().BrandValido,
            new ModelYearFakeData().ValidModelYear
            );

        Assert.True(plate.IsValid);
    }
}
