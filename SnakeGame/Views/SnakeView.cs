using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FormsSnake.Views
{
    public class SnakeView
    {
        private readonly List<SnakePartView> _parts;

        public Point Location => _parts[0].Location;
        public int Count => _parts.Count;

        public event Action Died;
        
        public SnakeView()
        {
            _parts = new List<SnakePartView>() {
                new SnakePartView(),
                new SnakePartView(),
                new SnakePartView(),
            };
            SetDefaultLocationForHead();
        }
        
        public void SetDefaultLocationForHead()
        {
            _parts[0].Location = new Point(96, 64);
            _parts[1].Location = new Point(64, 64);
            _parts[2].Location = new Point(32, 64);
        }
        
        public void Move(Point step)
        {
            for (int i = _parts.Count - 1; i > 0; i--)
            {
                _parts[i].Location = _parts[i - 1].Location;
                if (i != 1 && _parts[0].Location == _parts[i].Location)
                {
                    Died?.Invoke();
                    return;
                }
            } 
            _parts[0].Location = new Point(_parts[0].Location.X + step.X,
                _parts[0].Location.Y + step.Y);
        }

        public IReadOnlyList<Control> CutTail()
        {
            var removedParts = new List<SnakePartView>();
            for (int i = _parts.Count - 1; i > 2; i--)
            {
                removedParts.Add(_parts[i]);
                _parts.Remove(_parts[i]);
            }
            return removedParts;
        }

        public SnakePartView EatApple()
        {
            var location = new Point(_parts.Last().Location.X, _parts.Last().Location.Y);
            _parts.Add(new SnakePartView{Location = location});
            return _parts.Last();
        }

        public IReadOnlyList<Control> GetControls() => _parts;
    }
}