namespace Battleship.AI.Contract
{
    public class Score
    {
        private int _horizontal;
        private int _horizontalReverse;
        private int _horizontalTotal;

        private int _vertical;
        private int _verticalReverse;
        private int _verticalTotal;

        private int _total;

        /// <summary>
        /// Horizontal score
        /// </summary>
        public int Horizontal
        {
            get { return _horizontal; }
            set { _horizontal = value; }
        }

        /// <summary>
        /// Horizontal reverse score
        /// </summary>
        public int HorizontalReverse
        {
            get { return _horizontalReverse; }
            set { _horizontalReverse = value; }
        }

        /// <summary>
        /// Horizontal total score
        /// </summary>
        public int HorizontalTotal
        {
            get { return _horizontalTotal; }
            set { _horizontalTotal = value; }
        }

        /// <summary>
        /// Vertical score
        /// </summary>
        public int Vertical
        {
            get { return _vertical; }
            set { _vertical = value; }
        }

        /// <summary>
        /// Vertical reverse score
        /// </summary>
        public int VerticalReverse
        {
            get { return _verticalReverse; }
            set { _verticalReverse = value; }
        }

        /// <summary>
        /// Vertical total score
        /// </summary>
        public int VerticalTotal
        {
            get { return _verticalTotal; }
            set { _verticalTotal = value; }
        }

        /// <summary>
        /// Total score
        /// </summary>
        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public void ZeroOut()
        {
            _horizontal = 0;
            _horizontalReverse = 0;
            _horizontalTotal = 0;
            _vertical = 0;
            _verticalReverse = 0;
            _verticalTotal = 0;
            _total = 0;
        }
    }
}
