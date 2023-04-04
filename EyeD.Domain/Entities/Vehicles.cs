using EyeD.Domain.Core.Entities;
using EyeD.Domain.ValueObjects;

namespace EyeD.Domain.Entities
{
    public sealed class Vehicles : Entity
    {
        private Vehicles()
        {}

        public Vehicles(Plate plate, Model model, Brand brand, ModelYear modelYear) :base()
        {
            Plate = plate;
            Model = model;
            Brand = brand;
            ModelYear = modelYear;

            AddNotifications(Plate,Model, Brand, ModelYear);
        }

        public Plate Plate { get; private set; }
        public Model Model { get; private set; }
        public Brand Brand { get; private set; }
        public ModelYear ModelYear { get; private set; }

        public void Update(Plate plate, Model model, Brand brand, ModelYear modelYear)
        {
            Plate = plate;
            Model = model;
            Brand = brand;
            ModelYear = modelYear;

            AddNotifications(Plate, Model, Brand, ModelYear);
            if (IsValid)
                AtualizadoEm = DateTime.Now.ToLocalTime();
        }
    }
}
