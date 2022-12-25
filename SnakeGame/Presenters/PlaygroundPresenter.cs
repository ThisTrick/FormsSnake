using System;
using System.Drawing;
using System.Windows.Forms;
using FormsSnake.Models;
using FormsSnake.Views;

namespace FormsSnake.Presenters
{
    public class PlaygroundPresenter
    {
        private readonly IPlaygroundView _view;
        private readonly PlaygroundModel _model;
        private readonly Random _rand;
        
        private SnakeView _snake;
        private AppleView _apple;

        public PlaygroundPresenter(IPlaygroundView view)
        {
            _view = view;
            _model = new PlaygroundModel();
            _rand = new Random(Guid.NewGuid().GetHashCode());
            _view.Load += OnLoad;
            _view.GameTick += OnGameTick;
            _view.KeyDown += OnKeyDown;
        }


        private void OnLoad(object sender, EventArgs e)
        {
            _snake = new SnakeView();
            _snake.Died += OnSnakeDeath;

            foreach (Control control in _snake.GetControls())
                _view.AddControl(control);
            
            _apple = new AppleView() { Location = new Point(96, 96) };
            _view.AddControl(_apple);
            _view.SetScore(CalcScore());
        }
        
        private int CalcScore() => _snake.Count - 3;
        
        private void OnGameTick(object sender, EventArgs e)
        {
           if (SnakeNoHitWall())
           {
                _snake.Move(new Point(_model.CurrentDirection.X * _model.Step, _model.CurrentDirection.Y * _model.Step));

                if (SnakeCaughtApple())
                {
                    _apple.Location = new Point(32 * _rand.Next(1, 19), 32 * _rand.Next(1, 19));
                    _view.AddControl(_snake.EatApple());
                    _view.SetScore(CalcScore());
                }
                return;
           }
           
           OnSnakeDeath();
        }
        
        private bool SnakeNoHitWall() => _snake.Location.X <= _model.Space
                                         && _snake.Location.Y <= _model.Space
                                         && _snake.Location.X >= 0
                                         && _snake.Location.Y >= 0;

        private bool SnakeCaughtApple() => _snake.Location == _apple.Location;
        
        private void OnSnakeDeath()
        {
            foreach (Control control in _snake.CutTail())
                _view.RemoveControl(control);
            _snake.SetDefaultLocationForHead();
            _model.SetDefaultDirection();
            _view.SetScore(CalcScore());
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
                _view.Close();

            if (e.KeyData == Keys.W || e.KeyData == Keys.Up)
                _model.SetDirection(Direction.Top);

            if (e.KeyData == Keys.S || e.KeyData == Keys.Down)
                _model.SetDirection(Direction.Bottom);

            if (e.KeyData == Keys.A || e.KeyData == Keys.Left)
                _model.SetDirection(Direction.Left);

            if (e.KeyData == Keys.D || e.KeyData == Keys.Right)
                _model.SetDirection(Direction.Right);
        }
    }
}