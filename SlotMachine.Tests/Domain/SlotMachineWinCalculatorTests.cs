using SlotMachine.Domain.Services;

namespace SlotMachine.Tests.Domain
{
    public class SlotMachineWinCalculatorTests
    {
        [Fact]
        public void CalculateWin_WhenMatrixIsEmpty_ReturnsZero()
        {
            // Arrange
            var calculator = new SlotMachineWinCalculator();

            // Act
            var result = calculator.CalculateWin(new byte[0, 0]);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateWin_WhenMatrixHasOneRow_ReturnsZero()
        {
            // Arrange
            var calculator = new SlotMachineWinCalculator();

            // Act
            var result = calculator.CalculateWin(new byte[1, 0]);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateWin_WhenMatrixHasOneColumn_ReturnsZero()
        {
            // Arrange
            var calculator = new SlotMachineWinCalculator();

            // Act
            var result = calculator.CalculateWin(new byte[0, 1]);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public void CalculateWin_WhenMatrixHasOneRowAndOneColumn_ReturnsZero()
        {
            // Arrange
            var calculator = new SlotMachineWinCalculator();

            // Act
            var result = calculator.CalculateWin(new byte[1, 1] { { 7 } });

            // Assert
            Assert.Equal(0, result);
        }

        public static IEnumerable<object?[]> GetSimpleQueryData()
        {
            yield return new object[] {
                    new byte[3, 1]
                    {
                        { 1 },
                        { 2 },
                        { 3 }
                    }, 0
                };

            yield return new object[] {
                    new byte[3, 5]
                    {
                        { 1, 2, 3, 3, 2 },
                        { 4, 5, 6, 3, 2 },
                        { 7, 8, 9, 3, 2 }
                    }, 0
                };

            yield return new object[] {
                    new byte[3, 3]
                    {
                        { 1, 1, 1 },
                        { 4, 5, 6 },
                        { 7, 8, 9 }
                    }, 3
                };

            yield return new object[] {
                    new byte[3, 5]
                    {
                        { 1, 1, 1, 2, 3 },
                        { 2, 2, 2, 2, 3 },
                        { 1, 1, 1, 2, 3 }
                    }, 14
                };

            yield return new object[] {
                    new byte[3, 5]
                    {
                        { 1, 1, 3, 2, 1 },
                        { 2, 1, 2, 1, 2 },
                        { 3, 2, 1, 2, 0 }
                    }, 15
                };

            yield return new object[] {
                    new byte[3, 5]
                    {
                        { 1, 1, 1, 1, 1 },
                        { 1, 1, 1, 1, 1 },
                        { 1, 1, 1, 1, 1 }
                    }, 30
                };

            yield return new object[] {
                    new byte[3, 5]
                    {
                        { 1, 0, 1, 0, 0 },
                        { 0, 1, 0, 1, 0 },
                        { 1, 0, 1, 0, 0 }
                    }, 8
                };

            yield return new object[] {
                    new byte[3, 5]
                    {
                        { 1, 1, 1, 0, 0 },
                        { 0, 1, 0, 1, 0 },
                        { 1, 0, 1, 0, 0 }
                    }, 11
                };
            yield return new object[] {
                    new byte[2, 5]
                    {
                        { 1, 1, 1, 9, 9 },
                        { 9, 1, 9, 1, 9 }
                    }, 7
                };
        }
        [Theory]
        [MemberData(nameof(GetSimpleQueryData), MemberType = typeof(SlotMachineWinCalculatorTests))]
        public void CalculateWin_ReturnsCorrectResult(byte[,] matrix, int expected)
        {
            // Arrange
            var calculator = new SlotMachineWinCalculator();

            // Act
            var result = calculator.CalculateWin(matrix);

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
