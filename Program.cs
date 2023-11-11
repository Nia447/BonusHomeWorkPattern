using BonusHomeworkPatternShonhodoevBayan972102.General;
using BonusHomeworkPatternShonhodoevBayan972102.Models;
using BonusHomeworkPatternShonhodoevBayan972102.Models.Enums;

MapConfiguration cfg = new(160 * 1, 90 * 1, new Random().Next(100), GeneratorStrategyType.NormalModeGenerator);

Generator generator = new(cfg);

Map map = generator.Generate();

Printer.CreateImageFromMap(map);
