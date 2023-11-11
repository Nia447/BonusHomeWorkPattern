using BonusHomeworkPatternShonhodoevBayan972102.Contract.Strategies.Generator;
using BonusHomeworkPatternShonhodoevBayan972102.General.Factories.Generator;
using BonusHomeworkPatternShonhodoevBayan972102.Models;
using BonusHomeworkPatternShonhodoevBayan972102.Models.Enums;

namespace BonusHomeworkPatternShonhodoevBayan972102.General
{
    public class Generator
    {
        private readonly MapConfiguration _cfg;
        
        public Generator(MapConfiguration cfg)
        {
            _cfg = cfg;
        }

        public Map Generate()
        {
            Map map = new(_cfg);

            IGeneratorStrategy generatorStrategy = GeneratorStrategyFactory.GetGeneratorStrategy(GeneratorStrategyType.NormalModeGenerator);

            generatorStrategy.Execute(ref map);

            return map;
        }
    }
}
