using BonusHomeworkPatternShonhodoevBayan972102.Contract;
using BonusHomeworkPatternShonhodoevBayan972102.Models;
using BonusHomeworkPatternShonhodoevBayan972102.Models.Enums;

namespace BonusHomeworkPatternShonhodoevBayan972102.General.Iterators.ProceduralStage
{
    public class MountainProceduralStage : IProceduralStage
    {
        public Map ExecuteProcedure(Map map)
        {
            Random rand = new(map.Cfg.Seed);

            int mountainDeep = map.Cfg.EarthHeight - (int)Math.Round(0.3 * map.Cfg.Height);
            int mountainWidth = map.Cfg.Width / map.Cfg.Biomes.Count;
            int mountainOffset = rand.Next(0, 3);
            int maxSnowDeep = rand.Next(4, 7);
            int minSnowDeep = rand.Next(2, 4);

            bool isInStartMountain = map.Blocks[0, 0].BiomeType == BiomeType.Mountain;

            int currentY = map.Cfg.EarthHeight;
            int currentSnowDeep = rand.Next(minSnowDeep, maxSnowDeep);

            if (isInStartMountain)
            {
                for (int y = 0; y < map.Cfg.Height; y++)
                {
                    if (map.Blocks[y, mountainWidth].Index == 10)
                    {
                        currentY = y;
                        break;
                    }
                }
            }
            else
            {
                for (int y = 0; y < map.Cfg.Height; y++)
                {
                    if (map.Blocks[y, mountainWidth * (map.Cfg.Biomes.Count - 1)].Index == 10)
                    {
                        currentY = y;
                        break;
                    }
                }
            }

            for (int x = 0; x < map.Cfg.Width; x++)
            {
                if (map.Blocks[0, x].BiomeType != BiomeType.Mountain)
                    continue;

                if (isInStartMountain)
                {
                    int NumberOfPlacedSnowBlocked = 0;
                    for (int y = currentY - MathFunction(x, mountainDeep, mountainWidth, mountainOffset); (y < map.Cfg.Height) && (NumberOfPlacedSnowBlocked < currentSnowDeep || map.Blocks[y, x].Index != 20); y++)
                    {
                        if (NumberOfPlacedSnowBlocked < currentSnowDeep)
                        {
                            map.Blocks[y, x].Index = 50; // Блок снега
                            map.Backgrounds[y, x].Index = 0; // Стена пустоты
                            NumberOfPlacedSnowBlocked++;
                        }
                        else
                        {
                            map.Blocks[y, x].Index = 20; // Блок земли
                            map.Backgrounds[y, x].Index = 20; // Стена пустоты
                        }
                    }

                    int ySnowNextStep = rand.Next(1, 3) == 1 ? -1 : 1;

                    if (currentSnowDeep + ySnowNextStep <= maxSnowDeep && currentSnowDeep + ySnowNextStep >= minSnowDeep)
                    {
                        currentSnowDeep += ySnowNextStep;
                    }
                    else
                    {
                        currentSnowDeep -= ySnowNextStep;
                    }
                }
                else
                {
                    int NumberOfPlacedSnowBlocked = 0;
                    for (int y = currentY - MathFunction(mountainWidth - (x - mountainWidth * (map.Cfg.Biomes.Count - 1)), mountainDeep, mountainWidth, mountainOffset); (y < map.Cfg.Height) && (NumberOfPlacedSnowBlocked < currentSnowDeep || map.Blocks[y, x].Index != 20); y++)
                    {
                        if (NumberOfPlacedSnowBlocked < currentSnowDeep)
                        {
                            map.Blocks[y, x].Index = 50; // Блок снега
                            map.Backgrounds[y, x].Index = 0; // Стена пустоты
                            NumberOfPlacedSnowBlocked++;
                        }
                        else
                        {
                            map.Blocks[y, x].Index = 20; // Блок земли
                            map.Backgrounds[y, x].Index = 20; // Стена земли
                        }
                    }

                    int ySnowNextStep = rand.Next(1, 3) == 1 ? -1 : 1;

                    if (currentSnowDeep + ySnowNextStep <= maxSnowDeep && currentSnowDeep + ySnowNextStep >= minSnowDeep)
                    {
                        currentSnowDeep += ySnowNextStep;
                    }
                    else
                    {
                        currentSnowDeep -= ySnowNextStep;
                    }
                }
            }

            return map;
        }

        private static int MathFunction(int x, int h, int w, int o)
        {
            // y = (- h/((w - o)^2))*(x - o)^2+h. Перевернутая параболла с переменными h и w, где при x = 0 будет y = h и где при y = 0 будет x = w, но также со смещением по x из-за offset.

            double resultDouble = -(double)h / ((double)(w - o) * (double)(w - o)) * (double)(x - o) * (double)(x - o) + (double)h;

            return (int)Math.Floor(resultDouble);
        }
    }
}
