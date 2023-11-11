using BonusHomeworkPatternShonhodoevBayan972102.Models;

namespace BonusHomeworkPatternShonhodoevBayan972102.Contract.Strategies.Element
{
    public interface ICreateElementStrategy
    {
        public ElementParams ThisElementParams { get; set; }

        void CreateElement(ref Map map);
    }
}
