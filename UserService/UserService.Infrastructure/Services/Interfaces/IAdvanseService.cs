using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Services.Interfaces;

public interface IAdvanseService
{
    public Task CreateUserAdvanseAsync(int userId, CancellationToken ct);
    public Task<AdvanceModel> GetAdvanceAsync(int userId, CancellationToken ct);
}
