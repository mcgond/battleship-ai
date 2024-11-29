namespace Battleship.AI.Contract.Test
{
    public class ScoreTests
    {
        [Fact]
        public void ZeroOut_Score_ZerosOutScore()
        {
            Score score = new Score();
            score.Horizontal = 1;
            score.HorizontalReverse = 1;
            score.HorizontalTotal = 1;
            score.Vertical = 1;
            score.VerticalReverse = 1;
            score.VerticalTotal = 1;
            score.Total = 1;

            score.ZeroOut();

            Assert.Equal(0, score.Horizontal);
            Assert.Equal(0, score.HorizontalReverse);
            Assert.Equal(0, score.HorizontalTotal);
            Assert.Equal(0, score.Vertical);
            Assert.Equal(0, score.VerticalReverse);
            Assert.Equal(0, score.VerticalTotal);
            Assert.Equal(0, score.Total);
        }
    }
}
