using BonusHomeworkPatternShonhodoevBayan972102.General;

namespace BonusHomeworkPatternShonhodoevBayan972102.Models
{
    public class Map
    {
        public Block[,] Blocks { get; set; }
        public Background[,] Backgrounds { get; set; }
        public MapConfiguration Cfg { get; set; }

        public Map(MapConfiguration cfg)
        {
            Blocks = new Block[cfg.Height, cfg.Width];
            Backgrounds = new Background[cfg.Height, cfg.Width];
            Cfg = cfg;

            for (int i = 0; i < cfg.Height; i++)
            {
                for (int j = 0; j < cfg.Width; j++)
                {
                    Blocks[i, j] = new Block();
                    Backgrounds[i, j] = new Background();
                }
            }
        }
    }
}
