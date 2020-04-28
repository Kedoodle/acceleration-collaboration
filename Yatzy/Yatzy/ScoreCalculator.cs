using System.Collections.Generic;
using System.Linq;

namespace Yatzy
{
    public static class ScoreCalculator
    {
        public static int GetScore(IEnumerable<int> dice, Category category)
        {
            if (category == Category.Chance)
            {
                return dice.Sum();
            }
            else
            {
                return GetYatzyScore(dice);
            }
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
    }
}