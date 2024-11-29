namespace Battleship.AI.Contract
{
    public class Gameboard
    {
        private readonly Fleet _fleet;
        private readonly Grid _grid;

        public Fleet Fleet
        {
            get { return _fleet; }
        }

        public Grid Grid
        {
            get { return _grid; }
        }


        public Gameboard()
        {
            _fleet = new Fleet();
            _grid = new Grid();
        }
    }
}
