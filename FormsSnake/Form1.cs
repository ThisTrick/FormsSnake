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
        private const int Space = 576;
        public Point directionSnake = new Point(32, 0);
        public Point hide = new Point(600, 600);
        public int lengthSnake = 2;

        public List<Panel> snake = new List<Panel>();
        public List<Point> pointsSnake = new List<Point>();
        public Random rand = new Random(Guid.NewGuid().GetHashCode());

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        extern static void ReleaseCapture();
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);



        public Form1()
        {
            InitializeComponent();
            IEnumerable<Control> controls = Controls.Cast<Control>();
            snake.AddRange(controls.Where(x => x.Name.Contains("snake") && x is Panel).ToArray().Cast<Panel>().Reverse());

            pointsSnake.AddRange(
                new[]{
                new Point(96, 64),
                new Point(64, 64),
                new Point(32, 64)
                });
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
                if (directionSnake != new Point(0, 32))
                {
                    directionSnake = new Point(0, -32);
                }
            }
            else if (e.KeyData == Keys.S || e.KeyData == Keys.Down)
            {
                if (directionSnake != new Point(0, -32))
                {
                    directionSnake = new Point(0, 32);
                }
            }
            else if (e.KeyData == Keys.A || e.KeyData == Keys.Left)
            {
                if (directionSnake != new Point(32, 0))
                {
                    directionSnake = new Point(-32, 0);
                }
            }
            else if (e.KeyData == Keys.D || e.KeyData == Keys.Right)
            {
                if (directionSnake != new Point(-32, 0))
                {
                    directionSnake = new Point(32, 0);
                }
            }
            else if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void SnakeGo_Tick(object sender, EventArgs e)
        {
            
            if (snake0.Location.X <= Space && snake0.Location.Y <= Space && snake0.Location.X >= 0 && snake0.Location.Y >= 0)
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
                    
                    Apple.Location = new Point(32 * rand.Next(1, 19), 32 * rand.Next(1, 19));

                    if(lengthSnake < snake.Count - 1)
                    {
                        lengthSnake += 1;
                        label1.Text = (lengthSnake - 2).ToString();
                        pointsSnake.Add(new Point(snake[lengthSnake - 1].Location.X, snake[lengthSnake - 1].Location.Y));
                        snake[lengthSnake].Location = pointsSnake[lengthSnake];
                    }
                }
            }
            else
            {
                if (snake[0].Location.X > Space)
                {
                    if (snake[0].Location.Y == Space)
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
                    if (snake[0].Location.Y == Space)
                    {
                        pointsSnake[0] = new Point(pointsSnake[0].X + 32, pointsSnake[0].Y - 32);
                    }
                    else
                    {
                        pointsSnake[0] = new Point(pointsSnake[0].X + 32, pointsSnake[0].Y + 32);
                    }
                    
                    directionSnake = new Point(32, 0);
                }
                else if (snake[0].Location.Y > Space)
                {
                    if (snake[0].Location.X == Space)
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
                    if (snake[0].Location.X == Space)
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
                    MessageBox.Show("Ты дебил");
                }
                for(int i = lengthSnake; i >= 0; i--)
                {
                    snake[i].Location = pointsSnake[i];
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {           
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
