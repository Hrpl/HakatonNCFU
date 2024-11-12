using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Services.Interfaces;

public interface IRatingService
{
    public Task CreateRatingRecordAsync(int userId, CancellationToken ct);

    public Task<IEnumerable<RatingModel>> GetRatingUsersAsync(CancellationToken ct);
}
