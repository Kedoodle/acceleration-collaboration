using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

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
                Category.Pair => GetNOfAKindScore(2),
                Category.TwoPairs => GetTwoPairsScore(),
                Category.ThreeOfAKind => GetNOfAKindScore(3),
                Category.FourOfAKind => GetNOfAKindScore(4),
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

        private int GetTwoPairsScore()
        {
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
            return Dice.Where(HasMultiple);
        }

        private bool HasMultiple(int die)
        {
            return Dice.Count(d => d == die) > 1;
        }

        private int GetNOfAKindScore(int n)
        {
            var fourOfAKind = Dice.Where(HasNOfAKind()).OrderByDescending(d => d).Take(n);
            return fourOfAKind.Sum();
            
            Func<int, bool> HasNOfAKind()
            {
                return die => Dice.Count(d => d == die) >= n;
            }
        }

    }
}