using BonusHomeworkPatternShonhodoevBayan972102.Contract;
using BonusHomeworkPatternShonhodoevBayan972102.Contract.Strategies.Element;
using BonusHomeworkPatternShonhodoevBayan972102.General.Factories.Element;
using BonusHomeworkPatternShonhodoevBayan972102.Models;
using BonusHomeworkPatternShonhodoevBayan972102.Models.Enums;

namespace BonusHomeworkPatternShonhodoevBayan972102.General.Iterators.ProceduralStage
{
    public class DesertProceduralStage : IProceduralStage
    {
        public Map ExecuteProcedure(Map map)
        {
            Random rand = new(map.Cfg.Seed);

            int maxSandDeep = rand.Next(4, 7);
            int minSandDeep = rand.Next(2, 4);
            int numCactuses = 2;
            int minDistance = 5;

            int currentY = map.Cfg.EarthHeight;
            int currentSandDeep = rand.Next(minSandDeep, maxSandDeep);

            int desertWidth = map.Cfg.Width / map.Cfg.Biomes.Count;
            int desertStart = desertWidth * map.Cfg.Biomes.IndexOf(BiomeType.Desert);
            int desertEnd = desertWidth * (map.Cfg.Biomes.IndexOf(BiomeType.Desert) + 1);

            for (int y = 0; y < map.Cfg.Height; y++)
            {
                if (map.Blocks[y, desertWidth * map.Cfg.Biomes.IndexOf(BiomeType.Desert)].Index == 10)
                {
                    currentY = y;
                    break;
                }
            }

            List<(int, int)> positionsOfCactuses = new List<(int, int)>();

            for (int i = 0; i < numCactuses; i++)
            {
                int x, y;
                bool validPosition;

                do
                {
                    validPosition = true;
                    x = rand.Next(desertStart, desertEnd + 1);

                    foreach ((int cx, int cy) in positionsOfCactuses)
                    {
                        double distance = Math.Abs(x - cx);

                        if (distance < minDistance)
                        {
                            validPosition = false;
                            break;
                        }
                    }
                } while (!validPosition);

                positionsOfCactuses.Add((x, map.Cfg.EarthHeight));
            }

            ICreateElementStrategy createElementStrategy = CreateElementStrategyFactory.GetCreateElementStrategy(ElementStrategyType.CactusType);

            for (int x = 0; x < map.Cfg.Width; x++)
            {
                if (map.Blocks[0, x].BiomeType != BiomeType.Desert)
                    continue;

                int NumberOfPlacedSandBlocked = 0;
                bool isFoundGrass = false;
                for (int y = 0; (y < map.Cfg.Height) && (NumberOfPlacedSandBlocked < currentSandDeep); y++)
                {
                    if (map.Blocks[y, x].Index == 10)
                    {
                        isFoundGrass = true;
                    }

                    if (isFoundGrass)
                    {
                        if (NumberOfPlacedSandBlocked == 0 && positionsOfCactuses.FindIndex(cactus => cactus.Item1 == x) != -1)
                        {
                            createElementStrategy.ThisElementParams = new CactusParams(x, y - 1);

                            createElementStrategy.CreateElement(ref map);
                        }

                        if (NumberOfPlacedSandBlocked < currentSandDeep)
                        {
                            map.Blocks[y, x].Index = 60; // Блок песка
                            map.Backgrounds[y, x].Index = 0; // Стена пустоты
                            NumberOfPlacedSandBlocked++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                int yNextStep = rand.Next(1, 3) == 1 ? -1 : 1;

                if (currentSandDeep + yNextStep <= maxSandDeep && currentSandDeep + yNextStep >= minSandDeep)
                {
                    currentSandDeep += yNextStep;
                }
                else
                {
                    currentSandDeep -= yNextStep;
                }
            }

            return map;
        }
    }
}
