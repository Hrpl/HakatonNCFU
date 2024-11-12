using UserService.API.Enpoints.User;
using FastEndpoints;
using UserService.Domain.Commons.Response;
using UserService.Domain.Commons.Requests;
using Microsoft.AspNetCore.Identity;
using UserService.Domain.Entities;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.API.Enpoints.UserProfile.GetAny;

public class GetAnyUserProfileHandle : Endpoint<GetAnyUserProfileRequest, GetUserProfileResponse>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserProfileService _userProfileService;
    private readonly IMapper _mapper;
    public GetAnyUserProfileHandle(UserManager<AppUser> userManager, 
        IUserProfileService userProfileService,
        IMapper mapper) 
    {  
        _userManager = userManager; 
        _userProfileService = userProfileService;
        _mapper = mapper;
    }

    public override void Configure()
    {
        Post("get");
        AllowAnonymous();
        Group<UserProfileEndpointGroup>();
        Summary(sum =>
        {
            sum.Summary = "Получение профиля пользователя";
            sum.Description = "Эндпоинт для получение профиля пользователя";
        });
    }

    public override async Task HandleAsync(GetAnyUserProfileRequest req, CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(req.Email);

        var model = await _userProfileService.GetUserProfileAsync(user.Id, ct);
        if (model == null) throw new Exception("Профиль не найден");
        var result = _mapper.Map<GetUserProfileResponse>(model);

        await SendOkAsync(result);
    }
}
