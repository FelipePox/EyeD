using EyeD.Domain.Core.Entities;
using EyeD.Domain.ValueObjects;

namespace EyeD.Domain.Entities;

public sealed class Vehicles : Entity
{
    private Vehicles()
    {}

    public Vehicles(Plate plate, Model model, Brand brand, ModelYear modelYear, ReferenceDocument referenceDocument, Description motivo) : base()
    {
        Plate = plate;
        Model = model;
        Brand = brand;
        ModelYear = modelYear;
        ReferenceDocument = referenceDocument;
        Motivo = motivo;

        AddNotifications(Plate, Model, Brand, ModelYear, ReferenceDocument,Motivo);
    }

    public Plate Plate { get; private set; } = null!;
    public Model Model { get; private set; } = null!;
    public Brand Brand { get; private set; } = null!;
    public ModelYear ModelYear { get; private set; } = null!;
    public ReferenceDocument ReferenceDocument { get; private set; } = null!;
    public Description Motivo { get; private set; } = null!;


    public void Update(Plate plate, Model model, Brand brand, ModelYear modelYear,ReferenceDocument referenceDocument,Description motivo)
    {
        Plate = plate;
        Model = model;
        Brand = brand;
        ModelYear = modelYear;
        ReferenceDocument = referenceDocument;
        Motivo = motivo;

        AddNotifications(Plate, Model, Brand, ModelYear);
        if (IsValid)
            AtualizadoEm = DateTime.Now.ToLocalTime();
    }

}
