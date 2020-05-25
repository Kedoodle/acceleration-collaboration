using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public class ScoreByFacesCategory : IScoringMethod
    {
        private readonly int _face;

        public ScoreByFacesCategory(int face)
        {
            _face = face;
        }
        
        public int GetScore(IEnumerable<int> dice)
        {
            return dice.Where(die => die == _face).Sum();
        }

    }
}