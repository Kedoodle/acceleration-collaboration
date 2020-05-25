using System.Collections.Generic;
using System.Linq;

namespace Yatzy.ScoringMethod
{
    public class ScoreByTwoPairs : IScoringMethod
    {
        private IEnumerable<int> _dice;

        public int GetScore(IEnumerable<int> dice)
        {
            _dice = dice;
            if (!HasTwoPairs()) return 0;
            
            var multiples = GetAllMultiples();
            var distinctMultiples = multiples.Distinct().ToList();
            
            var hasFourFacesSame = distinctMultiples.Count == 1;
            var identicalPairsScore = distinctMultiples.First() * 4;
            var distinctPairsScore = distinctMultiples.Sum() * 2;
            
            return hasFourFacesSame ? identicalPairsScore : distinctPairsScore;
        }
        
        private bool HasTwoPairs()
        {
            return GetAllMultiples().Count() >= 4;
        }
        
        private IEnumerable<int> GetAllMultiples()
        {
            return _dice.Where(HasMultiple);
        }
        
        private bool HasMultiple(int die)
        {
            return _dice.Count(d => d == die) > 1;
        }
    }
}
