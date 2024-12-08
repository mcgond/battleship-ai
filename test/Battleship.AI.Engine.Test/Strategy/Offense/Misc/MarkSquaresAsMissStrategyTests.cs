using Microsoft.Extensions.DependencyInjection;

using Battleship.AI.Contract;
using Battleship.AI.Contract.Constants;
using Battleship.AI.Contract.Enumeration;
using Battleship.AI.Engine.Strategy.Offense.Misc;

using Battleship.AI.Engine.Test.Fixture;

namespace Battleship.AI.Engine.Test.Strategy.Offense.Misc
{
    [Collection("Engine Collection")]
    public class MarkSquaresAsMissStrategyTests
    {
        private EngineFixture _fixture;

        public MarkSquaresAsMissStrategyTests(EngineFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void MarkSquaresAsMiss_GameboardWithEmptySquares_MarksSquaresAsMiss()
        {
            MarkSquaresAsMissStrategy markSquaresAsMissStrategy = _fixture.ServiceProvider.GetRequiredService<MarkSquaresAsMissStrategy>();

            /**
             * Gameboard setup:
             *   1 2 3 4
             * A     M
             * B   M
             * C M
             * D
             */
            Gameboard gameboard = new Gameboard();
            gameboard.Grid.At(new Coordinate("A3")).State = SquareState.Miss;
            gameboard.Grid.At(new Coordinate("B2")).State = SquareState.Miss;
            gameboard.Grid.At(new Coordinate("C1")).State = SquareState.Miss;

            // Sink the ship of size two so three is smallest unsunk size
            gameboard.Fleet.Ships.Where(s => s.Name == ShipName.PATROL_BOAT).Single().Sink();

            markSquaresAsMissStrategy.MarkSquares(gameboard.Grid, gameboard.Fleet.SmallestUnsunkShipSize);

            Assert.Equal(SquareState.Miss, gameboard.Grid.At(new Coordinate("A1")).State);
            Assert.Equal(SquareState.Miss, gameboard.Grid.At(new Coordinate("A2")).State);
            Assert.Equal(SquareState.Miss, gameboard.Grid.At(new Coordinate("B1")).State);
        }

        [Fact]
        public void MarkSquaresAsMiss_GameboardWithEmptySquaresEndingOnLastColumn_MarksSquaresAsMiss()
        {
            MarkSquaresAsMissStrategy markSquaresAsMissStrategy = _fixture.ServiceProvider.GetRequiredService<MarkSquaresAsMissStrategy>();

            /**
             * Gameboard setup:
             *   7 8 9 10
             * A   M
             * B     M
             * C       M
             * D
             */
            Gameboard gameboard = new Gameboard();
            gameboard.Grid.At(new Coordinate("A8")).State = SquareState.Miss;
            gameboard.Grid.At(new Coordinate("B9")).State = SquareState.Miss;
            gameboard.Grid.At(new Coordinate("C10")).State = SquareState.Miss;

            // Sink the ship of size two so three is smallest unsunk size
            gameboard.Fleet.Ships.Where(s => s.Name == ShipName.PATROL_BOAT).Single().Sink();

            markSquaresAsMissStrategy.MarkSquares(gameboard.Grid, gameboard.Fleet.SmallestUnsunkShipSize);

            Assert.Equal(SquareState.Miss, gameboard.Grid.At(new Coordinate("A9")).State);
            Assert.Equal(SquareState.Miss, gameboard.Grid.At(new Coordinate("A10")).State);
            Assert.Equal(SquareState.Miss, gameboard.Grid.At(new Coordinate("B10")).State);
        }

        [Fact]
        public void MarkSquaresAsMiss_GameboardWithEmptySquaresEndingOnLastRow_MarksSquaresAsMiss()
        {
            MarkSquaresAsMissStrategy markSquaresAsMissStrategy = _fixture.ServiceProvider.GetRequiredService<MarkSquaresAsMissStrategy>();

            /**
             * Gameboard setup:
             *   1 2 3 4
             * G
             * H M
             * I   M
             * J     M
             */
            Gameboard gameboard = new Gameboard();
            gameboard.Grid.At(new Coordinate("H1")).State = SquareState.Miss;
            gameboard.Grid.At(new Coordinate("I2")).State = SquareState.Miss;
            gameboard.Grid.At(new Coordinate("J3")).State = SquareState.Miss;

            // Sink the ship of size two so three is smallest unsunk size
            gameboard.Fleet.Ships.Where(s => s.Name == ShipName.PATROL_BOAT).Single().Sink();

            markSquaresAsMissStrategy.MarkSquares(gameboard.Grid, gameboard.Fleet.SmallestUnsunkShipSize);

            Assert.Equal(SquareState.Miss, gameboard.Grid.At(new Coordinate("I1")).State);
            Assert.Equal(SquareState.Miss, gameboard.Grid.At(new Coordinate("J1")).State);
            Assert.Equal(SquareState.Miss, gameboard.Grid.At(new Coordinate("J2")).State);
        }
    }
}
