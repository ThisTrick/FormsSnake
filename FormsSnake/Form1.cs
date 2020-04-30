using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace FormsSnake
{
    public partial class Form1 : Form
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

        private int space;
        private Point directionSnake;
        private List<Panel> snake;
        private Panel apple;
        public Random rand;

        private Point directionLeft;
        private Point directionRight;
        private Point directionTop;
        private Point directionBottom;

        public Form1()
        {
            InitializeComponent();

            space = 576;
            directionLeft = new Point(32, 0);
            directionRight = new Point(-32, 0);
            directionTop = new Point(0, -32);
            directionBottom = new Point(0, 32);
            directionSnake = directionLeft;
            snake = new List<Panel>() {
                CreateSnakeItem(new Point(96, 64)),
                CreateSnakeItem(new Point(64, 64)),
                CreateSnakeItem(new Point(32, 64)),
            };
            rand = new Random(Guid.NewGuid().GetHashCode());
            apple = CreateApplePanel(new Point(96, 96));
            Count.Text = (snake.Count() - 3).ToString();
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
                if (directionSnake != directionBottom)
                {
                    directionSnake = directionTop;
                }
            }
            else if (e.KeyData == Keys.S || e.KeyData == Keys.Down)
            {
                if (directionSnake != directionTop)
                {
                    directionSnake = directionBottom;
                }
            }
            else if (e.KeyData == Keys.A || e.KeyData == Keys.Left)
            {
                if (directionSnake != directionLeft)
                {
                    directionSnake = directionRight;
                }
            }
            else if (e.KeyData == Keys.D || e.KeyData == Keys.Right)
            {
                if (directionSnake != directionRight)
                {
                    directionSnake = directionLeft;
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
            if (snake[0].Location.X <= space && snake[0].Location.Y <= space && snake[0].Location.X >= 0 && snake[0].Location.Y >= 0)
            {
                SnakeMoving();
                SnakeDeath();
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
        /// Удар змейки об себя.
        /// Теряет все блоки кроме первых 3.
        /// </summary>
        private void SnakeDeath()
        {
            for (int i = snake.Count() - 1; i > 0; i--)
            {
                if (snake[0].Location == snake[i].Location)
                {
                    SnakeHide();
                    break;
                }
            }
        }
        /// <summary>
        /// Скрывает компоненты змейки.
        /// </summary>
        private void SnakeHide()
        {
            for (int j = snake.Count() - 1; j > 2; j--)
            {
                Controls.Remove(snake[j]);
                snake.Remove(snake[j]);
            }
            Count.Text = (snake.Count() - 3).ToString();
        }

        /// <summary>
        /// Реализация передвижения змейки.
        /// </summary>
        private void SnakeMoving()
        {
            for (int i = snake.Count() - 1; i > 0; i--)
            {
                var tmp = snake[i - 1].Location;
                snake[i].Location = tmp;
            }
            snake[0].Location = new Point(snake[0].Location.X + directionSnake.X, snake[0].Location.Y + directionSnake.Y);
        }

        /// <summary>
        /// Реализация логики поедания яблока змеей. 
        /// </summary>
        private void EatAnApple()
        {
            if (snake[0].Location == apple.Location)
            {
                apple.Location = new Point(32 * rand.Next(1, 19), 32 * rand.Next(1, 19));
                var location = new Point(snake[snake.Count() - 2].Location.X, snake[snake.Count() - 2].Location.Y);
                snake.Add(CreateSnakeItem(location));
                Count.Text = (snake.Count() - 3).ToString();
            }
        }

        /// <summary>
        /// Задает начальное положение Змейки.
        /// </summary>
        private void SnakeStartingPoint()
        {
            SnakeHide();
            snake[0].Location = new Point(96, 64);
            snake[1].Location = new Point(64, 64);
            snake[2].Location = new Point(32, 64);
            directionSnake = directionLeft;
        }
    }
}
