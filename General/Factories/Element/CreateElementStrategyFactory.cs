using BonusHomeworkPatternShonhodoevBayan972102.Contract.Strategies.Element;
using BonusHomeworkPatternShonhodoevBayan972102.General.Strategies.Element;
using BonusHomeworkPatternShonhodoevBayan972102.Models.Enums;

namespace BonusHomeworkPatternShonhodoevBayan972102.General.Factories.Element
{
    public static class CreateElementStrategyFactory
    {
        public static ICreateElementStrategy GetCreateElementStrategy(ElementStrategyType type)
        {
            switch (type)
            {
                case (ElementStrategyType.CactusType):
                    return new CreateCactusStrategy();
                case (ElementStrategyType.TreeType):
                    return new CreateTreeStrategy();
                default:
                    return new CreateCactusStrategy();
            }
        }
    }
}
