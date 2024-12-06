using SlotMachine.Domain.Interfaces;

namespace SlotMachine.Domain.Services
{
    public class SlotMachineWinCalculator : ISlotMachineWinCalculator
    {
        public int CalculateWin(byte[,] slotMachineMatrix)
        {
            if (slotMachineMatrix == null || slotMachineMatrix.GetLength(1) < Constants.MinWinningSeriesLength || slotMachineMatrix.GetLength(0) == 0)
            {
                return 0;
            }

            var winAmount = 0;
            var matrixHeight = slotMachineMatrix.GetLength(0);

            for (var y = 0; y < matrixHeight; y++)
            {
                winAmount += CalculateLineWin(slotMachineMatrix, y);

                winAmount += CalculateDiagonalWin(slotMachineMatrix, y, matrixHeight);
            }

            return winAmount;
        }

        static int CalculateLineWin(byte[,] matrix, int startCol)
        {
            byte firstValue = matrix[startCol, 0];
            var seriesLength = 1;

            for (var x = 1; x < matrix.GetLength(1); x++)
            {
                if (matrix[startCol, x] == firstValue)
                {
                    seriesLength++;
                }
                else break;
            }

            if (seriesLength < Constants.MinWinningSeriesLength)
            {
                return 0;
            }

            int winAmount = firstValue * seriesLength;

            return winAmount;
        }

        static int CalculateDiagonalWin(byte[,] matrix, int startCol, int matrixHeight)
        {
            if (matrixHeight < 2)
            {
                return 0;
            }

            byte firstValue = matrix[startCol, 0];
            var seriesLength = 1;

            int y = startCol, yIncrement = 1;
            for (var x = 1; x < matrix.GetLength(1); x++)
            {
                if (y >= (matrixHeight - 1) && yIncrement == 1)
                {
                    yIncrement = -1;
                }
                else if (y <= 0 && yIncrement == -1)
                {
                    yIncrement = 1;
                }

                y += yIncrement;

                if (matrix[y, x] == firstValue)
                {
                    seriesLength++;
                }
                else break;
            }

            if (seriesLength < Constants.MinWinningSeriesLength)
            {
                return 0;
            }

            int winAmount = firstValue * seriesLength;

            return winAmount;
        }
    }
}
