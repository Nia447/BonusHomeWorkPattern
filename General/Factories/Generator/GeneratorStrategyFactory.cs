using BonusHomeworkPatternShonhodoevBayan972102.Contract.Strategies.Generator;
using BonusHomeworkPatternShonhodoevBayan972102.General.Strategies.Generator;
using BonusHomeworkPatternShonhodoevBayan972102.Models.Enums;

namespace BonusHomeworkPatternShonhodoevBayan972102.General.Factories.Generator
{
    public static class GeneratorStrategyFactory
    {
        public static IGeneratorStrategy GetGeneratorStrategy(GeneratorStrategyType type)
        {
            switch(type)
            {
                case(GeneratorStrategyType.NormalModeGenerator):
                    return new NormalModeGeneratorStrategy();
                default:
                    return new NormalModeGeneratorStrategy();
            }
        }
    }
}
