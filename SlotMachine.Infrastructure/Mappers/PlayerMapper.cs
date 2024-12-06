using SlotMachine.Domain.Models;
using SlotMachine.Infrastructure.Entities;

namespace SlotMachine.Infrastructure.Mappers
{
    internal static class PlayerMapper
    {
        public static Player? ToModel(this PlayerEntity? entity) =>
            entity == null ? null :
            new Player()
            {
                Id = entity.Id,
                Balance = entity.Balance,
                MatrixWidth = entity.MatrixWidth,
                MatrixHeight = entity.MatrixHeight
            };

        public static PlayerEntity? ToEntity(this Player? model) =>
            model == null ? null :
            new PlayerEntity()
            {
                Id = model.Id,
                Balance = model.Balance,
                MatrixWidth = model.MatrixWidth,
                MatrixHeight = model.MatrixHeight
            };
    }
}
