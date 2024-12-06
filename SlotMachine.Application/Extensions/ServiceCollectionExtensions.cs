using Microsoft.Extensions.DependencyInjection;
using SlotMachine.Application.Configuration;
using SlotMachine.Application.Interfaces;
using SlotMachine.Application.Services;
using SlotMachine.Domain.Interfaces;
using SlotMachine.Domain.Services;
using SlotMachine.Infrastructure.Database;
using SlotMachine.Infrastructure.Extensions;

namespace SlotMachine.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add slot machine services to dependency injection container
        /// </summary>
        public static void AddSlotMachineServices(this IServiceCollection services, DatabaseConfig config)
        {
            services.AddScoped<IPlayerService, PlayerService>();

            services.AddSingleton<ISlotMachineMatrixFactory, SlotMachineMatrixFactory>();
            services.AddSingleton<ISlotMachineWinCalculator, SlotMachineWinCalculator>();
            services.AddScoped<ISlotMachineService, SlotMachineService>();

            services.AddSlotMachineInfrastructureServices(new MongoDbConfig
            {
                ConnectionString = config.ConnectionString,
                DatabaseName = config.DatabaseName
            });
        }
    }
}
