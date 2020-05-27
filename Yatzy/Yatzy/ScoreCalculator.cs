using System.Collections.Generic;
using System.ComponentModel;
using Yatzy.ScoringMethod;

namespace Yatzy
{
    public class ScoreCalculator
    {
        public int Calculate(Category category, IEnumerable<int> dice)
        {
            IScoringMethod scoringMethod = category switch
            {
                Category.Chance => new ScoreByChance(),
                Category.Yatzy => new ScoreByYatzy(),
                Category.Ones => new ScoreByFaces(1),
                Category.Twos => new ScoreByFaces(2),
                Category.Threes => new ScoreByFaces(3),
                Category.Fours => new ScoreByFaces(4),
                Category.Fives => new ScoreByFaces(5),
                Category.Sixes => new ScoreByFaces(6),
                Category.Pair => new ScoreByNOfAKind(2),
                Category.TwoPairs => new ScoreByTwoPairs(),
                Category.ThreeOfAKind => new ScoreByNOfAKind(3),
                Category.FourOfAKind => new ScoreByNOfAKind(4),
                Category.SmallStraight => new ScoreByStraight(Category.SmallStraight),
                Category.LargeStraight => new ScoreByStraight(Category.LargeStraight),
                Category.FullHouse => new ScoreByFullHouse(),
                _ => throw new InvalidEnumArgumentException()
            };

            return scoringMethod.GetScore(dice);
        }
    }
}
