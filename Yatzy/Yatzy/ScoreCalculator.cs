using System.Linq;

namespace Yatzy
{
    public static class ScoreCalculator
    {
        public static int GetScore(int[] dice, Category chance)
        {
            return dice.Sum();
        }
    }
}