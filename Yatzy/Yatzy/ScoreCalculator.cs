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
                Category.TwoPairs => null,
                Category.ThreeOfAKind => new ScoreByNOfAKind(3),
                Category.FourOfAKind => new ScoreByNOfAKind(4),
                Category.SmallStraight => null,
                Category.LargeStraight => null,
                Category.FullHouse => null,
                _ => throw new InvalidEnumArgumentException()
            };

            return scoringMethod.GetScore(dice);
        }
    }
}

        // private int GetTwoPairsScore()
        // {
        //     if (!HasTwoPairs()) return 0;
        //
        //     var multiples = GetAllMultiples();
        //     var distinctMultiples = multiples.Distinct().ToList();
        //     
        //     var hasFourFacesSame = distinctMultiples.Count == 1;
        //     var identicalPairsScore = distinctMultiples.First() * 4;
        //     var distinctPairsScore = distinctMultiples.Sum() * 2;
        //     
        //     return hasFourFacesSame ? identicalPairsScore : distinctPairsScore;
        // }
        //
        // private bool HasTwoPairs()
        // {
        //     return GetAllMultiples().Count() >= 4;
        // }
        //
        // private IEnumerable<int> GetAllMultiples()
        // {
        //     return Dice.Where(HasMultiple);
        // }
        //
        // private bool HasMultiple(int die)
        // {
        //     return Dice.Count(d => d == die) > 1;
        // }
        //
        // private int GetNOfAKindScore(int n)
        // {
        //     var fourOfAKind = Dice.Where(HasNOfAKind()).OrderByDescending(d => d).Take(n);
        //     return fourOfAKind.Sum();
        //     
        //     Func<int, bool> HasNOfAKind()
        //     {
        //         return die => Dice.Count(d => d == die) >= n;
        //     }
        // }
        //
        // private int GetSmallStraightScore()
        // {
        //     return HasAllFacesExcept(6) ? Dice.Sum() : 0;
        // }
        //
        // private bool HasAllFacesExcept(int face)
        // {
        //     return Dice.Distinct().Count() == 5 && !Dice.Distinct().Contains(face);
        // }
        //
        // private int GetLargeStraightScore()
        // {
        //     return HasAllFacesExcept(1) ? Dice.Sum() : 0;
        // }
        //
        // private int GetFullHouseScore()
        // {
        //     return HasFullHouse() ? Dice.Sum() : 0;
        // }
        //
        // private bool HasFullHouse()
        // {
        //     var groups = Dice.GroupBy(die => die).ToList();
        //     
        //     var hasTwoGroups = groups.Count == 2;
        //     var hasGroupWithTwoElements = groups.Any(group => group.Count() == 2);
        //     
        //     return hasTwoGroups && hasGroupWithTwoElements;
        // }