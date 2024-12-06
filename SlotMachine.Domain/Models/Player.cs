namespace SlotMachine.Domain.Models
{
    public class Player
    {
        public Guid Id { get; set; }
        public long Balance { get; set; } = Constants.InitialPlayerBalance;
        public int MatrixWidth { get; set; } = Constants.DefaultMatrixWidth;
        public int MatrixHeight { get; set; } = Constants.DefaultMatrixHeight;
    }
}
