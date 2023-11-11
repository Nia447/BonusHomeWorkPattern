using BonusHomeworkPatternShonhodoevBayan972102.Contract;
using BonusHomeworkPatternShonhodoevBayan972102.Models;
using BonusHomeworkPatternShonhodoevBayan972102.Models.Enums;

namespace BonusHomeworkPatternShonhodoevBayan972102.General.Iterators.ProceduralStage
{
    public class BiomeProceduralStage : IProceduralStage
    {
        public Map ExecuteProcedure(Map map)
        {
            Random rand = new(map.Cfg.Seed);

            int BiomeWidth = map.Cfg.Width / map.Cfg.Biomes.Count;

            // Проверка обязательных условий

            if (!map.Cfg.Biomes.Contains(BiomeType.Ocean) || !map.Cfg.Biomes.Contains(BiomeType.Mountain) || !map.Cfg.Biomes.Contains(BiomeType.Forest))
            {
                throw new Exception("Ocean, Mountain, Forest are required.");
            }

            // Определение порядка размещения биомов

            BiomeType[] BiomesOrder = new BiomeType[map.Cfg.Biomes.Count];

            BiomesOrder[0] = rand.Next(0, 2) == 1 ? BiomeType.Ocean : BiomeType.Mountain;

            BiomesOrder[map.Cfg.Biomes.Count - 1] = (BiomesOrder[0] == BiomeType.Ocean) ? BiomeType.Mountain : BiomeType.Ocean;

            List<BiomeType> remainingBiomes = new List<BiomeType>(map.Cfg.Biomes);
            remainingBiomes.Remove(BiomesOrder[0]);
            remainingBiomes.Remove(BiomesOrder[map.Cfg.Biomes.Count - 1]);

            List<BiomeType> shuffledList = remainingBiomes.OrderBy(item => rand.Next()).ToList();

            for (int i = 1; i < map.Cfg.Biomes.Count - 1; i++)
            {
                BiomesOrder[i] = shuffledList[i - 1];
            }

            List<BiomeType> list = new List<BiomeType>();

            for (int i = 0; i < map.Cfg.Biomes.Count; i++)
            {
                list.Add(BiomesOrder[i]);
            }

            map.Cfg.Biomes = list;

            // Закрепление биомов за блоками

            for (int y = 0; y < map.Cfg.Height; y++)
            {
                for (int x = 0; x < map.Cfg.Width; x++)
                {
                    map.Blocks[y, x].BiomeType = BiomesOrder[x / BiomeWidth != map.Cfg.Biomes.Count ? x / BiomeWidth : map.Cfg.Biomes.Count - 1];
                }
            }

            return map;
        }
    }
}
