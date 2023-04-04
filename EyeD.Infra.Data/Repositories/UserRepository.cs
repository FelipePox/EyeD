using EyeD.Domain.Entities;
using EyeD.Infra.Data.Context;
using EyeD.Infra.Data.Interfaces;
using EyeD.Infra.Data.Repositories.Core;

namespace EyeD.Infra.Data.Repositories;

public sealed class UserRepository : BaseRespository<User> , IUserRepository
{
    public UserRepository(EyeDContext context) : base(context)
    {}
}
