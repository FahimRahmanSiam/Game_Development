using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trickyBird
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int gravity = 10;
        int speed = 25;
        int score = 0;
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                gravity = 25;
            
        } 

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                gravity = -25;
            
            else if(e.KeyCode == Keys.Enter)
                timer1.Start();
            
        }
        Random rnd = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            bird.Top += gravity;
            pipeDown.Left -= speed;
            pipeUp.Left -= speed;
            weather.Left -= speed;
            gameScore.Text = $"Score: {score}";
            if (pipeDown.Left < -170)
            {
                pipeDown.Left = rnd.Next(300, 600);
                score++;
            }
            if (pipeUp.Left < -170)
            {
                int top= rnd.Next(300, 700);
                pipeUp.Left = top;
                weather.Left = rnd.Next(top + 50, 770);
                score++;
            }
            if(bird.Bounds.IntersectsWith(pipeDown.Bounds) || bird.Bounds.IntersectsWith(pipeUp.Bounds) || bird.Bounds.IntersectsWith(ground.Bounds))
            {
                timer1.Stop();
                gameScore.Text += "  Gameover!!!";
            }
            if (score > 5)
            {             
                speed += 2;
            }
            if (score > 10)
            {
                speed += 2;
            }
            if (score > 15)
            {
                speed += 2;
            }
            if (score > 25)
            {
                speed += 2;
            }
        }
    }
}
