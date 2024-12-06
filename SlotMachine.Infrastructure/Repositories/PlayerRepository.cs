using MongoDB.Driver;
using SlotMachine.Domain.Interfaces;
using SlotMachine.Domain.Models;
using SlotMachine.Infrastructure.Database;
using SlotMachine.Infrastructure.Entities;
using SlotMachine.Infrastructure.Mappers;

namespace SlotMachine.Infrastructure.Repositories
{
    internal class PlayerRepository(IMongoClient mongoClient, MongoDbConfig config) : IPlayerRepository
    {
        const string CollectionName = "players";

        public async Task<Player?> GetAsync(Guid id)
        {
            var filter = Builders<PlayerEntity>.Filter.Eq(p => p.Id, id);
            var player = await GetCollection().Find(filter).FirstOrDefaultAsync();

            return player.ToModel();
        }

        public async Task<Player> CreateAsync(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }
            var playerEntity = player.ToEntity()!;

            if (playerEntity.Id == default)
            {
                playerEntity.Id = Guid.NewGuid();
            }

            await GetCollection().InsertOneAsync(playerEntity);

            return playerEntity.ToModel()!;
        }

        public async Task<Player?> UpdateBalanceAsync(Guid id, long balanceChange)
        {
            var filter = Builders<PlayerEntity>.Filter.Eq(p => p.Id, id);
            var update = Builders<PlayerEntity>.Update
                .Inc(nameof(PlayerEntity.Balance), balanceChange);

            var options = new FindOneAndUpdateOptions<PlayerEntity>
            {
                ReturnDocument = ReturnDocument.After
            };

            var updatedPlayer = await GetCollection().FindOneAndUpdateAsync(filter, update, options);

            return updatedPlayer.ToModel();
        }

        public async Task<Player?> UpdateMatrixSizeAsync(Guid id, int matrixWidth, int matrixHeight)
        {
            var filter = Builders<PlayerEntity>.Filter.Eq(p => p.Id, id);
            var update = Builders<PlayerEntity>.Update
                .Set(nameof(PlayerEntity.MatrixWidth), matrixWidth)
                .Set(nameof(PlayerEntity.MatrixHeight), matrixHeight);

            var options = new FindOneAndUpdateOptions<PlayerEntity>
            {
                ReturnDocument = ReturnDocument.After,
            };

            var updatedPlayer = await GetCollection().FindOneAndUpdateAsync(filter, update, options);

            return updatedPlayer.ToModel();
        }

        internal IMongoCollection<PlayerEntity> GetCollection() =>
            mongoClient.GetDatabase(config.DatabaseName).GetCollection<PlayerEntity>(CollectionName);
    }
}
