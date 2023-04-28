using AutoMapper;
using EyeD.Application.ViewModels.HMDs;
using EyeD.Application.ViewModels.Peoples;
using EyeD.Application.ViewModels.User;
using EyeD.Application.ViewModels.Vehicles;
using EyeD.Domain.Entities;

namespace EyeD.Application.AutoMapper
{
    public sealed class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<User, LoginResponseUserViewModel>()
                .ForMember(dest => dest.Nome, act => act.MapFrom(src => src.Nome.Texto))
                .ForMember(dest => dest.Email, act => act.MapFrom(src => src.Email.Endereco))
                .ForMember(dest => dest.Senha, act => act.MapFrom(src => src.Password.Texto));

            CreateMap<People, ResponsePeopleViewModel>()
               .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.Name.PrimeiroNome))
               .ForMember(dest => dest.SecondName, act => act.MapFrom(src => src.Name.SegundoNome))
               .ForMember(dest => dest.ThirdName, act => act.MapFrom(src => src.Name.TerceiroNome))
               .ForMember(dest => dest.FaceId, act => act.MapFrom(src => src.FaceId.Texto))
               .ForMember(dest => dest.ImageId, act => act.MapFrom(src => src.ImageId.Texto))
               .ForMember(dest => dest.ExternalImageId, act => act.MapFrom(src => src.ExternalImageId.Texto))
               .ForMember(dest => dest.ImageId, act => act.MapFrom(src => src.ImageId.Texto))
               .ForMember(dest => dest.ReferenceDocument, act => act.MapFrom(src => src.ReferenceDocument.Texto));

            CreateMap<Vehicles, ResponseVehicleViewModel>()
              .ForMember(dest => dest.Plate, act => act.MapFrom(src => src.Plate.Texto))
              .ForMember(dest => dest.Model, act => act.MapFrom(src => src.Model.Texto))
              .ForMember(dest => dest.ModelYear, act => act.MapFrom(src => src.ModelYear.Texto))
              .ForMember(dest => dest.Brand, act => act.MapFrom(src => src.Brand.Texto))
              .ForMember(dest => dest.ReferenceDocument, act => act.MapFrom(src => src.ReferenceDocument.Texto));



            CreateMap<HMDs, ResponseHMDViewModel>()
             .ForMember(dest => dest.SKU, act => act.MapFrom(src => src.SKU.Texto))
             .ForMember(dest => dest.IPV4, act => act.MapFrom(src => src.IPV4.Texto))
             .ForMember(dest => dest.Description, act => act.MapFrom(src => src.Description.Texto))
             .ForMember(dest => dest.MacAddress, act => act.MapFrom(src => src.MacAddress.Texto));
        }
    }
}
