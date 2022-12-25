using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        
        private List<SnakePartView> _snake;
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
            _snake = new List<SnakePartView>() {
                CreateSnakePart(new Point(96, 64)),
                CreateSnakePart(new Point(64, 64)),
                CreateSnakePart(new Point(32, 64)),
            };
            _snake.ForEach(p => _view.AddControl(p));
            _apple = CreateApplePanel(new Point(96, 96));
            _view.AddControl(_apple);
            _view.SetScore(CalcScore());
        }
        
        private SnakePartView CreateSnakePart(Point location)
        {
            var snakePart = new SnakePartView();
            snakePart.Location = location;
            return snakePart;
        }
        
        private AppleView CreateApplePanel(Point location)
        {
            var applePanel = new AppleView();
            applePanel.Location = location;
            return applePanel;
        }

        private int CalcScore() => _snake.Count - 3;
        
        private void OnGameTick(object sender, EventArgs e)
        {
            if (_snake[0].Location.X <= _model.Space 
                && _snake[0].Location.Y <= _model.Space 
                && _snake[0].Location.X >= 0 
                && _snake[0].Location.Y >= 0)
            {
                SnakeMoving();
                EatAnApple();
            }
            else
            {
                SnakeStartingPoint();
            }
        }
        
        private void SnakeMoving()
        {
            for (int i = _snake.Count - 1; i > 0; i--)
            {
                var tmp = _snake[i - 1].Location;
                _snake[i].Location = tmp;
                if (i != 1 && _snake[0].Location == _snake[i].Location)
                {
                    SnakeDeath();
                    return;
                }
            } 
            _snake[0].Location = new Point(_snake[0].Location.X + _model.CurrentDirection.X * _model.Step,
                _snake[0].Location.Y + _model.CurrentDirection.Y * _model.Step);
        }
        
        private void SnakeDeath()
        {
            for (int j = _snake.Count - 1; j > 2; j--)
            {
                _view.RemoveControl(_snake[j]);
                _snake.Remove(_snake[j]);
            }
            _view.SetScore(CalcScore());
        }
        
        private void EatAnApple()
        {
            if (_snake[0].Location == _apple.Location)
            {
                _apple.Location = new Point(32 * _rand.Next(1, 19), 32 * _rand.Next(1, 19));
                var location = new Point(_snake.Last().Location.X, _snake.Last().Location.Y);
                _snake.Add(CreateSnakePart(location));
                _view.AddControl(_snake.Last());
                _view.SetScore(CalcScore());
            }
        }
        
        private void SnakeStartingPoint()
        {
            SnakeDeath();
            _snake[0].Location = new Point(96, 64);
            _snake[1].Location = new Point(64, 64);
            _snake[2].Location = new Point(32, 64);
            _model.SetDefaultDirection();
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