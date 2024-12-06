namespace SlotMachine.Application.Dtos
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public long Balance { get; set; }
        public int MatrixWidth { get; set; }
        public int MatrixHeight { get; set; }
    }
}
