using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Models;
using UserService.Infrastructure.Repositories.Interfaces;
using UserService.Infrastructure.Services.Interfaces;
using static UserService.Domain.Constant.EntityInformation;

namespace UserService.Infrastructure.Services.Implementations;

public class ProgressService : IProgressService
{
    private readonly IAsyncRepository _asyncRepository;
    public ProgressService(IAsyncRepository asyncRepository)
    {
        _asyncRepository = asyncRepository;
    }

    public async Task CreateProgressAsync(int userId, CancellationToken ct)
    {
        var model = new ProgressModel();
        model.UserId = userId;

        var query = _asyncRepository.GetQueryBuilder("Progresses")
            .AsInsert(model);

        await _asyncRepository.ExecuteAsync(query, ct);
    }
}
