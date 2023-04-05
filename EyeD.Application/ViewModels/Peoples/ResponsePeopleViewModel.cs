namespace EyeD.Application.ViewModels.Peoples
{
    public class ResponsePeopleViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FaceId { get; set; }
        public string ImageId { get; set; }
        public string ExternalImageId { get; set; }
        public string ReferenceDocument { get; set; }

        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public bool Ativo { get; set; }
    }
}
