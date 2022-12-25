using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FormsSnake
{
    public partial class PlaygroundView : Form
    {
        #region Перемещение окна
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        
        
        private readonly int _space;
        private Point _directionSnake;
        private readonly List<Panel> _snake;
        private readonly Panel _apple;
        private readonly Random _rand;
        private readonly Point _directionLeft;
        private readonly Point _directionRight;
        private readonly Point _directionTop;
        private readonly Point _directionBottom;

        public PlaygroundView()
        {
            InitializeComponent();

            _space = 576;
            _directionLeft = new Point(32, 0);
            _directionRight = new Point(-32, 0);
            _directionTop = new Point(0, -32);
            _directionBottom = new Point(0, 32);
            _directionSnake = _directionLeft;
            _snake = new List<Panel>() {
                CreateSnakeItem(new Point(96, 64)),
                CreateSnakeItem(new Point(64, 64)),
                CreateSnakeItem(new Point(32, 64)),
            };
            _rand = new Random(Guid.NewGuid().GetHashCode());
            _apple = CreateApplePanel(new Point(96, 96));
            Count.Text = (_snake.Count() - 3).ToString();
        }

        /// <summary>
        /// Управление змейкой.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W || e.KeyData == Keys.Up)
            {
                if (_directionSnake != _directionBottom)
                {
                    _directionSnake = _directionTop;
                }
            }
            else if (e.KeyData == Keys.S || e.KeyData == Keys.Down)
            {
                if (_directionSnake != _directionTop)
                {
                    _directionSnake = _directionBottom;
                }
            }
            else if (e.KeyData == Keys.A || e.KeyData == Keys.Left)
            {
                if (_directionSnake != _directionLeft)
                {
                    _directionSnake = _directionRight;
                }
            }
            else if (e.KeyData == Keys.D || e.KeyData == Keys.Right)
            {
                if (_directionSnake != _directionRight)
                {
                    _directionSnake = _directionLeft;
                }
            }
            else if (e.KeyData == Keys.Escape)
            {
                Close();
            }
        }

        /// <summary>
        /// Основной таймер, задающий игровой процесс
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SnakeGo_Tick(object sender, EventArgs e)
        {
            if (_snake[0].Location.X <= _space && _snake[0].Location.Y <= _space && _snake[0].Location.X >= 0 && _snake[0].Location.Y >= 0)
            {
                SnakeMoving();
                EatAnApple();
            }
            else
            {
                SnakeStartingPoint();
            }
        }
        /// <summary>
        /// Создает Яблоко типа Panel 
        /// </summary>
        /// <param name="location">Локация объекта Panel</param>
        /// <returns></returns>
        private Panel CreateApplePanel(Point location)
        {
            var applePanel = CreatePanel(location);
            applePanel.BackColor = SystemColors.Highlight;
            applePanel.Name = "Apple";
            return applePanel;
        }
        /// <summary>
        /// Создает панель для части змейки. 
        /// </summary>
        /// <param name="location">Локация объекта Panel</param>
        /// <returns></returns>
        private Panel CreateSnakeItem(Point location)
        {
            var snakeItem = CreatePanel(location);
            snakeItem.BackColor = SystemColors.Info;
            return snakeItem;
        }
        /// <summary>
        /// Создает панель по шаблону.
        /// </summary>
        /// <param name="location">Локация объекта Panel</param>
        /// <returns></returns>
        private Panel CreatePanel(Point location)
        {
            var panel = new Panel();
            panel.Size = new Size(26, 26);
            panel.Location = location;
            Controls.Add(panel);
            return panel;
        }

        /// <summary>
        /// Смерть змейки.
        /// Теряет все блоки кроме первых 3.
        /// </summary>
        private void SnakeDeath()
        {
            for (int j = _snake.Count() - 1; j > 2; j--)
            {
                Controls.Remove(_snake[j]);
                _snake.Remove(_snake[j]);
            }
            Count.Text = (_snake.Count() - 3).ToString();
        }

        /// <summary>
        /// Реализация передвижения змейки.
        /// </summary>
        private void SnakeMoving()
        {
            for (int i = _snake.Count() - 1; i > 0; i--)
            {
                var tmp = _snake[i - 1].Location;
                _snake[i].Location = tmp;
                if (i != 1 && _snake[0].Location == _snake[i].Location)
                {
                    SnakeDeath();
                    return;
                }
            } 
            _snake[0].Location = new Point(_snake[0].Location.X + _directionSnake.X, _snake[0].Location.Y + _directionSnake.Y);
        }

        /// <summary>
        /// Реализация логики поедания яблока змеей. 
        /// </summary>
        private void EatAnApple()
        {
            if (_snake[0].Location == _apple.Location)
            {
                _apple.Location = new Point(32 * _rand.Next(1, 19), 32 * _rand.Next(1, 19));
                var location = new Point(_snake[_snake.Count() - 2].Location.X, _snake[_snake.Count() - 2].Location.Y);
                _snake.Add(CreateSnakeItem(location));
                Count.Text = (_snake.Count() - 3).ToString();
            }
        }

        /// <summary>
        /// Задает начальное положение Змейки.
        /// </summary>
        private void SnakeStartingPoint()
        {
            SnakeDeath();
            _snake[0].Location = new Point(96, 64);
            _snake[1].Location = new Point(64, 64);
            _snake[2].Location = new Point(32, 64);
            _directionSnake = _directionLeft;
        }
    }
}
