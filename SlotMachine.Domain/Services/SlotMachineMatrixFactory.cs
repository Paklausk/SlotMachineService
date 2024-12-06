using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Domain.Services
{
    public class SlotMachineMatrixFactory : ISlotMachineMatrixFactory
    {
        public byte[,] CreateMatrixPopulatedWithRandomNumbers(int matrixWidth, int matrixHeight)
        {
            if (matrixWidth < 1 || matrixHeight < 1)
            {
                throw new ArgumentException("Matrix width and height must be greater than 0");
            }

            var random = new Random();
            var matrix = new byte[matrixHeight, matrixWidth];
            for (var y = 0; y < matrixHeight; y++)
            {
                for (var x = 0; x < matrixWidth; x++)
                {
                    matrix[y, x] = (byte)random.Next(Constants.MinMatrixNumber, Constants.MaxMatrixNumber);
                }
            }
            return matrix;
        }
    }
}
