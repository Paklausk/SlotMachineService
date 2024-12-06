using SlotMachine.Application.Models;

namespace SlotMachine.Application.Interfaces
{
    public interface ISlotMachineService
    {
        /// <summary>
        /// Spin the slot machine and return the result
        /// </summary>
        public SpinResult Spin(int matrixWidth, int matrixHeight);
    }
}
