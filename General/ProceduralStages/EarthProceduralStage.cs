using BonusHomeworkPatternShonhodoevBayan972102.Contract;
using BonusHomeworkPatternShonhodoevBayan972102.Models;

namespace BonusHomeworkPatternShonhodoevBayan972102.General.Iterators.ProceduralStage
{
    public class EarthProceduralStage : IProceduralStage
    {
        public Map ExecuteProcedure(Map map)
        {
            Random rand = new (map.Cfg.Seed);

            int eartLine = (int)Math.Round(0.6 * map.Cfg.Height);
            int yPeriodEarthLine = Math.Min(5, map.Cfg.Height);
            int xPeriodLenEarthLine = Math.Min(8, map.Cfg.Width);

            int stoneLine = (int)Math.Round(0.75 * map.Cfg.Height);
            int yPeriodStoneLine = Math.Min(5, map.Cfg.Height);
            int xPeriodLenStoneLine = Math.Min(8, map.Cfg.Width);

            map.Cfg.EarthHeight = eartLine;

            // Генерация поверхности земли

            int currentY = eartLine;
            for (int currentX = 0; currentX < map.Cfg.Width;)
            {
                int yNextStep = rand.Next(1, 3) == 1 ? -1 : 1;

                if (Math.Abs(eartLine - (currentY + yNextStep)) <= yPeriodEarthLine)
                {
                    currentY += yNextStep;
                }
                else
                {
                    currentY -= yNextStep;
                }

                int xCurrentPeriodLenEarthLine = rand.Next(3, xPeriodLenEarthLine + 1);

                for (int x = 0; x < xCurrentPeriodLenEarthLine && currentX + x < map.Cfg.Width; x++)
                {
                    map.Blocks[currentY, currentX + x].Index = 10; // Блок травы
                }

                currentX += xCurrentPeriodLenEarthLine;
            }

            // Генерация поверхности камня в коре

            currentY = stoneLine;
            for (int currentX = 0; currentX < map.Cfg.Width;)
            {
                int yNextStep = rand.Next(1, 3) == 1 ? -1 : 1;

                if (Math.Abs(stoneLine - (currentY + yNextStep)) <= yPeriodStoneLine)
                {
                    currentY += yNextStep;
                }
                else
                {
                    currentY -= yNextStep;
                }

                int xCurrentPeriodLenStoneLine = rand.Next(3, xPeriodLenStoneLine + 1);

                for (int x = 0; x < xCurrentPeriodLenStoneLine && currentX + x < map.Cfg.Width; x++)
                {
                    if (map.Blocks[currentY, currentX + x].Index == 10 || (currentY + 1 < map.Cfg.Height && map.Blocks[currentY + 1, currentX + x].Index == 10))
                    {
                        currentY += 1;
                        map.Blocks[currentY, currentX + x].Index = 30; // Блок камня
                        map.Backgrounds[currentY, currentX + x].Index = 30; // Стена камня
                    }
                    else
                    {
                        map.Blocks[currentY, currentX + x].Index = 30; // Блок камня
                        map.Backgrounds[currentY, currentX + x].Index = 30; // Стена камня
                    }
                }

                currentX += xCurrentPeriodLenStoneLine;
            }

            // Генерация земной коры

            int currentIndex = 0; // Блок пустоты

            for (int y = 0; y < map.Cfg.Height; y++)
            {
                for (int x = 0; x < map.Cfg.Width; x++)
                {
                    if (map.Blocks[y, x].Index == 0)
                    {
                        // Проверка верхнего блока
                        if (y - 1 >= 0)
                        {
                            currentIndex = map.Blocks[y - 1, x].Index;

                            if (currentIndex == 10)
                            {
                                currentIndex = 20;
                            }
                        }

                        map.Blocks[y, x].Index = currentIndex;
                        map.Backgrounds[y, x].Index = currentIndex;
                    } 
                    else
                    {
                        currentIndex = map.Blocks[y, x].Index;
                        map.Backgrounds[y, x].Index = currentIndex;
                    }
                }
            }

            return map;
        }
    }
}
