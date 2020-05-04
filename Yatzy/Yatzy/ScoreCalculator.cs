using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Yatzy
{
    public static class ScoreCalculator
    {
        public static int GetScore(IEnumerable<int> dice, Category category)
        {
            return category switch
            {
                Category.Chance => GetChanceScore(dice),
                Category.Yatzy => GetYatzyScore(dice),
                Category.Ones => GetFacesScore(dice, 1),
                Category.Twos => GetFacesScore(dice, 2),
                Category.Threes => GetFacesScore(dice, 3),
                Category.Fours => GetFacesScore(dice, 4),
                Category.Fives => GetFacesScore(dice, 5),
                Category.Sixes => GetFacesScore(dice, 6),
                Category.Pair => GetPairScore(dice),
                _ => throw new InvalidEnumArgumentException()
            };
        }

        private static int GetPairScore(IEnumerable<int> dice)
        {
            var biggestPair = 0;
            foreach (var die in dice)
            {
                biggestPair = UpdateBiggestPair(dice, die, biggestPair);
            }
            return biggestPair * 2;
        }

        private static int UpdateBiggestPair(IEnumerable<int> dice, int die, int biggestPair)
        {
            if (dice.Count(d => d == die) <= 1) return biggestPair;
            if (die > biggestPair)
            {
                biggestPair = die;
            }

            return biggestPair;
        }

        private static int GetChanceScore(IEnumerable<int> dice)
        {
            return dice.Sum();
        }

        private static int GetYatzyScore(IEnumerable<int> dice)
        {
            const int scoreForAllDiceSame = 50;
            const int scoreForDifferentDice = 0;
            return AllDiceSame(dice) ? scoreForAllDiceSame : scoreForDifferentDice;
        }

        private static bool AllDiceSame(IEnumerable<int> dice)
        {
            return dice.Distinct().Count() == 1;
        }

        private static int GetFacesScore(IEnumerable<int> dice, int face)
        {
            return dice.Where(die => die == face).Sum();
        }
    }
}