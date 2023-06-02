﻿namespace EyeD.Application.ViewModels.Peoples
{
    public class ResponsePeopleViewModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string FaceId { get; set; } = null!;
        public string ImageId { get; set; } = null!;
        public string ExternalImageId { get; set; } = null!;
        public string ReferenceDocument { get; set; } = null!;
        public string Imagem { get; set; } = null!;
        public string Motivo { get; set; } = null!;


        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public bool Ativo { get; set; }
    }
}
