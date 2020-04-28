using System;
using Xunit;

namespace Yatzy
{
    public class ScoreCalculatorShould
    {
        [Theory]
        [InlineData(new[]{1, 1, 3, 3, 6}, 14)]
        [InlineData(new[]{4, 5, 5, 6, 1}, 21)]
        public void SumAllDiceForChanceCategory(int[] dice, int expectedScore)
        {
            var actualScore = ScoreCalculator.GetScore(dice, Category.Chance);
            
            Assert.Equal(expectedScore, actualScore);
        }        
        
        [Theory]
        [InlineData(new[] {1, 1, 1, 1, 1}, 50)]
        [InlineData(new[] {1, 1, 1, 2, 1}, 0)]
        public void GivesScoreIfAllDiceSameForYatzyCategory(int[] dice, int expectedScore)
        {
            var actualScore = ScoreCalculator.GetScore(dice, Category.Yatzy);
            
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new[] {1, 1, 2, 4, 4}, 2)]
        [InlineData(new[] {2, 3, 2, 5, 1}, 1)]
        [InlineData(new[] {3, 3, 3, 4, 5}, 0)]
        public void SumAllOnesForOnesCategory(int[] dice, int expectedScore)
        {
            var actualScore = ScoreCalculator.GetScore(dice, Category.Ones);
            
            Assert.Equal(expectedScore, actualScore);
        }
    }
}