namespace BonusHomeworkPatternShonhodoevBayan972102.Contract
{
    public abstract class ElementParams
    {
        public int X { get; set; }
        public int Y { get; set; }

        public ElementParams(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
