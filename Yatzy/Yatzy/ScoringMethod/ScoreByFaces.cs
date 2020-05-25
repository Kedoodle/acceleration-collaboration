using System.Collections.Generic;
using System.Linq;

namespace Yatzy.ScoringMethod
{
    public class ScoreByFaces : IScoringMethod
    {
        private readonly int _face;

        public ScoreByFaces(int face)
        {
            _face = face;
        }
        
        public int GetScore(IEnumerable<int> dice)
        {
            return dice.Where(die => die == _face).Sum();
        }
    }
}
