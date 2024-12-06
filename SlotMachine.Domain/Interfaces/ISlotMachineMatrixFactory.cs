namespace SlotMachine.Domain.Interfaces
{
    public interface ISlotMachineMatrixFactory
    {
        byte[,] CreateMatrixPopulatedWithRandomNumbers(int matrixWidth, int matrixHeight);
    }
}