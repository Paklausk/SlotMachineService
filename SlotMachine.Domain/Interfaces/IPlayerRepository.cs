using SlotMachine.Domain.Models;

namespace SlotMachine.Domain.Interfaces
{
    public interface IPlayerRepository
    {
        /// <summary>
        /// Get player by id. If player does not exist, return null.
        /// </summary>
        Task<Player?> GetAsync(Guid id);

        /// <summary>
        /// Create a new player. If player is null, throw ArgumentNullException.
        /// </summary>
        Task<Player> CreateAsync(Player player);

        /// <summary>
        /// Update player balance by id. If player does not exist, return null.
        /// </summary>
        Task<Player?> UpdateBalanceAsync(Guid id, long balanceChange);

        /// <summary>
        /// Update player matrix by id. If player does not exist, return null.
        /// </summary>
        Task<Player?> UpdateMatrixSizeAsync(Guid id, int matrixWidth, int matrixHeight);
    }
}
