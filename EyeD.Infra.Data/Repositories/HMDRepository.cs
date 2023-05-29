using EyeD.Domain.Entities;
using EyeD.Domain.Interfaces;
using EyeD.Infra.Data.Context;
using EyeD.Infra.Data.Repositories.Core;

namespace EyeD.Infra.Data.Repositories;

public sealed class HMDRepository : BaseRespository<HMDs> , IHMDRepository
{
    public HMDRepository(EyeDContext context) : base(context)
    {}
}
