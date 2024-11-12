using UserService.Domain.Entities;

namespace UserService.Infrastructure.Services.Interfaces;

public interface IUserService
{
    public Task CreateUserAsync(AppUser user, CancellationToken ct);

    public Task<AppUser?> FindByEmail(AppUser user, CancellationToken ct);
}
