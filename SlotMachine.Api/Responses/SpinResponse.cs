namespace SlotMachine.Api.Responses
{
    public class SpinResponse
    {
        public long Balance { get; set; }
        public long WinAmount { get; set; }
        public required int[][] SlotMachineMatrix { get; set; }
    }
}
