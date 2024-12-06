namespace SlotMachine.Domain.Interfaces
{
    public interface ISlotMachineWinCalculator
    {
        int CalculateWin(byte[,] slotMachineMatrix);
    }
}