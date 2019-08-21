namespace EHale.Wordsearch.Entities
{
    internal class SearchPoint
    {
        internal SearchPoint(int x, int y, char character)
        {
            X = x;
            Y = y;
            Character = character;
        }

        public Direction? Direction { get; set; }
        public char Character { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
