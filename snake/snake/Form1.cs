using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public partial class Form1 : Form
    {
        private List<Circle> Snake = new List<Circle>();
        private Circle food = new Circle();
        private int maxXPos;
        private int maxYPos;
        public Form1()
        {
            InitializeComponent();
            new Settings();
            maxXPos = pbCanvas.Size.Width / Settings.Width;
            maxXPos = pbCanvas.Size.Height / Settings.Height;
            GameTimer.Interval = 1000 / Settings.Speed;
            GameTimer.Tick += UbdateScreen;
            GameTimer.Start();
        }
        private void StartGame()
        {
            lblGameOver.Visible = false;
            Snake.Clear();
            Circle head = new Circle();
            head.x  = 10;
            head.y = 5;
            Snake.Add(head);
            new Settings();
            Label1.Text = Settings.Score.ToString();
            GenerateFood();
        }
        private void GenerateFood()
        {
            Random rnd = new Random();
            Circle food = new Circle();
            food.x = rnd.Next(0, maxXPos);
            food.y = rnd.Next(0, maxYPos);
        }        
        private void UbdateScreen(object sender,EventArgs e)
        {

        }
       private void pbCanvas_Paint(object sender, PaintEventArgs e)
       {

       }
       private void MovePlaer()
       {
            for(int i = Snake.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (Settings.direction)
                    {
                        case Direction.Right:
                            Snake[i].x++;
                            break;
                        case Direction.Left:
                            Snake[i].x--;
                            break;
                        case Direction.Down:
                            Snake[i].y++;
                            break;
                        case Direction.Up:
                            Snake[i].y--;
                            break;
                    }
                    if (Snake[i].x < 0 || Snake[i].y < 0 || Snake[i].x >= maxXPos || Snake[i].y >= maxXPos)
                    {
                        Die();
                    }
                    for(int j = 1; j < Snake.Count; j++)
                    {
                        if(Snake[i].x==Snake[j].x && Snake[i].y == Snake[j].y)
                        {
                            Die();
                        }
                    } 
                    if(Snake[i].y==food.y && Snake[i].x == food.x)
                    {
                        eat();
                    }
                    else
                    {
                        Snake[i].x = Snake[i + 1].x;
                        Snake[i].y = Snake[i + 1].y;
                    }
                }
            }
       }
        private void Die()
        {
            Settings.GameOver = true;
        }
        private void eat()
        {
            Circle food = new Circle();
            food.x = Snake[Snake.Count - 1].x;
            food.y= Snake[Snake.Count - 1].y;
            Snake.Add(food);
            Settings.Score += Settings.Points;
            Label1.Text = "Score: " + Settings.Score.ToString();
            GenerateFood();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pbCanvas_paint(object sender, PaintEventArgs e)
        {

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
