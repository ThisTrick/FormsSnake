using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsSnake
{
    public partial class Form1 : Form
    {
        public const int Space = 576;
        public Point directionSnake  = new Point(32, 0);
        public Point pointSnake0;
        public Point pointSnake1;
        public Point pointSnake2;

        public Form1()
        {
            InitializeComponent();
            pointSnake0 = new Point(96, 64);
            pointSnake1 = new Point(64, 64);
            pointSnake2 = new Point(32, 64);
            Snake0.Location = pointSnake0;
            Snake1.Location = pointSnake1;
            Snake2.Location = pointSnake2;

        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.W)
            {
                if(directionSnake != new Point(0, 32))
                {
                    directionSnake = new Point(0, -32);
                }  
            }
            else if (e.KeyData == Keys.S)
            {
                if (directionSnake != new Point(0, -32))
                {
                    directionSnake = new Point(0, 32);
                }
            }
            else if (e.KeyData == Keys.A)
            {
                if (directionSnake != new Point(32, 0))
                {
                    directionSnake = new Point(-32, 0);
                }
                
            }
            else if (e.KeyData == Keys.D)
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
            if (Snake0.Location.X <= Space && Snake0.Location.Y <= Space && Snake0.Location.X >= 0 && Snake0.Location.Y >= 0)
            {
                pointSnake2 = Snake1.Location;
                pointSnake1 = Snake0.Location;
                pointSnake0.X += directionSnake.X;
                pointSnake0.Y += directionSnake.Y;
                Snake0.Location = pointSnake0;
                Snake1.Location = pointSnake1;
                Snake2.Location = pointSnake2;
            }
            else
            {
                if (Snake0.Location.X > Space)
                {
                    if(Snake0.Location.Y == Space)
                    {
                        pointSnake0.Y -= 32;
                    }
                    else
                    {
                        pointSnake0.Y += 32;
                    }
                    pointSnake0.X -= 32;
                    directionSnake = new Point(-32, 0);
                }
                else if (Snake0.Location.X < 0)
                {
                    if (Snake0.Location.Y == Space)
                    {
                        pointSnake0.Y -= 32;
                    }
                    else
                    {
                        pointSnake0.Y += 32;
                    }
                    
                    pointSnake0.X += 32;
                    directionSnake = new Point(32, 0);
                }
                else if (Snake0.Location.Y > Space)
                {
                    if (Snake0.Location.X == Space)
                    {
                        pointSnake0.X -= 32;
                    }
                    else
                    {
                        pointSnake0.X += 32;
                    }
                    pointSnake0.Y -= 32;
                    directionSnake = new Point(0, -32);
                }
                else if (Snake0.Location.Y < 0)
                {
                    if (Snake0.Location.X == Space)
                    {
                        pointSnake0.X -= 32;
                    }
                    else
                    {
                        pointSnake0.X += 32;
                    }
                    pointSnake0.Y += 32;
                    directionSnake = new Point(0, 32);
                }
                else
                {
                    MessageBox.Show("Ты дебил");
                }

                Snake0.Location = pointSnake0;
                Snake1.Location = pointSnake1;
                Snake2.Location = pointSnake2;
            }
        }
    }
}
