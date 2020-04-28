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
                Category.Ones => GetOnesScore(dice),
                _ => throw new InvalidEnumArgumentException()
            };
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

        private static int GetOnesScore(IEnumerable<int> dice)
        {
            return dice.Where(x => x == 1).Sum(); // show rider suggestion LINQ
        }
    }
}