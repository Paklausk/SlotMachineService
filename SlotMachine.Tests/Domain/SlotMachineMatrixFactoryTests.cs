using SlotMachine.Domain;
using SlotMachine.Domain.Services;

namespace SlotMachine.Tests.Domain
{
    public class SlotMachineMatrixFactoryTests
    {
        [Fact]
        public void CreateMatrixPopulatedWithRandomNumbers_WhenMatrixWidthIsLessThan1_ThrowsArgumentException()
        {
            // Arrange
            var factory = new SlotMachineMatrixFactory();
            var matrixWidth = 0;
            var matrixHeight = 1;

            // Act, Assert
            Assert.Throws<ArgumentException>(() => factory.CreateMatrixPopulatedWithRandomNumbers(matrixWidth, matrixHeight));
        }

        [Fact]
        public void CreateMatrixPopulatedWithRandomNumbers_WhenMatrixHeightIsLessThan1_ThrowsArgumentException()
        {
            // Arrange
            var factory = new SlotMachineMatrixFactory();
            var matrixWidth = 1;
            var matrixHeight = 0;

            // Act, Assert
            Assert.Throws<ArgumentException>(() => factory.CreateMatrixPopulatedWithRandomNumbers(matrixWidth, matrixHeight));
        }

        [Fact]
        public void CreateMatrixPopulatedWithRandomNumbers_WhenMatrixWidthAndMatrixHeightAreGreaterThan0_ReturnsMatrixWithSpecifiedDimensions()
        {
            // Arrange
            var factory = new SlotMachineMatrixFactory();
            var matrixWidth = 3;
            var matrixHeight = 5;

            // Act
            var matrix = factory.CreateMatrixPopulatedWithRandomNumbers(matrixWidth, matrixHeight);

            // Assert
            Assert.Equal(matrixHeight, matrix.GetLength(0));
            Assert.Equal(matrixWidth, matrix.GetLength(1));
        }

        [Fact]
        public void CreateMatrixPopulatedWithRandomNumbers_WhenMatrixWidthAndMatrixHeightAreGreaterThan0_ReturnsMatrixWithRandomNumbers()
        {
            // Arrange
            var factory = new SlotMachineMatrixFactory();
            var matrixWidth = 3;
            var matrixHeight = 5;

            // Act
            var matrix = factory.CreateMatrixPopulatedWithRandomNumbers(matrixWidth, matrixHeight);

            // Assert
            var flatMatrix = matrix.Cast<byte>();
            Assert.All(flatMatrix, n => Assert.InRange(n, Constants.MinMatrixNumber, Constants.MaxMatrixNumber));
        }

        [Fact]
        public void CreateMatrixPopulatedWithRandomNumbers_WhenMatrixWidthAndMatrixHeightAreGreaterThan0_ReturnsMatrixWithDifferentNumbers()
        {
            // Arrange
            var factory = new SlotMachineMatrixFactory();
            var matrixWidth = 10;
            var matrixHeight = 10;

            // Act
            var matrix = factory.CreateMatrixPopulatedWithRandomNumbers(matrixWidth, matrixHeight);

            // Assert
            var flatMatrix = matrix.Cast<byte>();
            Assert.NotEqual(1, flatMatrix.Distinct().Count());
        }
    }
}
