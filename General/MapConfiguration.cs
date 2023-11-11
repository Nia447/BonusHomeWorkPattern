using BonusHomeworkPatternShonhodoevBayan972102.Models.Enums;

namespace BonusHomeworkPatternShonhodoevBayan972102.General
{
    public class MapConfiguration
    {
        public int Width { get; }
        public int Height { get; }
        public int Seed { get; }
        public int EarthHeight { get; set; }
        public List<BiomeType> Biomes { get; set; }
        public GeneratorStrategyType GeneratorStrategyType { get; }
        
        public MapConfiguration(int width, int height, int seed, GeneratorStrategyType generatorStrategyType)
        {
            Width = width;
            Height = height;
            Seed = seed;
            EarthHeight = height / 2;
            GeneratorStrategyType = generatorStrategyType;
        }
    }
}
