using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Yatzy
{
    public class ScoreCalculator
    {
        public IEnumerable<int> Dice { get; set; }
        
        public int GetScore(Category category)
        {
            return category switch
            {
                Category.Chance => GetChanceScore(),
                Category.Yatzy => GetYatzyScore(),
                Category.Ones => GetFacesScore(1),
                Category.Twos => GetFacesScore(2),
                Category.Threes => GetFacesScore(3),
                Category.Fours => GetFacesScore(4),
                Category.Fives => GetFacesScore(5),
                Category.Sixes => GetFacesScore(6),
                Category.Pair => GetPairScore(),
                Category.TwoPairs => GetTwoPairsScore(),
                _ => throw new InvalidEnumArgumentException()
            };
        }

        private int GetChanceScore()
        {
            return Dice.Sum();
        }

        private int GetYatzyScore()
        {
            const int scoreForAllDiceSame = 50;
            const int scoreForDifferentDice = 0;
            return AllDiceSame() ? scoreForAllDiceSame : scoreForDifferentDice;
        }

        private bool AllDiceSame()
        {
            return Dice.Distinct().Count() == 1;
        }

        private int GetFacesScore(int face)
        {
            return Dice.Where(die => die == face).Sum();
        }

        private int GetPairScore()
        {
            return GetAllMultiples().Max() * 2;
        }

        private IEnumerable<int> GetAllMultiples()
        {
            return Dice.Where(HasMultiple);
        }

        private bool HasMultiple(int die)
        {
            return Dice.Count(d => d == die) > 1;
        }

        private int GetTwoPairsScore()
        {
            if (!HasTwoPairs()) return 0;
            
            // if four of the same
                // return 4 * that
            // if two distinct pairs
                // return 2 * sum of those
                
            var multiples = GetAllMultiples().ToList();
            var distinctMultiples = multiples.Distinct().ToList();
            if (distinctMultiples.Count == 1)
            {
                return distinctMultiples.First() * 4;
            }
            return distinctMultiples.Sum() * 2;
        }

        private bool HasTwoPairs()
        {
            return GetAllMultiples().Count() >= 4;
        }
    }
}