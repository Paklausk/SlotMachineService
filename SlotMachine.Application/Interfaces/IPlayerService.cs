using SlotMachine.Application.Dtos;
using SlotMachine.Domain;

namespace SlotMachine.Application.Interfaces
{
    public interface IPlayerService
    {
        /// <summary>
        /// Get player by id. If player does not exist, return null.
        /// </summary>
        Task<PlayerDto?> GetAsync(Guid playerId);

        /// <summary>
        /// Create a new player with a default balance.
        /// </summary>
        Task<PlayerDto> CreateAsync(int matrixWidth, int matrixHeight, long initialBalance = Constants.InitialPlayerBalance);

        /// <summary>
        /// Update player balance by id. If player does not exist, return null.
        /// </summary>
        Task<PlayerDto?> UpdateBalanceAsync(Guid playerId, long balanceChange);

        /// <summary>
        /// Update player matrix size by id. If player does not exist, return null.
        /// </summary>
        Task<PlayerDto?> UpdateMatrixSizeAsync(Guid playerId, int matrixWidth, int matrixHeight);
    }
}
