using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ping_Pong_Game
{
    public partial class Form1 : Form
    {
        public int speed_left = 4;               //Speed of the ball
        public int speed_top = 4;
        public int point = 0;                     //Score
        Random rnd = new Random();
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            Cursor.Hide();                                 //Hiding the cursor
            this.FormBorderStyle = FormBorderStyle.None;   //Removing the border
            //this.TopMost = true;                           //bring the form to the top
            this.Bounds = Screen.PrimaryScreen.Bounds;     //make it fullscreen
            racket.Top = playground.Bottom - (playground.Bottom / 10); //setting position of racket

            Gameover.Visible = false;//hiding the label
            Gameover.Left = playground.Width / 2-Gameover.Width/2;
            Gameover.Top = playground.Height / 2-Gameover.Height/2;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2); //setting the center of the racket to the position of the cursor

            ball.Left = ball.Left + speed_left;  //moving the ball
            ball.Top = ball.Top + speed_top;

            if (ball.Left >= racket.Left && ball.Bottom <= racket.Bottom && ball.Bottom >= racket.Top && ball.Right <= racket.Right) //Collision condition
            {
                speed_top = speed_top + 2;
                speed_left = speed_left + 2;

                //change direction
                speed_top = -speed_top;

                //updating Score
                point = point + 1;

                //showing Score
                points.Text = point.ToString();

                //changing Color
                Color randomColor = Color.FromArgb(rnd.Next(150,255), rnd.Next(150,255), rnd.Next(150,255));
                playground.BackColor = randomColor;

            }

            if (ball.Left <= playground.Left)
            {
                speed_left = -speed_left;
            }

            if (ball.Right >= playground.Right)
            {
                speed_left = -speed_left;
            }

            if (ball.Top <= playground.Top)
            {
                speed_top = -speed_top;
            }

            if (ball.Bottom >= playground.Bottom)
            {
                timer1.Enabled = false;
                Gameover.Visible = true;
            }

        }


        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            if(e.KeyCode==Keys.F5)
            {
                ball.Top = 50;
                ball.Left = 50;
                speed_left = 4;
                speed_top = 4;
                point = 0;
                //points.Text = "0";

                timer1.Enabled = true;
                Gameover.Visible = false ;
            }
        }








    }
}
