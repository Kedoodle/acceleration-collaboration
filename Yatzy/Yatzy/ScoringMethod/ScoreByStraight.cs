using System.Collections.Generic;
using System.Linq;

namespace Yatzy.ScoringMethod
{
    public class ScoreByStraight : IScoringMethod
    {
        private readonly bool _scoringByLargeStraight;

        public ScoreByStraight(Category category)
        {
            _scoringByLargeStraight = category == Category.LargeStraight;
        }

        public int GetScore(IEnumerable<int> dice)
        {
            var isStraight = HasAllFacesExcept(_scoringByLargeStraight ? 1 : 6);
            return isStraight ? dice.Sum() : 0;
                
            bool HasAllFacesExcept(int face)
            {
                return dice.Distinct().Count() == 5 && !dice.Distinct().Contains(face);;
            }
        }
    }
}