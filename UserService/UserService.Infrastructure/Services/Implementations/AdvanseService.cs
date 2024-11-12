using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Models;
using UserService.Infrastructure.Repositories.Interfaces;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.Infrastructure.Services.Implementations;

public class AdvanseService : IAdvanseService
{
    private readonly IAsyncRepository _asyncRepository;
    public AdvanseService(IAsyncRepository asyncRepository)
    {
        _asyncRepository = asyncRepository;
    }

    public async Task CreateUserAdvanseAsync(int userId, CancellationToken ct)
    {
        var model = new AdvanceModel();
        model.UserId = userId;

        var query = _asyncRepository.GetQueryBuilder("Advances")
            .AsInsert(model);

        await _asyncRepository.ExecuteAsync(query, ct);
    }
}
