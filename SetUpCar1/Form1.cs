using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SetUpCar1
{
    public partial class Form1 : Form
    {
        int Car_image;
        int score;
        int PlaySpeed = 12;
        int Map_speed;
        int OtherCars_speed;

        //From the start player is starting with this setting of the car:
        String Engine; 
        String Suspension;
        String Tires;

        bool left;
        bool right;

        Random idk = new Random();
        Random Car_place = new Random();


        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            ResetGame();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Button_start_MouseHover(object sender, EventArgs e)
        {
            Button_start.Image = Properties.Resources.img1;
        }

        private void Button_start_MouseLeave(object sender, EventArgs e)
        {
            Button_start.Image = Properties.Resources.img2;
        }

        private void Button_options_MouseHover(object sender, EventArgs e)
        {
            Button_options.Image = Properties.Resources.img3;
        }

        private void Button_options_MouseLeave(object sender, EventArgs e)
        {
            Button_options.Image = Properties.Resources.img4;
        }

        private void Button_exit_MouseHover(object sender, EventArgs e)
        {
            Button_exit.Image = Properties.Resources.img5;
        }

        private void Button_exit_MouseLeave(object sender, EventArgs e)
        {
            Button_exit.Image = Properties.Resources.img6;
        }

        private void Button_start_Click(object sender, EventArgs e)
        {
            Main.SelectTab(2);
        }

        private void Button_options_Click(object sender, EventArgs e)
        {
            Main.SelectTab(1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Main.SelectTab(0);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Main.SelectTab(0);
        }

        private void key_up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = false;
            }
        }

        private void key_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                left = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                right = true;
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void TickTimer(object sender, EventArgs e)
        {

        }

        private void SwipingCars(PictureBox tempCar)
        {
            Car_image = idk.Next(1, 5);

            switch (Car_image)
            {
                case 1:
                    tempCar.Image = Properties.Resources._44;
                    break;
                case 2:
                    tempCar.Image = Properties.Resources._222;
                    break;
                case 3:
                    tempCar.Image = Properties.Resources._9;
                    break;
                case 4:
                    tempCar.Image = Properties.Resources._33;
                    break;
            }

            tempCar.Top = 0;
            if (tempCar.Tag.ToString() == "LeftCar")
            {
                tempCar.Location = new Point(Car_place.Next(5, 200),tempCar.Location.Y);
            }
            if (tempCar.Tag.ToString() == "RightCar")
            {
                tempCar.Location = new Point(Car_place.Next(240, 420),tempCar.Location.Y);
            }
        }

        private void ResetGame()
        {
            /*start_game.Enabled = false;
            award.Visible = false;
            left = false;
            right = false;
            score = 0;


            Map_speed = 12;
            OtherCars_speed = 15;

            Car1.Top = Car_place.Next(200, 500) * -1;
            Car1.Left = Car_place.Next(5, 200);

            Car2.Top = Car_place.Next(200, 500) * -1;
            Car2.Left = Car_place.Next(240, 420);

          */ 

        }

        private void GameOver()
        {
            timer1.Stop();
            award.Visible = true;
            scoreLabTxt.Visible = true;
            start_game.Enabled = true;
        }

        private void GameTimer(object sender, EventArgs e)
        {
            scoreLabTxt.Text = "Score = " + score;
            score++;

            if (left == true && Play.Left > 5)
            {
                Play.Left -= PlaySpeed;
            }
            if (right == true && Play.Left < 430)
            {
                Play.Left += PlaySpeed;
            }

            Map1.Top += Map_speed;
            Map2.Top += Map_speed;
            
            if (Map2.Top > 519)
            {
                Map2.Top = -519;
            }
            if (Map1.Top > 519)
            {
                Map1.Top = -519;
            }
            
            Car1.Top += OtherCars_speed;
            Car2.Top += OtherCars_speed;

            if (Car1.Top > 530)
            {
                //SwipingCars(Car1);
                SwipingCars(Car1);
            }
            if (Car2.Top > 530)
            {
                SwipingCars(Car2);
            }

            if (Play.Bounds.IntersectsWith(Car1.Bounds) || Play.Bounds.IntersectsWith(Car2.Bounds))
            {
                GameOver();
            }

            if(score > 50 && score < 1000)
            {
                award.Image = Properties.Resources.bronze;
            }

            if(score > 1000 && score < 2500)
            {
                award.Image = Properties.Resources.silver;

            }

            if(score > 2500)
            {
                award.Image = Properties.Resources.gold;
            }

        }

        private void Button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_MouseHover(object sender, EventArgs e)
        {
            Button_Back.Image = Properties.Resources._2;
        }

        private void Button_Back_MouseLeave(object sender, EventArgs e)
        {
            Button_Back.Image = Properties.Resources._1;
        }

        private void start_game_MouseLeave(object sender, EventArgs e)
        {
            start_game.Image = Properties.Resources._11;
        }

        private void pictureBox6_MouseHover(object sender, EventArgs e)
        {
            butt_back.Image = Properties.Resources._2;
        }

        private void butt_back_MouseLeave(object sender, EventArgs e)
        {
            butt_back.Image = Properties.Resources._1;
        }

        private void start_game_MouseHover_1(object sender, EventArgs e)
        {
            start_game.Image = Properties.Resources._3;
        }

        private void start_game_Click(object sender, EventArgs e)
        {

            start_game.Enabled = false;
            award.Visible = false;
            left = false;
            right = false;
            score = 0;


            Map_speed = 12;
            OtherCars_speed = 15;

            Car1.Top = Car_place.Next(200, 500) * -1;
            Car1.Left = Car_place.Next(5, 200);

            Car2.Top = Car_place.Next(200, 500) * -1;
            Car2.Left = Car_place.Next(240, 420);

            timer1.Start();
        }

        private void pic_2jz_Click(object sender, EventArgs e)
        {
            Engine = "2jz";
        }

        private void pic_rb26_Click(object sender, EventArgs e)
        {
            Engine = "rb26";
        }

        private void pic_dw13_Click(object sender, EventArgs e)
        {
            Engine = "dw13";
        }
    }
}
