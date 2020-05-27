using System.Collections.Generic;
using System.Linq;

namespace Yatzy.ScoringMethod
{
    public class ScoreByChance : IScoringMethod
    {
        public int GetScore(IEnumerable<int> dice)
        {
            return dice.Sum();
        }
    }
}