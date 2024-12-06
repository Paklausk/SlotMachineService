namespace SlotMachine.Application.Models
{
    public class SpinResult
    {
        public int WinMultiplier { get; set; } = 0;
        public required byte[,] SlotMachineMatrix { get; set; }
    }
}
