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
        private Point hide;
        private int lengthSnake;
        private List<Panel> snake;
        public List<Point> pointsSnake;
        public Random rand;

        private Point directionLeft;
        private Point directionRight;
        private Point directionTop;
        private Point directionBottom;

        public Form1()
        {
            InitializeComponent();
            space = 576;
            directionSnake = new Point(32, 0);
            hide = new Point(600, 600);
            lengthSnake = 2;
            snake = new List<Panel>();
            pointsSnake = new List<Point>(){
                new Point(96, 64),
                new Point(64, 64),
                new Point(32, 64)
                };
            rand = new Random(Guid.NewGuid().GetHashCode());

            directionLeft = new Point(32, 0);
            directionRight = new Point(-32, 0);
            directionTop = new Point(0, -32);
            directionBottom = new Point(0, 32);


            IEnumerable<Control> controls = Controls.Cast<Control>();
            snake.AddRange(controls.Where(x => x.Name.Contains("snake") && x is Panel).ToArray().Cast<Panel>().Reverse());

            for (int i = 2; i <= 50; i++)
            {
                pointsSnake.Add(hide);
            }

            for (int i = 0; i <= 50; i++)
            {
                snake[i].Location = pointsSnake[i];
            }

            label1.Text = (lengthSnake - 2).ToString();
            Apple.Location = new Point(96, 96);

        }


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

        private void SnakeGo_Tick(object sender, EventArgs e)
        {
            
            if (snake0.Location.X <= space && snake0.Location.Y <= space && snake0.Location.X >= 0 && snake0.Location.Y >= 0)
            {
                for (int i = lengthSnake; i >= 0 ; i--)
                {
                    if (i == 0)
                    {
                        pointsSnake[i] = new Point(pointsSnake[i].X + directionSnake.X, pointsSnake[i].Y + directionSnake.Y);
                    }
                    else
                    {
                        pointsSnake[i] = snake[i - 1].Location;
                    }
                    snake[i].Location = pointsSnake[i];
                    
                }

                for(int i = lengthSnake; i > 0; i--)
                {
                    if(pointsSnake[0] == pointsSnake[i])
                    {
                        for (int j = 50; j > 2; j--)
                        {
                            snake[j].Location = hide;
                            pointsSnake[j] = hide;
                        }
                        lengthSnake = 2;
                        label1.Text = (lengthSnake - 2).ToString();
                        break;
                    }
                }


                if (snake0.Location == Apple.Location)
                {
                    EatAnApple();
                }
            }
            else
            {
                if (snake[0].Location.X > space)
                {
                    if (snake[0].Location.Y == space)
                    {
                        pointsSnake[0] =  new Point(pointsSnake[0].X - 32, pointsSnake[0].Y - 32);
                    }
                    else
                    {
                        pointsSnake[0] = new Point(pointsSnake[0].X - 32, pointsSnake[0].Y + 32);
                    }
                    directionSnake = new Point(-32, 0);
                }
                else if (snake[0].Location.X < 0)
                {
                    if (snake[0].Location.Y == space)
                    {
                        pointsSnake[0] = new Point(pointsSnake[0].X + 32, pointsSnake[0].Y - 32);
                    }
                    else
                    {
                        pointsSnake[0] = new Point(pointsSnake[0].X + 32, pointsSnake[0].Y + 32);
                    }
                    
                    directionSnake = new Point(32, 0);
                }
                else if (snake[0].Location.Y > space)
                {
                    if (snake[0].Location.X == space)
                    {
                        pointsSnake[0] = new Point(pointsSnake[0].X - 32, pointsSnake[0].Y - 32);
                    }
                    else
                    {
                        pointsSnake[0] = new Point(pointsSnake[0].X + 32, pointsSnake[0].Y - 32);
                    }
                    directionSnake = new Point(0, -32);
                }
                else if (snake[0].Location.Y < 0)
                {
                    if (snake[0].Location.X == space)
                    {
                        pointsSnake[0] = new Point(pointsSnake[0].X - 32, pointsSnake[0].Y + 32);
                    }
                    else
                    {
                        pointsSnake[0] = new Point(pointsSnake[0].X + 32, pointsSnake[0].Y + 32);
                    }
                    directionSnake = new Point(0, 32);
                }
                else
                {
                    throw new ApplicationException();
                }

                for(int i = lengthSnake; i >= 0; i--)
                {
                    snake[i].Location = pointsSnake[i];
                }
            }
        }
        /// <summary>
        /// Реализация логики поедания яблока змеей. 
        /// </summary>
        private void EatAnApple()
        {
            Apple.Location = new Point(32 * rand.Next(1, 19), 32 * rand.Next(1, 19));

            if (lengthSnake < snake.Count - 1)
            {
                lengthSnake += 1;
                label1.Text = (lengthSnake - 2).ToString();
                pointsSnake.Add(new Point(snake[lengthSnake - 1].Location.X, snake[lengthSnake - 1].Location.Y));
                snake[lengthSnake].Location = pointsSnake[lengthSnake];
            }
        }
    }
}
