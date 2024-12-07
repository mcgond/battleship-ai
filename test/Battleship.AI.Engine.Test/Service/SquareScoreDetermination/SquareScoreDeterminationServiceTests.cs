using Microsoft.Extensions.DependencyInjection;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Enumeration;
using Battleship.AI.Engine.Service.SquareScoreDetermination;

using Battleship.AI.Engine.Test.Fixture;

namespace Battleship.AI.Engine.Test.Service.SquareScoreDetermination
{
    [Collection("Engine Collection")]
    public class SquareScoreDeterminationServiceTests
    {
        private EngineFixture _fixture;

        public SquareScoreDeterminationServiceTests(EngineFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void DetermineSquareScores_Squares_DeterminesScores()
        {
            ISquareScoreDeterminationService squareScoreDeterminationService = _fixture.ServiceProvider.GetRequiredService<ISquareScoreDeterminationService>();

            Grid grid = new Grid();
            squareScoreDeterminationService.DetermineSquareScores(grid.Squares);

            Assert.Equal(2, grid.Squares[0].Score.HorizontalTotal);
            Assert.Equal(2, grid.Squares[0].Score.VerticalTotal);
            Assert.Equal(4, grid.Squares[0].Score.Total);
        }

        [Fact]
        public void DetermineSquareScores_SquaresWithNonEmptyStates_DeterminesScores()
        {
            ISquareScoreDeterminationService squareScoreDeterminationService = _fixture.ServiceProvider.GetRequiredService<ISquareScoreDeterminationService>();

            Grid grid = new Grid();
            grid.Squares[1].State = SquareState.Hit;

            squareScoreDeterminationService.DetermineSquareScores(grid.Squares);
            Assert.Equal(1, grid.Squares[0].Score.Horizontal);
            Assert.Equal(1, grid.Squares[2].Score.Horizontal);
        }
    }
}
