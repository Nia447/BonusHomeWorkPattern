using BonusHomeworkPatternShonhodoevBayan972102.Models;
using System.Drawing;
using System.Drawing.Imaging;

namespace BonusHomeworkPatternShonhodoevBayan972102.General
{
    public static class Printer
    {
        public static void CreateImageFromMap(Map map)
        {
            string startPath = Environment.CurrentDirectory + "\\..\\..\\..\\";

            int blockWidth = 40;
            int blockHeight = 40;

            int width = map.Cfg.Width * blockWidth;
            int height = map.Cfg.Height * blockHeight;

            Bitmap finalImage = new (width, height);

            string sceneName = "scene_forest_with_mountains";

            Image sceneImage = new Bitmap(startPath + $"General\\Images\\Scene\\{sceneName}.png");
            using (Graphics graphics = Graphics.FromImage(finalImage))
            {
                graphics.DrawImage(sceneImage, 0, 0, width, height);
            }

            for (int y = 0; y < map.Cfg.Height; y++)
            {
                for (int x = 0; x < map.Cfg.Width; x++)
                {
                    int backgroundValue = map.Backgrounds[y, x].Index;
                    Image backgroundImage = GetBackgroundImage(backgroundValue);
                    using (Graphics graphics = Graphics.FromImage(finalImage))
                    {
                        graphics.DrawImage(backgroundImage, x * blockWidth, y * blockHeight, blockWidth, blockHeight);
                    }

                    int blockValue = map.Blocks[y, x].Index;
                    Image blockImage = GetBlockImage(blockValue);
                    using (Graphics graphics = Graphics.FromImage(finalImage))
                    {
                        graphics.DrawImage(blockImage, x * blockWidth, y * blockHeight, blockWidth, blockHeight);
                    }
                }
            }

            string fileName = "Results\\result.png";
            string fileNameHistory = $"Results\\result_{DateTime.Now.Ticks}.png";

            string fullPath = Path.Combine(startPath, fileName);
            string fullPathHistory = Path.Combine(startPath, fileNameHistory);

            finalImage.Save(fullPath, ImageFormat.Png);
            finalImage.Save(fullPathHistory, ImageFormat.Png);
        }

        static Image GetBlockImage(int blockValue)
        {
            string startPath = Environment.CurrentDirectory + "\\..\\..\\..\\General\\Images\\Block\\";

            switch (blockValue)
            {
                case 10:
                    return new Bitmap(startPath + $"block_{blockValue}_grass.png");
                case 20:
                    return new Bitmap(startPath + $"block_{blockValue}_earth.png");
                case 30:
                    return new Bitmap(startPath + $"block_{blockValue}_stone.png");
                case 40:
                    return new Bitmap(startPath + $"block_{blockValue}_water.png");
                case 50:
                    return new Bitmap(startPath + $"block_{blockValue}_snow.png");
                case 60:
                    return new Bitmap(startPath + $"block_{blockValue}_sand.png");
                case 70:
                    return new Bitmap(startPath + $"block_{blockValue}_cactus.png");
                case 80:
                    return new Bitmap(startPath + $"block_{blockValue}_jungle_earth.png");
                case 90:
                    return new Bitmap(startPath + $"block_{blockValue}_jungle_grass.png");
                case 100:
                    return new Bitmap(startPath + $"block_{blockValue}_flower.png");
                case 110:
                    return new Bitmap(startPath + $"block_{blockValue}_flower.png");
                case 120:
                    return new Bitmap(startPath + $"block_{blockValue}_flower.png");
                case 130:
                    return new Bitmap(startPath + $"block_{blockValue}_wood.png");
                case 140:
                    return new Bitmap(startPath + $"block_{blockValue}_leaf.png");
                default:
                    return new Bitmap(startPath + "block_0_empty.png");
            }
        }

        static Image GetBackgroundImage(int blockValue)
        {
            string startPath = Environment.CurrentDirectory + "\\..\\..\\..\\General\\Images\\Background\\";

            switch (blockValue)
            {
                case 20:
                    return new Bitmap(startPath + $"background_{blockValue}_earth.png");
                case 30:
                    return new Bitmap(startPath + $"background_{blockValue}_stone.png");
                default:
                    return new Bitmap(startPath + "background_0_empty.png");
            }
        }
    }
}
