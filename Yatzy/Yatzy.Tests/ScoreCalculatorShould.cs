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
        [InlineData(new[]{1, 1, 3, 3, 6}, 14)]
        [InlineData(new[]{4, 5, 5, 6, 1}, 21)]
        public void ReturnsFiftyForYatzyCategory(int[] dice, int expectedScore)
        {
            var actualScore = ScoreCalculator.GetScore(dice, Category.Chance);
            
            Assert.Equal(expectedScore, actualScore);
        }
        
        
    }
}