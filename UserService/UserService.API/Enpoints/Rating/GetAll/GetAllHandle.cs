using FastEndpoints;
using Microsoft.AspNetCore.Identity;
using UserService.API.Enpoints.Advance;
using UserService.Domain.Commons.Requests;
using UserService.Domain.Commons.Response;
using UserService.Domain.Entities;
using UserService.Infrastructure.Services.Implementations;
using UserService.Infrastructure.Services.Interfaces;

namespace UserService.API.Enpoints.Rating.GetAll;

public class GetAllHandle : EndpointWithoutRequest<IEnumerable<RatingResponse>>
{
    private readonly IMapper _mapper;
    private readonly IRatingService _ratingService;
    public GetAllHandle(IMapper mapper, IRatingService ratingService)
    {
        _mapper = mapper;
        _ratingService = ratingService;
    }

    public override void Configure()
    {
        Post("getAll");
        AllowAnonymous();
        Group<RatingEndpointsGroup>();
        Summary(sum =>
        {
            sum.Summary = "Получение рейтинга";
            sum.Description = "Эндпоинт для получние рейтинга";
        });
    }

    public override async Task HandleAsync(CancellationToken ct)
    {

        var models = await _ratingService.GetRatingUsersAsync(ct);

        var result = _mapper.Map<IEnumerable<RatingResponse>>(models);

        await SendOkAsync(result);
    }
}
