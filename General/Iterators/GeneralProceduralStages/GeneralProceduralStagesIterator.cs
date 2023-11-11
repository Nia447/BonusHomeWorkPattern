using BonusHomeworkPatternShonhodoevBayan972102.Contract;
using System.Collections;

namespace BonusHomeworkPatternShonhodoevBayan972102.General.Iterators.ProceduralStage
{
    public class GeneralProceduralStagesIterator : IEnumerable<IProceduralStage>
    {
        private IProceduralStage[] stages = { new EarthProceduralStage(), new BiomeProceduralStage(), new OceanProceduralStage(), new MountainProceduralStage(), new DesertProceduralStage(), new JungleProceduralStage(), new ForestProceduralStage() };

        public IEnumerator<IProceduralStage> GetEnumerator()
        {
            foreach (var stage in stages)
            {
                yield return stage;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
