namespace Battleship.AI.Contract.Test
{
    public class CoordinateTests
    {
        [Fact]
        public void ToString_CoordinateWithOneDigitNumber_ReturnsCoordinateString()
        {
            string expected = "C1";
            Coordinate coordinate = new Coordinate('C', 1);

            string actual = coordinate.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToString_CoordinateWithTwoDigitNumber_ReturnsCoordinateString()
        {
            string expected = "C10";
            Coordinate coordinate = new Coordinate('C', 10);

            string actual = coordinate.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToString_CoordinateStringWithOneDigitNumber_ReturnsCoordinateString()
        {
            string expected = "C1";
            Coordinate coordinate = new Coordinate("C1");

            string actual = coordinate.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ToString_CoordinateStringWithTwoDigitNumber_ReturnsCoordinateString()
        {
            string expected = "C10";
            Coordinate coordinate = new Coordinate("C10");

            string actual = coordinate.ToString();

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Equals_TwoEqualCoordinates_ReturnsTrue()
        {
            Coordinate first = new Coordinate("C10");
            Coordinate second = new Coordinate('C', 10);

            Assert.True(first.Equals(second));
            Assert.True(first == second);
            Assert.False(first != second);
        }

        [Fact]
        public void Equals_TwoNotEqualCoordinates_ReturnsTrue()
        {
            Coordinate first = new Coordinate("C1");
            Coordinate second = new Coordinate('D', 10);

            Assert.False(first.Equals(second));
            Assert.False(first == second);
            Assert.True(first != second);
        }

        [Fact]
        public void Equals_NotCoordinate_ReturnsFalse()
        {
            object notACoordinate = new object();
            Coordinate coordinate = new Coordinate("C1");

            Assert.False(coordinate.Equals(notACoordinate));
        }

        [Fact]
        public void Equals_NullObject_ReturnsFalse()
        {
            object nullObject = null!;
            Coordinate coordinate = new Coordinate("C1");

            Assert.False(coordinate.Equals(nullObject));
        }

        [Fact]
        public void GetHashCode_TwoEqualCoordinate_ReturnsSameHashCode()
        {
            Coordinate firstCoordinate = new Coordinate("A1");
            Coordinate secondCoordinate = new Coordinate("A1");

            int firstCoordinateHashCode = firstCoordinate.GetHashCode();
            int secondCoordinateHashCode = secondCoordinate.GetHashCode();

            Assert.Equal(firstCoordinateHashCode, secondCoordinateHashCode);
        }
    }
}