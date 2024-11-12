using UserService.API.Enpoints.User;
using FastEndpoints;
using UserService.Domain.Entities;
using UserService.Domain.Commons.Requests;
using Microsoft.AspNetCore.Identity;
using UserService.Domain.Models;
using UserService.Infrastructure.Services.Implementations;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.API.Enpoints.UserProfile;

public class CreateUserProfile : Endpoint<UserProfileRequest>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IUserProfileService _userProfileService;
    private readonly IAdvanseService _advanseService;
    private readonly IProgressService _progressService;

    public CreateUserProfile(UserManager<AppUser> userManager, 
        IMapper mapper, 
        IUserProfileService userProfileService, 
        IAdvanseService advanseService,
        IProgressService progressService)
    {
        _userManager = userManager;
        _mapper = mapper;
        _userProfileService = userProfileService;
        _advanseService = advanseService;
        _progressService = progressService;
    }

    public override void Configure()
    {
        Post("create");
        AllowAnonymous();
        Group<UserProfileEndpointGroup>();
        Summary(sum =>
        {
            sum.Summary = "Создание нового пользователя";
            sum.Description = "Эндпоинт для создания нового пользователя";
        });
    }

    public override async Task HandleAsync(UserProfileRequest req, CancellationToken ct)
    {
        var user = await _userManager.FindByEmailAsync(req.Email);

        if (user == null) throw new Exception("Такого email не существует");
        var model = _mapper.Map<UserProfileModel>(req);
        model.UserId = user.Id;

        await _progressService.CreateProgressAsync(user.Id, ct);
        await _advanseService.CreateUserAdvanseAsync(user.Id, ct);
        await _userProfileService.CreateUserProfileAsync(model, ct);
    }
}
