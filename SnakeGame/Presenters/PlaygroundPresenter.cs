using System;
using System.Collections.Generic;
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
        
        private List<Panel> _snake;
        private Panel _apple;

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
            _snake = new List<Panel>() {
                CreateSnakeItem(new Point(96, 64)),
                CreateSnakeItem(new Point(64, 64)),
                CreateSnakeItem(new Point(32, 64)),
            };
            _apple = CreateApplePanel(new Point(96, 96));
            _view.SetScore(CalcScore());
        }
        
        private Panel CreateSnakeItem(Point location)
        {
            var snakeItem = CreatePanel(location);
            snakeItem.BackColor = SystemColors.Info;
            return snakeItem;
        }
        
        private Panel CreatePanel(Point location)
        {
            var panel = new Panel();
            panel.Size = new Size(26, 26);
            panel.Location = location;
            _view.AddControl(panel);
            return panel;
        }
        
        
        private Panel CreateApplePanel(Point location)
        {
            var applePanel = CreatePanel(location);
            applePanel.BackColor = SystemColors.Highlight;
            applePanel.Name = "Apple";
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
                var location = new Point(_snake[_snake.Count - 2].Location.X, _snake[_snake.Count - 2].Location.Y);
                _snake.Add(CreateSnakeItem(location));
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