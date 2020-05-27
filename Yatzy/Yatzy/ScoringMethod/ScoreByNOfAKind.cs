using System;
using System.Collections.Generic;
using System.Linq;

namespace Yatzy.ScoringMethod
{
    public class ScoreByNOfAKind : IScoringMethod
    {
        private readonly int _n;

        public ScoreByNOfAKind(int n)
        {
            _n = n;
        }
        
        public int GetScore(IEnumerable<int> dice)
        {
            var fourOfAKind = dice.Where(HasNOfAKind()).OrderByDescending(d => d).Take(_n);
            return fourOfAKind.Sum();
        
            Func<int, bool> HasNOfAKind()
            {
                return die => dice.Count(d => d == die) >= _n;
            }
        }
    }
}