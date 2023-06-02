namespace EyeD.Application.ViewModels.Vehicles;

public class ResponseVehicleViewModel
{
    public Guid Id { get; set; }
    public string Plate { get; set; }
    public string Model { get; set; }
    public string ModelYear { get; set; }
    public string Brand { get; set; }
    public string ReferenceDocument { get; set; }
    public string Motivo { get; set; }

    public DateTime CriadoEm { get; set; }
    public DateTime AtualizadoEm { get; set; }
    public bool Ativo { get; set; }
}
