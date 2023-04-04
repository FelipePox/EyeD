using EyeD.Domain.Entities;
using EyeD.Domain.Interfaces;
using EyeD.Infra.Data.Context;
using EyeD.Infra.Data.Repositories.Core;

namespace EyeD.Infra.Data.Repositories;

public sealed class PeopleRepository : BaseRespository<People> , IPeopleRepository
{
    public PeopleRepository(EyeDContext context) : base(context)
    {}
}
