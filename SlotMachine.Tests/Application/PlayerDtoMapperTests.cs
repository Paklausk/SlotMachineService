using SlotMachine.Application.Dtos;
using SlotMachine.Application.Mappers;
using SlotMachine.Domain.Models;

namespace SlotMachine.Tests.Application
{
    public class PlayerDtoMapperTests
    {
        [Fact]
        public void ToDto_PlayerIsNull_ReturnsNull()
        {
            // Arrange
            Player? player = null;

            // Act
            var result = player.ToDto();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToDto_PlayerIsNotNull_ReturnsPlayerDto()
        {
            // Arrange
            var player = new Player
            {
                Id = Guid.NewGuid(),
                Balance = 100,
                MatrixWidth = 3,
                MatrixHeight = 3,
            };

            // Act
            var result = player.ToDto();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(player.Id, result.Id);
            Assert.Equal(player.Balance, result.Balance);
            Assert.Equal(player.MatrixWidth, result.MatrixWidth);
            Assert.Equal(player.MatrixHeight, result.MatrixHeight);
        }

        [Fact]
        public void ToModel_PlayerDtoIsNull_ReturnsNull()
        {
            // Arrange
            PlayerDto? playerDto = null;

            // Act
            var result = playerDto.ToModel();

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void ToModel_PlayerDtoIsNotNull_ReturnsPlayer()
        {
            // Arrange
            var playerDto = new PlayerDto
            {
                Id = Guid.NewGuid(),
                Balance = 100,
                MatrixWidth = 3,
                MatrixHeight = 3,
            };

            // Act
            var result = playerDto.ToModel();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(playerDto.Id, result.Id);
            Assert.Equal(playerDto.Balance, result.Balance);
            Assert.Equal(playerDto.MatrixWidth, result.MatrixWidth);
            Assert.Equal(playerDto.MatrixHeight, result.MatrixHeight);
        }
    }
}
