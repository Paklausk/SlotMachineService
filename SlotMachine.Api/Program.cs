using Microsoft.AspNetCore.Mvc;
using SlotMachine.Api.Extensions;
using SlotMachine.Api.Responses;
using SlotMachine.Application.Configuration;
using SlotMachine.Application.Extensions;
using SlotMachine.Application.Interfaces;

static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen();

    var databaseConfig = configuration.GetRequiredSection("Database").Get<DatabaseConfig>();
    if (string.IsNullOrWhiteSpace(databaseConfig?.ConnectionString))
    {
        throw new InvalidOperationException("Database connection string is missing or empty");
    }
    if (string.IsNullOrWhiteSpace(databaseConfig?.DatabaseName))
    {
        throw new InvalidOperationException("Database name is missing or empty");
    }

    services.AddSlotMachineServices(databaseConfig);
}

void AddEndpoints(IEndpointRouteBuilder endpoints)
{
    endpoints.MapPost("/player", async (
        [FromServices] IPlayerService playerService,
        [FromQuery] int matrixWidth,
        [FromQuery] int matrixHeight
    ) =>
    {
        if (matrixWidth <= 0 || matrixHeight <= 0)
        {
            return Results.BadRequest("Matrix width and height must be greater than 0");
        }

        var playerDto = await playerService.CreateAsync(matrixWidth, matrixHeight);

        return Results.Ok(playerDto);
    })
        .DisableAntiforgery()
        .WithName("Create Player")
        .WithOpenApi();

    endpoints.MapGet("/player", async (
        [FromServices] IPlayerService playerService,
        [FromQuery] Guid playerId
    ) =>
    {
        var playerDto = await playerService.GetAsync(playerId);
        if (playerDto == null)
        {
            return Results.NotFound("Player not found");
        }

        return Results.Ok(playerDto);
    })
        .WithName("Get Player Info")
        .WithOpenApi();

    endpoints.MapPut("/player/balance", async (
        [FromServices] IPlayerService playerService,
        [FromQuery] Guid playerId,
        [FromQuery] long amount
    ) =>
    {
        var playerDto = await playerService.UpdateBalanceAsync(playerId, amount);
        if (playerDto == null)
        {
            return Results.NotFound("Player not found");
        }

        return Results.Ok(playerDto);
    })
        .DisableAntiforgery()
        .WithName("Update Balance")
        .WithOpenApi();

    endpoints.MapPut("/player/matrix", async (
        [FromServices] IPlayerService playerService,
        [FromQuery] Guid playerId,
        [FromQuery] int matrixWidth,
        [FromQuery] int matrixHeight
    ) =>
    {
        if (matrixWidth <= 0 || matrixHeight <= 0)
        {
            return Results.BadRequest("Matrix width and height must be greater than 0");
        }

        var playerDto = await playerService.UpdateMatrixSizeAsync(playerId, matrixWidth, matrixHeight);
        if (playerDto == null)
        {
            return Results.NotFound("Player not found");
        }

        return Results.Ok(playerDto);
    })
        .DisableAntiforgery()
        .WithName("Update Matrix")
        .WithOpenApi();

    endpoints.MapPost("/spin", async (
        [FromServices] IPlayerService playerService,
        [FromServices] ISlotMachineService slotMachine,
        [FromQuery] Guid playerId,
        [FromQuery] long betAmount
    ) =>
    {
        if (betAmount < 0)
        {
            return Results.BadRequest("Bet amount cannot be negative");
        }

        var playerDto = await playerService.GetAsync(playerId);
        if (playerDto == null)
        {
            return Results.NotFound("Player not found");
        }

        if (playerDto.Balance < betAmount)
        {
            return Results.BadRequest("Insufficient balance");
        }

        var spinResult = slotMachine.Spin(playerDto.MatrixWidth, playerDto.MatrixHeight);

        var winAmount = spinResult.WinMultiplier * betAmount;

        playerDto = await playerService.UpdateBalanceAsync(playerId, winAmount - betAmount);

        var spinResponse = new SpinResponse
        {
            Balance = playerDto!.Balance,
            WinAmount = winAmount,
            SlotMachineMatrix = spinResult.SlotMachineMatrix.ToJaggedIntArray()
        };

        return Results.Ok(spinResponse);
    })
        .DisableAntiforgery()
        .WithName("Spin The Slot Machine")
        .WithOpenApi();
}

var builder = WebApplication.CreateBuilder(args);

ConfigureServices(builder.Services, builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

AddEndpoints(app);

app.Run();
