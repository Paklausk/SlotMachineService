using SlotMachine.Application.Dtos;
using SlotMachine.Domain.Models;

namespace SlotMachine.Application.Mappers
{
    public static class PlayerDtoMapper
    {
        public static PlayerDto? ToDto(this Player? player) =>
            player == null ? null : new PlayerDto
            {
                Id = player.Id,
                Balance = player.Balance,
                MatrixWidth = player.MatrixWidth,
                MatrixHeight = player.MatrixHeight,
            };

        public static Player? ToModel(this PlayerDto? playerDto) =>
            playerDto == null ? null : new Player
            {
                Id = playerDto.Id,
                Balance = playerDto.Balance,
                MatrixWidth = playerDto.MatrixWidth,
                MatrixHeight = playerDto.MatrixHeight,
            };
    }
}
