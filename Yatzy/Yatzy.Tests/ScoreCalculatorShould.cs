using System;
using Xunit;

namespace Yatzy
{
    public class ScoreCalculatorShould
    {
        private readonly ScoreCalculator _scoreCalculator;

        public ScoreCalculatorShould()
        {
            _scoreCalculator = new ScoreCalculator();
        }
        
        [Theory]
        [InlineData(new[]{1, 1, 3, 3, 6}, 14)]
        [InlineData(new[]{4, 5, 5, 6, 1}, 21)]
        public void SumAllDiceForChanceCategory(int[] dice, int expectedScore)
        {
            _scoreCalculator.Dice = dice;
            var actualScore = _scoreCalculator.GetScore(Category.Chance);
            
            Assert.Equal(expectedScore, actualScore);
        }        
        
        [Theory]
        [InlineData(new[] {1, 1, 1, 1, 1}, 50)]
        [InlineData(new[] {1, 1, 1, 2, 1}, 0)]
        public void GivesScoreIfAllDiceSameForYatzyCategory(int[] dice, int expectedScore)
        {
            _scoreCalculator.Dice = dice;
            var actualScore = _scoreCalculator.GetScore(Category.Yatzy);
            
            Assert.Equal(expectedScore, actualScore);
        }

        [Theory]
        [InlineData(new[] {1, 1, 2, 4, 4}, 2)]
        [InlineData(new[] {2, 3, 2, 5, 1}, 1)]
        [InlineData(new[] {3, 3, 3, 4, 5}, 0)]
        [InlineData(new[] {1, 1, 1, 1, 1}, 5)]
        public void SumAllOnesForOnesCategory(int[] dice, int expectedScore)
        {
            _scoreCalculator.Dice = dice;
            var actualScore = _scoreCalculator.GetScore(Category.Ones);
            
            Assert.Equal(expectedScore, actualScore);
        }   
        
        [Theory]
        [InlineData(new[] {1, 1, 2, 4, 4}, 2)]
        [InlineData(new[] {2, 3, 2, 5, 1}, 4)]
        [InlineData(new[] {3, 3, 3, 4, 5}, 0)]
        [InlineData(new[] {2, 2, 2, 2, 2}, 10)]
        public void SumAllTwosForTwosCategory(int[] dice, int expectedScore)
        {
            _scoreCalculator.Dice = dice;
            var actualScore = _scoreCalculator.GetScore(Category.Twos);
            
            Assert.Equal(expectedScore, actualScore);
        }   
        
        [Theory]
        [InlineData(new[] {1, 1, 2, 4, 4}, 0)]
        [InlineData(new[] {2, 3, 2, 5, 1}, 3)]
        [InlineData(new[] {3, 3, 3, 4, 5}, 9)]
        [InlineData(new[] {3, 3, 3, 3, 3}, 15)]
        public void SumAllThreesForThreesCategory(int[] dice, int expectedScore)
        {
            _scoreCalculator.Dice = dice;
            var actualScore = _scoreCalculator.GetScore(Category.Threes);
            
            Assert.Equal(expectedScore, actualScore);
        }   
        
        [Theory]
        [InlineData(new[] {1, 1, 2, 4, 4}, 8)]
        [InlineData(new[] {2, 3, 2, 5, 1}, 0)]
        [InlineData(new[] {3, 3, 3, 4, 5}, 4)]
        [InlineData(new[] {4, 4, 4, 4, 4}, 20)]
        public void SumAllFoursForFoursCategory(int[] dice, int expectedScore)
        {
            _scoreCalculator.Dice = dice;
            var actualScore = _scoreCalculator.GetScore(Category.Fours);
            
            Assert.Equal(expectedScore, actualScore);
        }   
        
        [Theory]
        [InlineData(new[] {1, 1, 2, 4, 4}, 0)]
        [InlineData(new[] {2, 3, 5, 5, 1}, 10)]
        [InlineData(new[] {3, 3, 3, 4, 5}, 5)]
        [InlineData(new[] {5, 5, 5, 5, 5}, 25)]
        public void SumAllFivesForFivesCategory(int[] dice, int expectedScore)
        {
            _scoreCalculator.Dice = dice;
            var actualScore = _scoreCalculator.GetScore(Category.Fives);
            
            Assert.Equal(expectedScore, actualScore);
        }   
        
        [Theory]
        [InlineData(new[] {1, 1, 6, 4, 4}, 6)]
        [InlineData(new[] {2, 6, 6, 5, 1}, 12)]
        [InlineData(new[] {3, 3, 3, 4, 5}, 0)]
        [InlineData(new[] {6, 6, 6, 6, 6}, 30)]
        public void SumAllSixesForSixesCategory(int[] dice, int expectedScore)
        {
            _scoreCalculator.Dice = dice;
            var actualScore = _scoreCalculator.GetScore(Category.Sixes);
            
            Assert.Equal(expectedScore, actualScore);
        }
        
        [Theory]
        [InlineData(new[] {3, 3, 3, 4, 4}, 8)]
        [InlineData(new[] {1, 1, 6, 2, 6}, 12)]
        [InlineData(new[] {3, 3, 3, 4, 1}, 6)]
        [InlineData(new[] {3, 3, 3, 3, 1}, 6)]
        public void SumHighestPairForPairCategory(int[] dice, int expectedScore)
        {
            _scoreCalculator.Dice = dice;
            var actualScore = _scoreCalculator.GetScore(Category.Pair);
            
            Assert.Equal(expectedScore, actualScore);
        }        
        
        [Theory]
        [InlineData(new[] {1, 1, 2, 3, 3}, 8)]
        [InlineData(new[] {1, 1, 2, 3, 4}, 0)]
        [InlineData(new[] {1, 1, 2, 2, 2}, 6)]
        [InlineData(new[] {3, 3, 3, 3, 1}, 12)]
        public void SumTwoPairsForTwoPairsCategory(int[] dice, int expectedScore)
        {
            _scoreCalculator.Dice = dice;
            var actualScore = _scoreCalculator.GetScore(Category.TwoPairs);
            
            Assert.Equal(expectedScore, actualScore);
        }
        
        [Theory]
        [InlineData(new[] {3, 3, 3, 4, 5}, 9)]
        [InlineData(new[] {3, 3, 4, 5, 6}, 0)]
        [InlineData(new[] {3, 3, 3, 3, 1}, 9)]
        public void SumThreeMatchingDiceForThreeOfAKindCategory(int[] dice, int expectedScore)
        {
            _scoreCalculator.Dice = dice;
            var actualScore = _scoreCalculator.GetScore(Category.ThreeOfAKind);
            
            Assert.Equal(expectedScore, actualScore);
        }
    }
}
