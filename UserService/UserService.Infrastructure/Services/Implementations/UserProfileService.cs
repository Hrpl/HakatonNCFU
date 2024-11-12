using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Models;
using UserService.Infrastructure.Repositories.Interfaces;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.Infrastructure.Services.Implementations;

public class UserProfileService : IUserProfileService
{
    private readonly IAsyncRepository _asyncRepository;
    public UserProfileService(IAsyncRepository asyncRepository)
    {
        _asyncRepository = asyncRepository;
    }

    public async Task CreateUserProfileAsync(UserProfileModel model, CancellationToken ct)
    {
        model.CreatedAt = DateTime.Now;
        model.UpdatedAt = DateTime.Now;
        model.IsDeleted = false;

        var query = _asyncRepository.GetQueryBuilder("UserProfiles")
            .AsInsert(model);

        await _asyncRepository.ExecuteAsync(query, ct);
    }
}
