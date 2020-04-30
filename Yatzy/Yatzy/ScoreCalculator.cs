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
            // copy dice to new list
            // get distinct values in list
            // remove distinct values from list
            // get max value in remaining items in list
            // return 2 * max value
            
            var diceWithPair = GetAllPairs(dice); // dice.Where(die => dice.Count(d => d == die) > 1);
            return diceWithPair.Max() * 2;
            1 1 2 3 4
                
                
            // sort dice descending
            // loop through dice
                // if die in dice at least twice, return 2 * die
            // return 0
            
            
            // set biggestpair = 0
            // loop through dice
                // if die in dice at least twice, if die > biggestpair set biggestpair = die
            // return biggest
            
            
            var diceGroupedByFace = dice.GroupBy(die => die);
            var facesWithPair= diceGroupedByFace.Where(group => group.Count() > 1);
            1 1 2 3 4
                
                33316
                                
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