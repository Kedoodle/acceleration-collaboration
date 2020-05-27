using System.Collections.Generic;
using System.Linq;

namespace Yatzy.ScoringMethod
{
    public class ScoreByYatzy : IScoringMethod
    {
        public int GetScore(IEnumerable<int> dice)
        {
            const int scoreForAllDiceSame = 50;
            return AllDiceSame(dice) ? scoreForAllDiceSame : 0;
        }
        
        private bool AllDiceSame(IEnumerable<int> dice)
        {
            return dice.Distinct().Count() == 1;
        }
    }
}