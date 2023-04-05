﻿namespace EyeD.Application.ViewModels.HMDs
{
    public class ResponseHMDViewModel
    {
        public Guid Id { get; set; }
        public string SKU { get; set; }
        public string IPV4 { get; set; }
        public string Description { get; set; }
        public string MacAddress { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public bool Ativo { get; set; }
    }
}