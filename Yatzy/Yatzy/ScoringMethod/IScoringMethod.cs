using System.Collections.Generic;

namespace Yatzy.ScoringMethod
 {
    public interface IScoringMethod
    {
        public int GetScore(IEnumerable<int> dice);
    }
}