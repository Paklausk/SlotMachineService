namespace SlotMachine.Api.Extensions
{
    public static class ByteArrayExtensions
    {
        public static int[][] ToJaggedIntArray(this byte[,] multidimentionalArray)
        {
            var rows = multidimentionalArray.GetLength(0);
            var cols = multidimentionalArray.GetLength(1);
            var jaggedArray = new int[rows][];
            for (var i = 0; i < rows; i++)
            {
                jaggedArray[i] = new int[cols];
                for (var j = 0; j < cols; j++)
                {
                    jaggedArray[i][j] = multidimentionalArray[i, j];
                }
            }
            return jaggedArray;
        }
    }
}
