using AutoMapper;
using EyeD.Application.ViewModels.HMDs;
using EyeD.Application.ViewModels.Peoples;
using EyeD.Application.ViewModels.User;
using EyeD.Application.ViewModels.Vehicles;
using EyeD.Domain.Entities;

namespace EyeD.Application.AutoMapper
{
    public sealed class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<LoginRequestUserViewModel, User>();
            CreateMap<RequestPeopleViewModel, People>();
            CreateMap<RequestVehicleViewModel, Vehicles>();
            CreateMap<RequestHMDViewModel, HMDs>();

        }
    }
}
