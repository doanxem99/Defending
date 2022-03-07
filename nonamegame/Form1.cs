using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nonamegame
{
    public partial class Form1 : Form
    {
        private int speed = 5, speedEnemy = 1, timedelayBullet = 0, limitdelayBullet = 25, timedelayTele = 0, limitdelayTele = 200,
                    timedelayEnemy = 0, limitdelayEnemy = 50, score = 0, difficult = 0, postionXMouse = 0, positionYMouse = 0;
        private bool goLeft = false, goRight = false, goUp = false, goDown = false, shoot = false, teleport1 = false, teleport2 = false;
        private Random random = new Random();
        private Timer timer = new Timer();
        private int[] locy = new int[2];
        private int[] locx = new int[2];
        private List<PictureBox> BULLET_pictureboxes = new List<PictureBox>();
        private List<PictureBox> ENEMY_pictureboxes = new List<PictureBox>();
        private List<Bullet> bulletDir = new List<Bullet>();
        private List<Enemy> enemyOut = new List<Enemy>();
        private List<Color> colors = new List<Color>();
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            //   this.MouseDown += Form1_MouseDown;
            //   this.MouseUp += Form1_MouseUp;
            colors.Add(Color.White);
            colors.Add(Color.Violet);
            colors.Add(Color.Brown);
            colors.Add(Color.Magenta);
            colors.Add(Color.DarkSeaGreen);
            colors.Add(Color.Orange);
            Init_Game();
            Start_Game();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.Text = "nonamegame";
        }
        private void Init_Game()
        {
            for (int i = 0; i < enemyOut.Count; i++)
            {
                enemyOut[i].Out = true;
                ENEMY_pictureboxes[i].Visible = false;
            }

            for (int i = 0; i < bulletDir.Count; i++)
            {
                bulletDir[i].finish = true;
                BULLET_pictureboxes[i].Visible = false;
            }
            limitdelayEnemy = 50;
            speedEnemy = 1;
            score = 0;
            SCORE_label.Text = "SCORE : " + score;
            TANK_picturebox.Left = 450;
            TANK_picturebox.Top = 450;
        }
        private void Start_Game()
        {
            Init_Game();
            timer.Interval = 20;
            timer.Tick += Run_Game;
            timer.Start();
        }
        private void Run_Game(object sender, EventArgs e)
        {
            timedelayBullet++;
            timedelayEnemy++;
            timedelayTele++;
            //Appear enemy around the tank
            if (timedelayEnemy > limitdelayEnemy)
            {
                Appear_Enemy();
                timedelayEnemy = 0;
            }
            if (timedelayTele > limitdelayTele && teleport1 && teleport2)
            {
                TANK_picturebox.Location = new Point(postionXMouse, positionYMouse);
                timedelayTele = 0;
            }
            Moving_Enemy();
            Moving_Tank();
            Check_Shooting();

        }
        private void Moving_Enemy()
        {
            for (int i = 0; i < ENEMY_pictureboxes.Count; i++)
            {
                if (!enemyOut[i].Out)
                {
                    double x = (double)(enemyOut[i].locX + (1.0 * ENEMY_pictureboxes[i].Size.Width / 2));
                    double y = (double)(enemyOut[i].locY + (1.0 * ENEMY_pictureboxes[i].Size.Height / 2));
                    double xx = (double)(1.0 * TANK_picturebox.Left + (1.0 * TANK_picturebox.Size.Width / 2));
                    double yy = (double)(1.0 * TANK_picturebox.Top + (1.0 * TANK_picturebox.Size.Height / 2));
                    double speedEnemy2 = (double)speedEnemy;
                    double z = Math.Sqrt(((xx - x) * (xx - x)) + ((yy - y) * (yy - y)));
                    enemyOut[i].locX = (double)(1.0 * enemyOut[i].locX + (1.0 * Math.Sin((xx - x) / z) * speedEnemy2));

                    enemyOut[i].locY = (double)(1.0 * enemyOut[i].locY + (1.0 * Math.Sin((yy - y) / z) * speedEnemy2));

                    ENEMY_pictureboxes[i].Left = (int)Math.Round(enemyOut[i].locX);
                    ENEMY_pictureboxes[i].Top = (int)Math.Round(enemyOut[i].locY);

                    if (TANK_picturebox.Bounds.IntersectsWith(ENEMY_pictureboxes[i].Bounds))
                    {
                        timer.Stop();
                    }
                }
            }
        }
        private void Moving_Tank()
        {
            if (goLeft == true)
                TANK_picturebox.Left -= (TANK_picturebox.Left - speed < 0) ? (TANK_picturebox.Left) : speed;

            if (goRight == true)
                TANK_picturebox.Left += (TANK_picturebox.Left + speed + TANK_picturebox.Size.Width > BACKGROUND_picturebox.Size.Width)
                                        ? (BACKGROUND_picturebox.Size.Width - TANK_picturebox.Left - TANK_picturebox.Size.Width) : speed;

            if (goUp == true)
                TANK_picturebox.Top -= (TANK_picturebox.Top - speed < 0) ? (TANK_picturebox.Top) : speed;

            if (goDown == true)
                TANK_picturebox.Top += (TANK_picturebox.Top + speed + TANK_picturebox.Size.Height > BACKGROUND_picturebox.Size.Height)
                                    ? (BACKGROUND_picturebox.Size.Height - TANK_picturebox.Top - TANK_picturebox.Size.Height) : speed;
        }
        private void Appear_Enemy()
        {
            int temp = -1;
            for (int i = 0; i < enemyOut.Count; i++)
            {
                if (enemyOut[i].Out)
                {
                    temp = i;
                    break;
                }
            }
            PictureBox enemy = new PictureBox();
            int tempX, tempY;
            do
            {
                tempX = random.Next(-130, BACKGROUND_picturebox.Size.Width + 130);
                tempY = random.Next(-130, BACKGROUND_picturebox.Size.Height + 130);
            } while (tempX > 0 && tempX < BACKGROUND_picturebox.Size.Width + 30
                    && tempY > 0 && tempY < BACKGROUND_picturebox.Size.Height + 30);
            enemy.Location = new Point(tempX, tempY);
            enemy.Size = new Size(30, 30);
            enemy.Visible = true;
            enemy.BackColor = colors[random.Next(0, 6)];
            if (temp == -1)
            {
                BACKGROUND_picturebox.Controls.Add(enemy);
                ENEMY_pictureboxes.Add(enemy);
                Enemy X = new Enemy();
                X.locX = (double)tempX * 1.0;
                X.locY = (double)tempY * 1.0;
                enemyOut.Add(X);
            }
            else
            {
                ENEMY_pictureboxes[temp].Location = new Point(tempX, tempY);
                ENEMY_pictureboxes[temp].Visible = true;
                enemyOut[temp].locX = tempX * 1.0;
                enemyOut[temp].locY = tempY * 1.0;
                enemyOut[temp].Out = false;
            }
        }
        private void Check_Shooting()
        {
            //Create the bullet and continue the direction of the bullet
            int temp = -1;
            for (int i = 0; i < bulletDir.Count; i++)
            {
                if (shoot && timedelayBullet > limitdelayBullet && temp == -1 && bulletDir[i].finish)
                {
                    temp = i;
                }
                if (!bulletDir[i].finish)
                {
                    bulletDir[i].Solve();
                    BULLET_pictureboxes[i].Left = (int) Math.Round(bulletDir[i].bulletXpos);
                    BULLET_pictureboxes[i].Top =  (int) Math.Round(bulletDir[i].bulletYpos);
                    if (Finish_Bullet(BULLET_pictureboxes[i]))
                    {
                        BULLET_pictureboxes[i].Visible = false;
                        bulletDir[i].finish = true;
                    }
                }
                for (int j = 0; j < enemyOut.Count; j++)
                {
                    if (!enemyOut[j].Out && !bulletDir[i].finish
                        && BULLET_pictureboxes[i].Bounds.IntersectsWith(ENEMY_pictureboxes[j].Bounds))
                    {
                        BULLET_pictureboxes[i].Visible = false;
                        bulletDir[i].finish = true;
                        enemyOut[j].Out = true;
                        ENEMY_pictureboxes[j].Visible = false;
                        score += random.Next(5, 20);
                        if (score / 100 > difficult)
                        {
                            limitdelayEnemy -= (limitdelayEnemy > 15) ? 3 : 0;
                            difficult++;
                            speedEnemy += (difficult % 2 == 0 ? 1 : 0);
                        }
                        SCORE_label.Text = "SCORE : " + score.ToString();
                        break;
                    }
                }
            }
            if (shoot && timedelayBullet > limitdelayBullet)
            {
                timedelayBullet = 0;
                Shoot(temp);
            }
        }
        private bool Finish_Bullet(PictureBox x)
        {
            return x.Left < 0 || x.Left > BACKGROUND_picturebox.Size.Width
                || x.Top < 0 || x.Top > BACKGROUND_picturebox.Size.Height;
        }
        private void Shoot(int temp)
        {
            if (temp == -1)
            {
                PictureBox bullet = new PictureBox();
                bullet.Location = new Point(TANK_picturebox.Left + (TANK_picturebox.Size.Width / 2) - 5,
                                            TANK_picturebox.Top + (TANK_picturebox.Size.Height / 2) - 5);
                bullet.Size = new Size(10, 10);
                bullet.Visible = true;
                bullet.BackColor = Color.Yellow;
                BACKGROUND_picturebox.Controls.Add(bullet);
                BULLET_pictureboxes.Add(bullet);
                Bullet t = new Bullet
                {
                    mouseXpos = postionXMouse,
                    mouseYpos = positionYMouse,
                    bulletXpos = TANK_picturebox.Left + (TANK_picturebox.Size.Width / 2) - 5,
                    bulletYpos = TANK_picturebox.Top + (TANK_picturebox.Size.Height / 2) - 5
                };
                t.Prepare();
                bulletDir.Add(t);
            }
            else
            {
                BULLET_pictureboxes[temp].Location = new Point(TANK_picturebox.Left + (TANK_picturebox.Size.Width / 2) - 5,
                                                               TANK_picturebox.Top + (TANK_picturebox.Size.Height / 2) - 5);
                BULLET_pictureboxes[temp].Visible = true;
                bulletDir[temp] = new Bullet 
                {
                    mouseXpos = postionXMouse,
                    mouseYpos = positionYMouse,
                    bulletXpos = TANK_picturebox.Left + (TANK_picturebox.Size.Width / 2) - 5,
                    bulletYpos = TANK_picturebox.Top + (TANK_picturebox.Size.Height / 2) - 5
                };
                bulletDir[temp].Prepare();
                bulletDir[temp].finish = false;
            }
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    goUp = true;
                    goDown = false;
                    break;
                case Keys.S:
                    goDown = true;
                    goUp = false;
                    break;
                case Keys.A:
                    goLeft = true;
                    goRight = false;
                    break;
                case Keys.D:
                    goRight = true;
                    goLeft = false;
                    break;
                case Keys.Enter:
                    Init_Game();
                    timer.Start();
                    break;
                case Keys.Space:
                    teleport1 = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    goUp = false;
                    break;
                case Keys.S:
                    goDown = false;
                    break;
                case Keys.A:
                    goLeft = false;
                    break;
                case Keys.D:
                    goRight = false;
                    break;
                case Keys.Space:
                    teleport1 = false;
                    break;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            shoot = (teleport1) ? false : true;
            teleport2 = true;
            postionXMouse = e.X;
            positionYMouse = e.Y;
            POSITION_label.Text = postionXMouse.ToString() + ":" + positionYMouse.ToString();
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            shoot = false;
            teleport2 = false;
        }
        
    }
}
