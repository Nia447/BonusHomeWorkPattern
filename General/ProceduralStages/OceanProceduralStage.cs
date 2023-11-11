using BonusHomeworkPatternShonhodoevBayan972102.Contract;
using BonusHomeworkPatternShonhodoevBayan972102.Models;
using BonusHomeworkPatternShonhodoevBayan972102.Models.Enums;

namespace BonusHomeworkPatternShonhodoevBayan972102.General.Iterators.ProceduralStage
{
    public class OceanProceduralStage : IProceduralStage
    {
        public Map ExecuteProcedure(Map map)
        {
            int oceanDeep = (int)Math.Round(0.8 * map.Cfg.Height) - map.Cfg.EarthHeight;
            int oceanWidth = map.Cfg.Width / map.Cfg.Biomes.Count;

            bool isInStartOcean = map.Blocks[0, 0].BiomeType == BiomeType.Ocean;

            int currentY = map.Cfg.EarthHeight;

            if (isInStartOcean)
            {
                for (int y = 0; y < map.Cfg.Height; y++)
                {
                    if (map.Blocks[y, oceanWidth].Index == 10)
                    {
                        currentY = y;
                        break;
                    }
                }
            } else
            {
                for (int y = 0; y < map.Cfg.Height; y++)
                {
                    if (map.Blocks[y, oceanWidth * (map.Cfg.Biomes.Count - 1)].Index == 10)
                    {
                        currentY = y;
                        break;
                    }
                }
            }

            for (int x = 0; x < map.Cfg.Width; x++)
            {
                if (map.Blocks[0, x].BiomeType != BiomeType.Ocean)
                    continue;

                if (isInStartOcean)
                {
                    for (int y = currentY - 1; y >= 0; y--)
                    {
                        map.Blocks[y, x].Index = 0; // Блок пустоты
                        map.Backgrounds[y, x].Index = 0; // Стена пустоты
                    }

                    for (int y = currentY; y < map.Cfg.EarthHeight + MathFunction(x, oceanDeep, oceanWidth); y++)
                    {
                        map.Blocks[y, x].Index = 40; // Блок воды
                        map.Backgrounds[y, x].Index = 0; // Стена пустоты
                    }
                }
                else
                {
                    for (int y = currentY - 1; y >= 0; y--)
                    {
                        map.Blocks[y, x].Index = 0; // Блок пустоты
                        map.Backgrounds[y, x].Index = 0; // Стена пустоты
                    }

                    for (int y = currentY; y < map.Cfg.EarthHeight + MathFunction(oceanWidth - (x - oceanWidth * (map.Cfg.Biomes.Count - 1)), oceanDeep, oceanWidth); y++)
                    {
                        map.Blocks[y, x].Index = 40; // Блок воды
                        map.Backgrounds[y, x].Index = 0; // Стена пустоты
                    }
                }
            }

            return map;
        }

        private static int MathFunction(int x, int h, int w)
        {
            // y = (- h/(w^2))*x^2+h. Перевернутая параболла с переменными h и w, где при x = 0 будет y = h и где при y = 0 будет x = w.

            double resultDouble = -(double)h / ((double)w * (double)w) * (double)x * (double)x + (double)h;

            return (int)Math.Floor(resultDouble);
        }
    }
}
