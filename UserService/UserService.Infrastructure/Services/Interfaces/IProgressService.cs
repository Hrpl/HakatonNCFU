using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserService.Domain.Models;

namespace UserService.Infrastructure.Services.Interfaces;

public interface IProgressService
{
    public Task CreateProgressAsync(int userId, CancellationToken ct);
}
