using BonusHomeworkPatternShonhodoevBayan972102.Contract;
using BonusHomeworkPatternShonhodoevBayan972102.Contract.Strategies.Element;
using BonusHomeworkPatternShonhodoevBayan972102.General.Factories.Element;
using BonusHomeworkPatternShonhodoevBayan972102.Models;
using BonusHomeworkPatternShonhodoevBayan972102.Models.Enums;

namespace BonusHomeworkPatternShonhodoevBayan972102.General.Iterators.ProceduralStage
{
    public class JungleProceduralStage:IProceduralStage
    {
        public Map ExecuteProcedure(Map map)
        {
            Random rand = new(map.Cfg.Seed);

            int maxJungleEarthDeep = rand.Next(6, 10);
            int minJungleEarthDeep = rand.Next(4, 6);
            int numJungleFlower = 6;
            int minDistance = 1;

            int currentY = map.Cfg.EarthHeight;
            int currentJungleEarthDeep = rand.Next(minJungleEarthDeep, maxJungleEarthDeep);

            int jungleWidth = map.Cfg.Width / map.Cfg.Biomes.Count;
            int jungleStart = jungleWidth * map.Cfg.Biomes.IndexOf(BiomeType.Jungle);
            int jungleEnd = jungleWidth * (map.Cfg.Biomes.IndexOf(BiomeType.Jungle) + 1);

            for (int y = 0; y < map.Cfg.Height; y++)
            {
                if (map.Blocks[y, jungleWidth * map.Cfg.Biomes.IndexOf(BiomeType.Jungle)].Index == 10)
                {
                    currentY = y;
                    break;
                }
            }

            List<(int, int)> positionsOfFlowers = new List<(int, int)>();

            for (int i = 0; i < numJungleFlower; i++)
            {
                int x, y;
                bool validPosition;

                do
                {
                    validPosition = true;
                    x = rand.Next(jungleStart, jungleEnd + 1);

                    foreach ((int cx, int cy) in positionsOfFlowers)
                    {
                        double distance = Math.Abs(x - cx);

                        if (distance < minDistance)
                        {
                            validPosition = false;
                            break;
                        }
                    }
                } while (!validPosition);

                positionsOfFlowers.Add((x, map.Cfg.EarthHeight));
            }

            for (int x = 0; x < map.Cfg.Width; x++)
            {
                if (map.Blocks[0, x].BiomeType != BiomeType.Jungle)
                    continue;

                int NumberOfPlacedJungleEarthBlocked = 0;
                bool isFoundGrass = false;
                for (int y = 0; (y < map.Cfg.Height) && (NumberOfPlacedJungleEarthBlocked < currentJungleEarthDeep); y++)
                {
                    if (map.Blocks[y, x].Index == 10)
                    {
                        isFoundGrass = true;
                    }

                    if (isFoundGrass)
                    {
                        if (NumberOfPlacedJungleEarthBlocked == 0 && positionsOfFlowers.FindIndex(cactus => cactus.Item1 == x) != -1)
                        {
                            map.Blocks[y - 1, x].Index = 100; // Блок джунглевой травы
                        }

                        if (NumberOfPlacedJungleEarthBlocked < currentJungleEarthDeep)
                        {
                            if (NumberOfPlacedJungleEarthBlocked == 0)
                            {
                                map.Blocks[y, x].Index = 90; // Блок джунглевой травы
                                map.Backgrounds[y, x].Index = 0; // Стена пустоты
                            }
                            else
                            {
                                map.Blocks[y, x].Index = 80; // Блок джунглевой земли
                                map.Backgrounds[y, x].Index = 0; // Стена пустоты
                            }
                            NumberOfPlacedJungleEarthBlocked++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                int yNextStep = rand.Next(1, 3) == 1 ? -1 : 1;

                if (currentJungleEarthDeep + yNextStep <= maxJungleEarthDeep && currentJungleEarthDeep + yNextStep >= minJungleEarthDeep)
                {
                    currentJungleEarthDeep += yNextStep;
                }
                else
                {
                    currentJungleEarthDeep -= yNextStep;
                }
            }

            return map;
        }
    }
}
