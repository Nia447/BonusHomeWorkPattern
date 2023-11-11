using BonusHomeworkPatternShonhodoevBayan972102.Contract;
using BonusHomeworkPatternShonhodoevBayan972102.Contract.Strategies.Element;
using BonusHomeworkPatternShonhodoevBayan972102.Models;

namespace BonusHomeworkPatternShonhodoevBayan972102.General.Strategies.Element
{
    public class CreateTreeStrategy : ICreateElementStrategy
    {
        public ElementParams ThisElementParams { get; set; }

        public void CreateElement(ref Map map)
        {
            if (ThisElementParams.Y < 0 || ThisElementParams.X >= map.Cfg.Width)
            {
                throw new Exception("Cannot create Element.");
            }

            int currentHeight = new Random(map.Cfg.Seed).Next(((TreeParams)ThisElementParams).MinTreeHeight, ((TreeParams)ThisElementParams).MaxTreeHeight);

            for (int y = ThisElementParams.Y; Math.Abs(y - ThisElementParams.Y) < currentHeight; y--)
            {
                map.Blocks[y, ThisElementParams.X].Index = 130; // Блок дерева
                if (Math.Abs(ThisElementParams.Y - y) > 3)
                {
                    map.Blocks[y - 1, ThisElementParams.X + 1].Index = 140; // Блок листьев
                    map.Blocks[y - 1, ThisElementParams.X - 1].Index = 140; // Блок листьев
                }
                if (Math.Abs(ThisElementParams.Y - y) == currentHeight - 1)
                {
                    map.Blocks[y - 1, ThisElementParams.X].Index = 140; // Блок листьев
                }
            }
        }
    }
}
