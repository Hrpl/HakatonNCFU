using Microsoft.AspNetCore.Identity;
using UserService.API.Enpoints.Auth;
using UserService.Domain.Models;
using FastEndpoints;
using UserService.Domain.Commons.Requests;
using UserService.Domain.Commons.Response;
using UserService.Infrastructure.Services.Interfaces;
using UserService.Domain.Entities;

namespace UserService.API.Enpoints.Advance.Get;

public class GetAdvanseHandle : Endpoint<GetAnyUserProfileRequest, AdvanseResponse>
{
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    private readonly IAdvanseService _advanseService;

    public GetAdvanseHandle(IMapper mapper, IAdvanseService advanseService, UserManager<AppUser> userManager)
    {
        _mapper = mapper;
        _advanseService = advanseService;
        _userManager = userManager;
    }

    public override void Configure()
    {
        Post("get");
        AllowAnonymous();
        Group<AdvanseEndpointsGroup>();
        Summary(sum =>
        {
            sum.Summary = "Получние достижений";
            sum.Description = "Эндпоинт для получние достижений";
        });
    }

    public override async Task HandleAsync(GetAnyUserProfileRequest req, CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(req.Email);
        
        var model = await _advanseService.GetAdvanceAsync(user.Id, ct);
        if (model == null) throw new Exception("Такого пользователя не существует");
        var result = _mapper.Map<AdvanseResponse>(model);

        await SendOkAsync(result);
    }
}
