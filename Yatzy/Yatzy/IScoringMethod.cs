using System.Collections.Generic;

namespace Yatzy
{
    public interface IScoringMethod
    {
        public int GetScore(IEnumerable<int> dice);
    }
}