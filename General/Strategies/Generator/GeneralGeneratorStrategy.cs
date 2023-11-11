using BonusHomeworkPatternShonhodoevBayan972102.Contract.Strategies.Generator;
using BonusHomeworkPatternShonhodoevBayan972102.General.Iterators.ProceduralStage;
using BonusHomeworkPatternShonhodoevBayan972102.Models;
using BonusHomeworkPatternShonhodoevBayan972102.Models.Enums;

namespace BonusHomeworkPatternShonhodoevBayan972102.General.Strategies.Generator
{
    public class GeneralGeneratorStrategy : IGeneratorStrategy
    {
        public void Execute(ref Map map)
        {
            GeneralProceduralStagesIterator stages = new();

            map.Cfg.Biomes = new List<BiomeType>() { BiomeType.Forest, BiomeType.Desert, BiomeType.Mountain, BiomeType.Ocean, BiomeType.Jungle };

            foreach(var stage in stages)
            {
                map = stage.ExecuteProcedure(map);
            }
        }
    }
}
