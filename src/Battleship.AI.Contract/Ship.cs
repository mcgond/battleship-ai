using Battleship.AI.Contract.Enumeration;

namespace Battleship.AI.Contract
{
    public class Ship
    {
        private readonly string _name;
        private readonly int _size;
        private bool _sunk;
        private readonly List<Coordinate> _location;

        /// <summary>
        /// Name of the ship
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Size of the ship
        /// </summary>
        public int Size
        {
            get { return _size; }
        }

        /// <summary>
        /// Indicates if the ship is sunk
        /// </summary>
        public bool Sunk
        {
            get { return _sunk; }
        }

        /// <summary>
        /// List of <see cref="Coordinate"/> where the ship is located
        /// </summary>
        public List<Coordinate> Location
        {
            get { return _location; }
        }

        public Orientation Orientation
        {
            get
            {
                if (_location.Count == 0)
                {
                    return Orientation.None;
                }
                else if (_location.Count == 1)
                {
                    return Orientation.Unknown;
                }
                else
                {
                    // Ship located at C1 and D1 is orientated vertically
                    if (_location[0].Number == _location[1].Number)
                    {
                        return Orientation.Vertical;
                    }
                    // Ship located at C1 and C2 is orientated horizontally
                    else if (_location[0].Letter == _location[1].Letter)
                    {
                        return Orientation.Horizontal;
                    }
                    // Something has gone horribly, horribly wrong
                    else
                    {
                        throw new InvalidOperationException("Orientation of ship is invalid");
                    }
                }
            }
        }

        public Ship(string name, int size)
        {
            _name = name;
            _size = size;
            _sunk = false;
            _location = new List<Coordinate>();
        }

        /// <summary>
        /// Hit a ship. If a hit causes a ship to be sunk, <see cref="Sink()"/> will also be called
        /// </summary>
        /// <param name="coordinate">Coordinate where a ship is hit</param>
        public void Hit(Coordinate coordinate)
        {
            _location.Add(coordinate);

            if (_location.Count == _size)
            {
                Sink();
            }
        }

        /// <summary>
        /// Sink a ship
        /// </summary>
        public void Sink()
        {
            _sunk = true;
        }

        /// <summary>
        /// Place a ship
        /// </summary>
        /// <param name="coordinates">List of <see cref="Coordinate"/> where a ship is located</param>
        public void Place(List<Coordinate> coordinates)
        {
            if (coordinates.Count != _size)
            {
                throw new ArgumentException("Location of ship does not match size");
            }

            _location.AddRange(coordinates);
        }
    }
}
