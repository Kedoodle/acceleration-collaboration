using System.Collections.Generic;
using System.Linq;

namespace Yatzy.ScoringMethod
{
    public class ScoreByFullHouse : IScoringMethod
    {
        public int GetScore(IEnumerable<int> dice)
        {
            return HasFullHouse(dice) ? dice.Sum() : 0;
        }
        
        private static bool HasFullHouse(IEnumerable<int> dice)
        {
            var groups = dice.GroupBy(die => die).ToList();
            
            var hasTwoGroups = groups.Count == 2;
            var hasGroupWithTwoElements = groups.Any(group => group.Count() == 2);
            
            return hasTwoGroups && hasGroupWithTwoElements;
        }
    }
}
