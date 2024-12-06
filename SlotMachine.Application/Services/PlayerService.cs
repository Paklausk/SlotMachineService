using SlotMachine.Application.Dtos;
using SlotMachine.Application.Interfaces;
using SlotMachine.Application.Mappers;
using SlotMachine.Domain.Interfaces;
using SlotMachine.Domain.Models;

namespace SlotMachine.Application.Services
{
    public class PlayerService(IPlayerRepository playerRepository) : IPlayerService
    {
        public async Task<PlayerDto> CreateAsync(int matrixWidth, int matrixHeight, long initialBalance)
        {
            var player = new Player()
            {
                Balance = initialBalance,
                MatrixWidth = matrixWidth,
                MatrixHeight = matrixHeight
            };
            var createdPlayer = await playerRepository.CreateAsync(player);
            return createdPlayer.ToDto()!;
        }

        public async Task<PlayerDto?> GetAsync(Guid playerId)
        {
            var player = await playerRepository.GetAsync(playerId);
            if (player == null)
            {
                return null;
            }

            return player.ToDto();
        }

        public async Task<PlayerDto?> UpdateBalanceAsync(Guid playerId, long balanceChange)
        {
            var player = await playerRepository.UpdateBalanceAsync(playerId, balanceChange);

            return player.ToDto();
        }

        public async Task<PlayerDto?> UpdateMatrixSizeAsync(Guid playerId, int matrixWidth, int matrixHeight)
        {
            var player = await playerRepository.UpdateMatrixSizeAsync(playerId, matrixWidth, matrixHeight);

            return player.ToDto();
        }
    }
}
