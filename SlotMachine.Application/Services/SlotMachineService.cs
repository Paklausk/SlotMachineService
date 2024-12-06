using SlotMachine.Application.Interfaces;
using SlotMachine.Application.Models;
using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Application.Services
{
    public class SlotMachineService(
        ISlotMachineMatrixFactory matrixFactory,
        ISlotMachineWinCalculator winCalculator
    ) : ISlotMachineService
    {
        public SpinResult Spin(int matrixWidth, int matrixHeight)
        {
            var matrix = matrixFactory.CreateMatrixPopulatedWithRandomNumbers(matrixWidth, matrixHeight);

            return new SpinResult
            {
                SlotMachineMatrix = matrix,
                WinMultiplier = winCalculator.CalculateWin(matrix)
            };
        }
    }
}
