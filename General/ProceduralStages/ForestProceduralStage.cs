using BonusHomeworkPatternShonhodoevBayan972102.Contract;
using BonusHomeworkPatternShonhodoevBayan972102.Contract.Strategies.Element;
using BonusHomeworkPatternShonhodoevBayan972102.General.Factories.Element;
using BonusHomeworkPatternShonhodoevBayan972102.General.Strategies.Element;
using BonusHomeworkPatternShonhodoevBayan972102.Models;
using BonusHomeworkPatternShonhodoevBayan972102.Models.Enums;

namespace BonusHomeworkPatternShonhodoevBayan972102.General.Iterators.ProceduralStage
{
    public class ForestProceduralStage : IProceduralStage
    {
        public Map ExecuteProcedure(Map map)
        {
            Random rand = new(map.Cfg.Seed);

            int maxTreesHeight = 12;
            int minTreesHeight = 4;
            int numTrees = 2;
            int minDistance = 1;

            int currentY = map.Cfg.EarthHeight;
            int currentForestHeight = rand.Next(minTreesHeight, maxTreesHeight);

            int forestWidth = map.Cfg.Width / map.Cfg.Biomes.Count;
            int forestStart = forestWidth * map.Cfg.Biomes.IndexOf(BiomeType.Forest);
            int forestEnd = forestWidth * (map.Cfg.Biomes.IndexOf(BiomeType.Forest) + 1);

            for (int y = 0; y < map.Cfg.Height; y++)
            {
                if (map.Blocks[y, forestWidth * map.Cfg.Biomes.IndexOf(BiomeType.Forest)].Index == 10)
                {
                    currentY = y;
                    break;
                }
            }

            List<(int, int)> positionsOfTrees = new List<(int, int)>();

            for (int i = 0; i < numTrees; i++)
            {
                int x, y;
                bool validPosition;

                do
                {
                    validPosition = true;
                    x = rand.Next(forestStart, forestEnd + 1);

                    foreach ((int cx, int cy) in positionsOfTrees)
                    {
                        double distance = Math.Abs(x - cx);

                        if (distance < minDistance)
                        {
                            validPosition = false;
                            break;
                        }
                    }
                } while (!validPosition);

                positionsOfTrees.Add((x, map.Cfg.EarthHeight));
            }

            ICreateElementStrategy createElementStrategy = CreateElementStrategyFactory.GetCreateElementStrategy(ElementStrategyType.TreeType);

            int currentGrassY = 0;
            for (int x = 0; x < map.Cfg.Width; x++)
            {
                if (map.Blocks[0, x].BiomeType != BiomeType.Forest)
                    continue;

                bool isFoundGrass = false;
                for (int y = 0; (y < map.Cfg.Height); y++)
                {
                    if (map.Blocks[y, x].Index == 10)
                    {
                        isFoundGrass = true;
                        currentGrassY = y;
                    }

                    if (isFoundGrass)
                    {
                        if (positionsOfTrees.FindIndex(cactus => cactus.Item1 == x) != -1)
                        {
                            createElementStrategy.ThisElementParams = new TreeParams(x, currentGrassY - 1, maxTreesHeight, minTreesHeight);

                            createElementStrategy.CreateElement(ref map);
                        }
                    }
                }
            }

            return map;
        }
    }
}
