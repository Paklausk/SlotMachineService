using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using SlotMachine.Domain.Interfaces;
using SlotMachine.Infrastructure.Database;
using SlotMachine.Infrastructure.Repositories;

namespace SlotMachine.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Add slot machine infrastructure services to dependency injection container
        /// </summary>
        public static void AddSlotMachineInfrastructureServices(this IServiceCollection services, MongoDbConfig mongoDbConfig)
        {
            services.AddSingleton(mongoDbConfig);
            services.AddSingleton<IMongoClient>(_ => new MongoClient(mongoDbConfig.ConnectionString));
            services.AddScoped<IPlayerRepository, PlayerRepository>();
        }
    }
}
