using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using UserService.API.Enpoints.Auth;
using UserService.API.Enpoints.User;
using UserService.Domain.Entities;
using UserService.Infrastructure.Services.Implementations;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.API.Enpoints.User.Create;

public class CreateUserHandle : Endpoint<AppUser>
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IUserService _userService;
    public CreateUserHandle(UserManager<AppUser> userManager, IUserService userService)
    {
        _userManager = userManager;
        _userService = userService; 
    }

    public override void Configure()
    {
        Post("create");
        AllowAnonymous();
        Group<UserEndpointGroup>();
        Summary(sum =>
        {
            sum.Summary = "Создание нового пользователя";
            sum.Description = "Эндпоинт для создания нового пользователя";
        });
    }

    public override async Task HandleAsync(AppUser req, CancellationToken ct)
    {
        if(req.Email == "") throw new Exception("Поле Email не заполнено");
        var findEmail = _userService.FindByEmail(req, ct);
        if (findEmail.Result != null) throw new Exception("Пользователь с таким email уже существует");

        var res = await _userManager.CreateAsync(req, req.PasswordHash);
        if (res.Errors.ToList().Count > 0) throw new Exception($"{res.Errors.First().Description}");
        else await SendOkAsync(req.Email);
    }
}
