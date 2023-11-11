using BonusHomeworkPatternShonhodoevBayan972102.Contract;
using BonusHomeworkPatternShonhodoevBayan972102.Contract.Strategies.Element;
using BonusHomeworkPatternShonhodoevBayan972102.Models;

namespace BonusHomeworkPatternShonhodoevBayan972102.General.Strategies.Element
{
    public class CreateCactusStrategy : ICreateElementStrategy
    {
        public ElementParams ThisElementParams { get; set; }

        public void CreateElement(ref Map map)
        {
            if (ThisElementParams.Y < 0 || ThisElementParams.X >= map.Cfg.Width)
            {
                throw new Exception("Cannot create Element.");
            }

            map.Blocks[ThisElementParams.Y, ThisElementParams.X + 1].Index = 70; // Блок кактуса
            map.Blocks[ThisElementParams.Y - 1, ThisElementParams.X + 1].Index = 70; // Блок кактуса
            map.Blocks[ThisElementParams.Y - 2, ThisElementParams.X + 1].Index = 70; // Блок кактуса
            map.Blocks[ThisElementParams.Y - 2, ThisElementParams.X + 0].Index = 70; // Блок кактуса
            map.Blocks[ThisElementParams.Y - 3, ThisElementParams.X + 0].Index = 70; // Блок кактуса
            map.Blocks[ThisElementParams.Y - 4, ThisElementParams.X + 0].Index = 70; // Блок кактуса
            map.Blocks[ThisElementParams.Y - 2, ThisElementParams.X + 2].Index = 70; // Блок кактуса
            map.Blocks[ThisElementParams.Y - 3, ThisElementParams.X + 2].Index = 70; // Блок кактуса
        }
    }
}
