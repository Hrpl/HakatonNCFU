using Microsoft.EntityFrameworkCore;
using UserService.Domain.Entities;
using UserService.Infrastructure.Context;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.Infrastructure.Services.Implementations;

public class UserService : IUserService
{
    private readonly ApplicationDbContext _context;

    public UserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateUserAsync(AppUser user, CancellationToken ct)
    {
        _context.Users.Add(user);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("Ошибка сохранения данных");
        }
    }

    public async Task<AppUser?> FindByEmail(AppUser user, CancellationToken ct)
    {
        var result = await _context.Users.Where(e => e.Email == user.Email).FirstOrDefaultAsync();
        return result;
    }
}
