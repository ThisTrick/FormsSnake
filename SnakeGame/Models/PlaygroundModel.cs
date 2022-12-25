using System.Drawing;

namespace FormsSnake.Models
{
    public class PlaygroundModel
    {
        
        private readonly Point _directionLeft;
        private readonly Point _directionRight;
        private readonly Point _directionTop;
        private readonly Point _directionBottom;
        
        public int Space { get; }
        
        public int Step { get; }
        
        public Point CurrentDirection { get; set; }

        
        public PlaygroundModel()
        {
            Space = 576;
            Step = 32;
            _directionLeft = new Point(-1, 0);
            _directionRight = new Point(1, 0);
            _directionTop = new Point(0, -1);
            _directionBottom = new Point(0, 1);
            SetDefaultDirection();
        }

        public void SetDirection(Direction direction)
        {
            if (direction == Direction.Bottom && CurrentDirection != _directionTop)
                CurrentDirection = _directionBottom;
            if (direction == Direction.Top && CurrentDirection != _directionBottom)
                CurrentDirection = _directionTop;
            if (direction == Direction.Left && CurrentDirection != _directionRight)
                CurrentDirection = _directionLeft;
            if (direction == Direction.Right && CurrentDirection != _directionLeft)
                CurrentDirection = _directionRight;
        }

        public void SetDefaultDirection() => CurrentDirection = _directionRight;
    }
}