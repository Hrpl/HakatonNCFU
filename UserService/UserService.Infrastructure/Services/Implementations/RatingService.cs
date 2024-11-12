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

public class RatingService : IRatingService
{
    private readonly IAsyncRepository _asyncRepository;
    public RatingService(IAsyncRepository asyncRepository)
    {
        _asyncRepository = asyncRepository;
    }
    public async Task CreateRatingRecordAsync(int userId, CancellationToken ct)
    {
        var model = new RatingModel();
        model.UserId = userId;

        var query = _asyncRepository.GetQueryBuilder("Rating")
            .AsInsert(model);

        await _asyncRepository.ExecuteAsync(query, ct);
    }
}
