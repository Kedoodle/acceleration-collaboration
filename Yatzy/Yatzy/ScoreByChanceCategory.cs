using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class ScoreByChanceCategory : IScoringMethod
    {
        public int GetScore(IEnumerable<int> dice)
        {
            return dice.Sum();
        }
    }
}