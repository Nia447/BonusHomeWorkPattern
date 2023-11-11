using BonusHomeworkPatternShonhodoevBayan972102.Contract;

namespace BonusHomeworkPatternShonhodoevBayan972102.Models
{
    public class TreeParams : ElementParams
    {
        public int MaxTreeHeight { get; set; }
        public int MinTreeHeight { get; set; }

        public TreeParams(int x, int y, int maxTreeHeight, int minTreeHeight) : base(x, y)
        {
            MaxTreeHeight = maxTreeHeight;
            MinTreeHeight = minTreeHeight;
        }
    }
}
