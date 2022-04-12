using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace nonamegame
{
    public partial class Form1 : Form
    {
        private int 
       speedTank_subject = 3, tankWidth_subject = 40, tankHeight_subject = 40,
       speedBullet_subject = 20, timedelayBullet_time = 0, limitdelayBullet_time = 80, timedelayEnergyBlock_time = 0,
       limitdelayEnergyBlock_time = 500, timedelayEnemy_time = 0, limitdelayEnemy_time = 50, limitEnemy_number = 5, numberEnemy_number = 0, 
       speedBulletEnemy_subject = 10, timedelaySkill2_time = 0, timedelayTele_time = 0, limitdelayTele_time = 100, limitdelaySkill2_time = 100,
       consumeSkill1_skill = 20, consumeSkill2_skill = 50, consumeSkill3_skill = 5, positionXMouse_position = 0, screenWidth, screenHeight,
       //countscreenWidth, countscreenHeight,
       positionYMouse_position = 0, timems_time = 10, timeStop_time = 0, limitStop_time = 300, limitStop1_time = 80, limitStop2_time = 300, temptime_time = 0,
       energyBlockWidth = 30, energyBlockHeight = 30, barrelXpos = 0, barrelYpos = 0, numberEnergyBlock = 0, limitEnergyBlock_number = 3, temptank = 0, 
       pasttankXpos_subject, pasttankYpos_subject, score = 0, difficult = 0, highspeed = 0, radXtimestop_skill = 0, radYtimestop_skill = 0,
       posXtimestop_skill, posYtimestop_skill, settingpanelX_setting = 0, settingpanelY_setting = 0, timepersec_time, sizeHighSpeed_skill, 
       timemeteorshower_time;
        private double speedEnemy_subject = 1, speedCells_subject, angel, consumeTank_subject = 0.1, energyleft_subject = -1, radTele, 
        countscreenWidth, countscreenHeight, tankXpos_subject, tankYpos_subject;
        private bool goLeft = false, goRight = false, goUp = false, goDown = false, shoot = false, teleport1_skill = false,
            teleport2_skill = false, timestop_skill = false, STOP1 = false, STOP = true, STOP2 = false, pause = false,
            penetration = false, STOPOVER = false, godeyes = false, settingPanel = false, score_enemy = true, meteorshower_skill = false;
        private Random random = new Random();
        private Timer timer = new Timer();
        private Image tank;
        private List<Bullet> bulletDir = new List<Bullet>();
        private List<Bullet> bulletEnemy = new List<Bullet>();
        private List<Normal_Monster> enemy1 = new List<Normal_Monster>();
        private List<Snipe_Monster> enemy3 = new List<Snipe_Monster>();
        private List<Bullet> bloodcells = new List<Bullet>();
        private List<Brush> brushes = new List<Brush>();
        private List<Color> colors = new List<Color>();
        private List<int> energyBlockX = new List<int>();
        private List<int> energyBlockY = new List<int>();
        private List<int> energyBlockval = new List<int>();
        //private List<Point> rechighspeed = new List<Point>();

        class Normal_Monster : Enemy
        {
            public int id = 1;
            public int sizeofMouth = 0;
            public bool plus = true;
            public List<Point> polypoint = new List<Point>(); 
        }
        class Mole_Monster : Enemy
        {
            public int id = 2;
        }
        class Snipe_Monster : Enemy
        {
            private static Random random = new Random();
            public int id = 3;
            public int timedelayShooting = 0, limitdelayShooting = 500, timeSniping = 0, limitSniping = 80;
            public bool Shooting = false, Sniping;
            public double long_barrel = 30;
            public int randomXpos = random.Next(50, 1450), randomYpos = random.Next(50, 950);
            public List<Point> polypoint = new List<Point>();
        }
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
            this.KeyDown += Form1_KeyDown;
            this.KeyUp += Form1_KeyUp;
            BACKGROUND_picturebox.Paint += Form1_Paint;
            BACKGROUND_picturebox.MouseDown += Form1_MouseDown;
            BACKGROUND_picturebox.MouseUp += Form1_MouseUp;
            BACKGROUND_picturebox.MouseMove += Form1_MouseMove;
            brushes.Add(Brushes.White); brushes.Add(Brushes.AliceBlue);
            brushes.Add(Brushes.Violet); brushes.Add(Brushes.Azure);
            brushes.Add(Brushes.Brown);  brushes.Add(Brushes.Bisque);
            brushes.Add(Brushes.Magenta); brushes.Add(Brushes.CadetBlue);
            brushes.Add(Brushes.DarkSeaGreen); brushes.Add(Brushes.DarkKhaki);
            brushes.Add(Brushes.Orange); brushes.Add(Brushes.Firebrick);
            brushes.Add(Brushes.White); brushes.Add(Brushes.AliceBlue);
            brushes.Add(Brushes.Violet); brushes.Add(Brushes.Azure);
            brushes.Add(Brushes.Brown); brushes.Add(Brushes.Bisque);
            brushes.Add(Brushes.CadetBlue); brushes.Add(Brushes.DarkTurquoise);
            brushes.Add(Brushes.DarkSeaGreen); brushes.Add(Brushes.DarkKhaki);
            brushes.Add(Brushes.Orange); brushes.Add(Brushes.Firebrick);
            colors.Add(Color.DarkViolet); colors.Add(Color.DarkCyan);
            colors.Add(Color.DarkGray); colors.Add(Color.DarkBlue);
            colors.Add(Color.DarkGoldenrod); colors.Add(Color.DarkGreen);
            colors.Add(Color.DarkSeaGreen); colors.Add(Color.DarkKhaki);
            colors.Add(Color.DarkMagenta); colors.Add(Color.DarkOliveGreen);
            colors.Add(Color.DarkRed); colors.Add(Color.DarkOrange);
            colors.Add(Color.DarkSalmon); colors.Add(Color.Azure);
            colors.Add(Color.DarkSlateGray); colors.Add(Color.DarkSlateBlue);
            colors.Add(Color.Magenta); colors.Add(Color.CadetBlue);
            colors.Add(Color.DarkSeaGreen); colors.Add(Color.DarkKhaki);
            colors.Add(Color.DarkTurquoise); colors.Add(Color.DeepPink);
            tank = nonamegame.Properties.Resources.Top;
            screenWidth = Screen.GetWorkingArea(this).Width;
            screenHeight = Screen.GetWorkingArea(this).Height;
            countscreenWidth = screenWidth * 1.0;
            countscreenHeight = screenHeight * 1.0;
            Show_Setting();
            Init_Game();
            Start_Game();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.ShowIcon = false;
            this.Text = "nonamegame";
            // SCORE_label.Parent = BACKGROUND_picturebox;
            // POSITION_label.Parent = BACKGROUND_picturebox;
            // ENERGY_label.Parent = BACKGROUND_picturebox;
            Show_Setting();
            SCORE_label.BackColor = Color.FromArgb(100, 0, 0, 0);
            POSITION_label.BackColor = Color.FromArgb(100, 0, 0, 0);
            ENERGY_label.BackColor = Color.FromArgb(100, 0, 0, 0);
            panel1.Visible = false;
            CONTROL_panel.Visible = false;
            CONTROL_panel.Left = 12;
            CONTROL_panel.Top = 52;
            
            Size formSize = new Size(screenWidth + 10, screenHeight);
            this.Location = new Point(0, 0);
            this.Size = new Size(formSize.Width, formSize.Height);
            BACKGROUND_picturebox.Width = screenWidth;
            BACKGROUND_picturebox.Height = screenHeight;
            double tempp1 = 280.0, tempp2 = 60.0;
            a_pictureBox.Width = b_pictureBox.Width = c_pictureBox.Width = (int)(1.0 * screenWidth / countscreenWidth * tempp1);
            a_pictureBox.Height = b_pictureBox.Height = c_pictureBox.Height = (int)(1.0 * screenHeight / countscreenHeight * tempp2);
            SKILL1_label.Font = SKILL2_label.Font = SKILL3_label.Font = new Font("Showcard Gothic", (int)Math.Min(Math.Max(1, a_pictureBox.Size.Width / tempp1 * 22.0), Math.Max(1, a_pictureBox.Size.Height / tempp2 * 22.0)), FontStyle.Bold);
            c_pictureBox.Top = screenHeight - (int) Math.Round(1.0 * screenHeight / countscreenHeight * 1.0 * c_pictureBox.Height) - 39;
            b_pictureBox.Top = screenHeight - (int) Math.Round(1.0 * screenHeight / countscreenHeight * 1.0 * b_pictureBox.Height) * 2 - 39;
            a_pictureBox.Top = screenHeight - (int) Math.Round(1.0 * screenHeight / countscreenHeight * 1.0 * a_pictureBox.Height) * 3 - 39;
            SKILL1_label.Top = c_pictureBox.Top;// + Math.Max(0, c_pictureBox.Size.Height - SKILL1_label.Size.Height);
            SKILL2_label.Top = b_pictureBox.Top;// + Math.Max(0, b_pictureBox.Size.Height - SKILL2_label.Size.Height);
            SKILL3_label.Top = a_pictureBox.Top;// + Math.Max(0, a_pictureBox.Size.Height - SKILL3_label.Size.Height);
            screenHeight -= 39;
            screenWidth -= 10; 
            POSITION_label.Left = screenWidth - POSITION_label.Size.Width;
            POSITION_label.Top = screenHeight - POSITION_label.Size.Height;
            ENERGY_label.Left = screenWidth - 245 - ENERGY_label.Size.Width;
            
            /*c_pictureBox.Top = screenHeight - 40;
            b_pictureBox.Top = screenHeight - 80;
            a_pictureBox.Top = screenHeight - 120;
            SKILL1_label.Top = c_pictureBox.Top + 7;
            SKILL2_label.Top = b_pictureBox.Top + 7;
            SKILL3_label.Top = a_pictureBox.Top + 7;*/
        }
        private void Init_Game()
        {
            enemy1.Clear();
            enemy3.Clear();
            bulletDir.Clear();
            bulletEnemy.Clear();
            energyBlockX.Clear();
            energyBlockY.Clear();
            energyBlockval.Clear();
            bloodcells.Clear();
            timedelayTele_time = timedelayEnemy_time = timedelayBullet_time = timedelaySkill2_time = numberEnemy_number = 0;
            limitdelayEnemy_time = 50;
            limitdelayBullet_time = System.Convert.ToInt32(d_textBox.Text);
            limitEnemy_number = System.Convert.ToInt32(e_textBox.Text);
            speedEnemy_subject = System.Convert.ToInt32(a_textBox.Text);
            if (a_comboBox.Text == "ENEMY CACULATION")
                score_enemy = true;
            else
            if (a_comboBox.Text == "TIME CACULATION")
                score_enemy = false;
            speedCells_subject = 5;
            difficult = 0;
            energyleft_subject = 150;
            numberEnergyBlock = 0;
            score = 0;
            SCORE_label.Text = (score_enemy) ? ("SCORE : " + score.ToString()) : ("TIME : " + score.ToString());
            tankXpos_subject = screenWidth / 2 - (tankWidth_subject / 2);
            tankYpos_subject = screenHeight / 2 - (tankHeight_subject / 2);
        }
        private void Start_Game()
        {
            Init_Game();
            timer.Interval = timems_time;
            timer.Tick += Run_Game;
            timer.Start();
        }
        private void Run_Game(object sender, EventArgs e)
        {
            timedelayBullet_time++;
            timedelayEnemy_time++;
            timedelayEnergyBlock_time++;
            if (STOPOVER)
            {
                Game_Over();
            }
            if (STOP || STOP1 || STOP2)
            {
                timeStop_time++;
                if (STOP)
                {
                    Moving_Enemy();
                    if (numberEnemy_number < limitEnemy_number && timedelayEnemy_time > limitdelayEnemy_time)
                    {
                        Appear_Enemy();
                        numberEnemy_number++;
                        timedelayEnemy_time = 0;
                    }
                    STOP = (timeStop_time != limitStop_time);
                }
                if (STOP1)
                {
                    Check_Shooting(0);
                    Moving_Enemy();
                    if (numberEnemy_number < limitEnemy_number && timedelayEnemy_time > limitdelayEnemy_time)
                    {
                        Appear_Enemy();
                        numberEnemy_number++;
                        timedelayEnemy_time = 0;
                    }
                    STOP1 = (timeStop_time != limitStop1_time);
                }
                if (STOP2)
                {
                    Moving_Tank();
                    Moving_Enemy();
                    if (timedelayBullet_time >= limitdelayBullet_time && shoot)
                    {
                        timedelayBullet_time = 0;
                        Shoot(-1);
                    }
                    if (!penetration)
                    {
                        limitdelayBullet_time = 40;
                        speedTank_subject = 1;
                    }
                    penetration = STOP2 = (timeStop_time != limitStop2_time);   
                    if (!penetration)
                    {
                        speedTank_subject = 3;
                    }
                }
                timeStop_time = (STOP || STOP1 || STOP2) ? timeStop_time : 0;
            }
            else
            {
                timepersec_time++;
                if (timepersec_time == 1000 / timems_time)
                {
                    timepersec_time = 0;
                    if (!score_enemy)
                    {
                        score++;
                        SCORE_label.Text = "TIME : " + score.ToString();
                    }
                }
                if (meteorshower_skill)
                {
                    timemeteorshower_time++;
                }
                else
                {
                    timemeteorshower_time = 0;
                }
                //Appear enemy around the tank
                if (numberEnemy_number < limitEnemy_number && timedelayEnemy_time > limitdelayEnemy_time)
                {
                    Appear_Enemy();
                    numberEnemy_number++;
                    timedelayEnemy_time = 0;
                }
                if (settingPanel == false)
                {
                    timedelayTele_time++;
                    timedelaySkill2_time++;
                    Moving_Enemy();
                    Moving_Tank();
                    Check_Shooting(1);
                }
                if (teleport1_skill && teleport2_skill && timedelayTele_time > limitdelayTele_time && energyleft_subject >= consumeSkill1_skill)
                {
                    pasttankXpos_subject = (int)tankXpos_subject;
                    pasttankYpos_subject = (int)tankYpos_subject;
                    tankXpos_subject = positionXMouse_position;
                    tankYpos_subject = positionYMouse_position;
                    energyleft_subject -= consumeSkill1_skill;
                    STOP1 = true;
                    angel = 0;
                    radTele = 10;
                    temptank = 0;
                    timedelayTele_time = 0;
                }
                if (timestop_skill && timedelaySkill2_time > limitdelaySkill2_time && energyleft_subject >= consumeSkill2_skill)
                {
                    energyleft_subject -= consumeSkill2_skill;
                    STOP2 = true;
                    timedelaySkill2_time = 0;
                }
                switch (highspeed)
                {
                    case 0:
                        limitdelayBullet_time = System.Convert.ToInt32(d_textBox.Text);
                        break;
                     case 1:
                         limitdelayBullet_time = System.Convert.ToInt32(d_textBox.Text) - 10;
                         break;
                     case 2:
                         limitdelayBullet_time = System.Convert.ToInt32(d_textBox.Text) - 20;
                         break;
                     case 3:
                         limitdelayBullet_time = System.Convert.ToInt32(d_textBox.Text) - 35;
                         break;
                }

                if (timedelayEnergyBlock_time > limitdelayEnergyBlock_time)
                {
                    timedelayEnergyBlock_time = 0;
                    Appear_EnergyBlock();
                }
            }
            BACKGROUND_picturebox.Invalidate();  
        }
        private void Moving_Enemy()
        {
            //SNIPE_MONSTER
            for (int i = 0; i < Math.Max(enemy1.Count, enemy3.Count); i++)
            {
                if (i < enemy3.Count)
                {
                    if (STOP2 && !enemy3[i].Stop)
                    {
                        double aa = ((posXtimestop_skill - enemy3[i].enemyXpos) * (posXtimestop_skill - enemy3[i].enemyXpos))
                                    + ((posYtimestop_skill - enemy3[i].enemyYpos) * (posYtimestop_skill - enemy3[i].enemyYpos));
                        double bb = 1.0 * radXtimestop_skill / 2;
                        if (aa <= bb * bb)
                        {
                            enemy3[i].Stop = true;
                        }
                    }
                    else
                    if (STOP2 && enemy3[i].Stop)
                    {
                        double aa = ((posXtimestop_skill - enemy3[i].enemyXpos) * (posXtimestop_skill - enemy3[i].enemyXpos))
                                    + ((posYtimestop_skill - enemy3[i].enemyYpos) * (posYtimestop_skill - enemy3[i].enemyYpos));
                        double bb = 1.0 * radXtimestop_skill / 2;
                        if (aa > bb * bb)
                        {
                            enemy3[i].Stop = false;
                        }
                    }
                    else
                    if (!STOP2 && enemy3[i].Stop)
                    {
                        enemy3[i].Stop = false;
                    }
                    if (!enemy3[i].Out && !enemy3[i].Stop)
                    {
                        if (STOP1 && timeStop_time <= 30)
                        {
                            enemy3[i].tankXpos = (1.0 * pasttankXpos_subject + 1.0 * tankWidth_subject / 2);
                            enemy3[i].tankYpos = (1.0 * pasttankYpos_subject + 1.0 * tankHeight_subject / 2);
                        }
                        else
                        {
                            enemy3[i].tankXpos = (1.0 * tankXpos_subject + 1.0 * tankWidth_subject / 2);
                            enemy3[i].tankYpos = (1.0 * tankYpos_subject + 1.0 * tankHeight_subject / 2);
                        }

                        Enemy X = enemy3[i];
                        double aa = ((X.tankXpos - X.enemyXpos) * (X.tankXpos - X.enemyXpos))
                                    + ((X.tankYpos - X.enemyYpos) * (X.tankYpos - X.enemyYpos));
                        double bb = 1.0 * ((tankWidth_subject / 2) + 1.0 * (X.enemyWidth / 2));
                        if (aa <= bb * bb)
                        {
                            STOPOVER = true;
                            angel = -1;
                        }
                        if (enemy3[i].Xpos >= enemy3[i].randomX - 5 && enemy3[i].Xpos <= enemy3[i].randomX + 5
                            && enemy3[i].Ypos >= enemy3[i].randomY - 5 && enemy3[i].Ypos <= enemy3[i].randomY + 5)
                        {
                            enemy3[i].randomXpos = random.Next(50, screenWidth - 50);
                            enemy3[i].randomYpos = random.Next(50, screenHeight - 50);
                        }
                        enemy3[i].randomX = enemy3[i].randomXpos;
                        enemy3[i].randomY = enemy3[i].randomYpos;
                        enemy3[i].Solve(0, 3);
                        enemy3[i].Shooting = false;
                        double temp = 80;
                        if (enemy3[i].Xpos >= -temp && enemy3[i].Ypos >= -temp && enemy3[i].Xpos <= screenWidth + temp &&
                                enemy3[i].Ypos <= screenHeight + temp && enemy3[i].targetX == -2)
                        {
                            enemy3[i].targetX = enemy3[i].Xpos + (int)((enemy3[i].zz) * ((enemy3[i].zz > 0) ? -enemy3[i].enemyXpos + enemy3[i].radX + 10.0: enemy3[i].enemyXpos - screenWidth * 1.0 + enemy3[i].radX + 10.0));
                            enemy3[i].targetY = enemy3[i].Ypos + (int)((enemy3[i].zzz) * ((enemy3[i].zzz > 0) ? -enemy3[i].enemyYpos + enemy3[i].radY + 10.0: enemy3[i].enemyYpos - screenHeight * 1.0 + enemy3[i].radY + 10.0));
                            enemy3[i].polypoint.Add(new Point((int)(enemy3[i].targetX), (int)(enemy3[i].targetY - enemy3[i].radY)));
                            enemy3[i].polypoint.Add(new Point((int)(enemy3[i].targetX - enemy3[i].radX), (int)(enemy3[i].targetY + enemy3[i].radY)));
                            enemy3[i].polypoint.Add(new Point((int)(enemy3[i].targetX + enemy3[i].radX), (int)(enemy3[i].targetY + enemy3[i].radY)));
                        }
                        if (enemy3[i].timedelayShooting < enemy3[i].limitdelayShooting)
                        {
                            enemy3[i].timedelayShooting++;
                            enemy3[i].Solve(speedEnemy_subject + ((godeyes) ? 0.5F : 0F), 3);
                            
                        }
                        else
                        if (!enemy3[i].Sniping)
                        {
                            enemy3[i].Sniping = true;
                        }
                        if (enemy3[i].Sniping)
                        {
                            if (enemy3[i].timeSniping < enemy3[i].limitSniping)
                            {
                                enemy3[i].timeSniping++;
                            }
                            else
                            {
                                enemy3[i].Shooting = true;
                                Bullet t = new Bullet
                                {
                                    mouseXpos = 1.0 * tankXpos_subject + 1.0 * tankWidth_subject / 2,
                                    mouseYpos = 1.0 * tankYpos_subject + 1.0 * tankHeight_subject / 2,
                                    bulletXpos = 1.0 * enemy3[i].enemyXpos + enemy3[i].zz * enemy3[i].long_barrel,
                                    bulletYpos = 1.0 * enemy3[i].enemyYpos + enemy3[i].zzz * enemy3[i].long_barrel
                                };
                                t.Prepare();
                                bulletEnemy.Add(t);
                                enemy3[i].timeSniping = 0;
                                enemy3[i].timedelayShooting = 0;
                                enemy3[i].Sniping = false;
                            }
                        }
                    }
                }
                //Normal_Monster
                if (i < enemy1.Count)
                {
                    if (STOP2 && !enemy1[i].Stop)
                    {
                        double aa = ((posXtimestop_skill - enemy1[i].enemyXpos) * (posXtimestop_skill - enemy1[i].enemyXpos))
                                    + ((posYtimestop_skill - enemy1[i].enemyYpos) * (posYtimestop_skill - enemy1[i].enemyYpos));
                        double bb = 1.0 * radXtimestop_skill / 2;
                        if (aa <= bb * bb)
                        {
                            enemy1[i].Stop = true;
                        }
                    }
                    else
                    if (STOP2 && enemy1[i].Stop)
                    {
                        double aa = ((posXtimestop_skill - enemy1[i].enemyXpos) * (posXtimestop_skill - enemy1[i].enemyXpos))
                                    + ((posYtimestop_skill - enemy1[i].enemyYpos) * (posYtimestop_skill - enemy1[i].enemyYpos));
                        double bb = 1.0 * radXtimestop_skill / 2;
                        if (aa > bb * bb)
                        {
                            enemy1[i].Stop = false;
                        }
                    }
                    else
                    if (!STOP2 && enemy1[i].Stop)
                    {
                        enemy1[i].Stop = false;
                    }
                    if (!enemy1[i].Out && !enemy1[i].Stop)
                    {
                        if (STOP1 && timeStop_time <= 30)
                        {
                            enemy1[i].tankXpos = (1.0 * pasttankXpos_subject + 1.0 * tankWidth_subject / 2);
                            enemy1[i].tankYpos = (1.0 * pasttankYpos_subject + 1.0 * tankHeight_subject / 2);
                        }
                        else
                        {
                            enemy1[i].tankXpos = (1.0 * tankXpos_subject + 1.0 * tankWidth_subject / 2);
                            enemy1[i].tankYpos = (1.0 * tankYpos_subject + 1.0 * tankHeight_subject / 2);
                        }

                        Enemy X = enemy1[i];
                        double aa = ((X.tankXpos - X.enemyXpos) * (X.tankXpos - X.enemyXpos))
                                    + ((X.tankYpos - X.enemyYpos) * (X.tankYpos - X.enemyYpos));
                        double bb = 1.0 * ((tankWidth_subject / 2) + 1.0 * (X.enemyWidth / 2));
                        if (aa <= bb * bb)
                        {
                            STOPOVER = true;
                            angel = -1;
                        }
                        enemy1[i].Solve(speedEnemy_subject + ((godeyes) ? 0.5F : 0F), enemy1[i].id);
                        double temp = 80;
                        if (enemy1[i].Xpos >= -temp && enemy1[i].Ypos >= -temp && enemy1[i].Xpos <= screenWidth + temp &&
                                enemy1[i].Ypos <= screenHeight + temp && enemy1[i].targetX == -2)
                        {
                            enemy1[i].targetX = enemy1[i].Xpos + (int)((enemy1[i].zz) * ((enemy1[i].zz > 0) ? -enemy1[i].enemyXpos + enemy1[i].radX + 10.0: (enemy1[i].enemyXpos - screenWidth * 1.0) + enemy1[i].radX + 10.0));
                            enemy1[i].targetY = enemy1[i].Ypos + (int)((enemy1[i].zzz) * ((enemy1[i].zzz > 0) ? -enemy1[i].enemyYpos + enemy1[i].radY + 10.0: (enemy1[i].enemyYpos - screenHeight * 1.0) + enemy1[i].radY + 5.0));
                            enemy1[i].polypoint.Add(new Point((int)(enemy1[i].targetX), (int)(enemy1[i].targetY - enemy1[i].radY)));
                            enemy1[i].polypoint.Add(new Point((int)(enemy1[i].targetX - enemy1[i].radX), (int)(enemy1[i].targetY + enemy1[i].radY)));
                            enemy1[i].polypoint.Add(new Point((int)(enemy1[i].targetX + enemy1[i].radX), (int)(enemy1[i].targetY + enemy1[i].radY)));
                        }
                    }
                }
            }
            //Countdown
            SKILL1_label.Text = "TELEPORT : " + ((timedelayTele_time > limitdelayTele_time) ? ("READY")
                                                                 : ((((limitdelayTele_time - timedelayTele_time) * timems_time) / 1000).ToString()));
            SKILL2_label.Text = "TIMESTOP : " + ((timedelaySkill2_time > limitdelaySkill2_time) ? ("READY")
                                                             : ((((limitdelaySkill2_time - timedelaySkill2_time) * timems_time) / 1000).ToString()));
        }
        private void Moving_Tank()
        {
            //Check
            int tempX = ((int)tankXpos_subject + tankWidth_subject / 2);
            int tempY = ((int)tankYpos_subject + tankHeight_subject / 2);
            for (int i = 0; i < energyBlockX.Count; i++)
            {
                double aa = ((tempX - energyBlockX[i]) * (tempX - energyBlockX[i]))
                                    + ((tempY - energyBlockY[i]) * (tempY - energyBlockY[i]));
                double bb = 1.0 * ((tankWidth_subject / 2) + 1.0 * (energyBlockWidth / 2));
                if (aa <= bb * bb)
                {
                    energyleft_subject += energyBlockval[i];
                    energyBlockX[i] = -1;
                    energyBlockY[i] = -1;
                    numberEnergyBlock--;
                    energyleft_subject = Math.Min(230, energyleft_subject);
                }
            }

            double speed = 0;
            if (energyleft_subject <= 0) speed = 1.0;
            else
            speed = (double) speedTank_subject + ((!STOP2) ? highspeed : 0);
            consumeTank_subject = 0;
            if (goLeft || goRight || goUp || goDown)
            {
                switch (speed)
                {
                    case 3:
                        consumeTank_subject = 0.08;
                        break;
                    case 4:
                        consumeTank_subject = 0.1;
                        break;
                    case 5:
                        consumeTank_subject = 0.12;
                        break;
                    case 6:
                        consumeTank_subject = 0.15;
                        break;
                }
            }
            switch (highspeed)
            {
                case 1:
                    consumeTank_subject += 0.03;
                    break;
                case 2:
                    consumeTank_subject += 0.05;
                    break;
                case 3:
                    consumeTank_subject += 0.08;
                    break;
            }

            energyleft_subject -= (energyleft_subject - consumeTank_subject < 0) ? energyleft_subject : consumeTank_subject;
            
            if (goLeft == true && goUp == true)
            {
                speed = Math.Sqrt((speed * speed)/ (2.0));
                tankXpos_subject -= (tankXpos_subject - speed < 0) ? (tankXpos_subject) : speed;
                tankYpos_subject -= (tankYpos_subject - speed < 0) ? (tankYpos_subject) : speed;
            }
            else
            if (goLeft == true && goDown == true)
            {
                speed = Math.Sqrt((speed * speed) / (2.0));
                tankXpos_subject -= (tankXpos_subject - speed < 0) ? (tankXpos_subject) : speed;
                tankYpos_subject += (tankYpos_subject + speed + tankHeight_subject > screenHeight)
                                    ? (screenHeight - tankYpos_subject - tankHeight_subject) : speed;
            }
            else
            if (goRight == true && goUp == true)
            {
                speed = Math.Sqrt((speed * speed) / (2.0));
                tankXpos_subject += (tankXpos_subject + speed + tankWidth_subject > screenWidth)
                                        ? (screenWidth - tankXpos_subject - tankWidth_subject) : speed;
                tankYpos_subject -= (tankYpos_subject - speed < 0) ? (tankYpos_subject) : speed;
            }
            else
            if (goRight == true && goDown == true)
            {
                speed = Math.Sqrt((speed * speed) / (2.0));
                tankXpos_subject += (tankXpos_subject + speed + tankWidth_subject > screenWidth)
                                        ? (screenWidth - tankXpos_subject - tankWidth_subject) : speed;
                tankYpos_subject += (tankYpos_subject + speed + tankHeight_subject > screenHeight)
                                    ? (screenHeight - tankYpos_subject - tankHeight_subject) : speed;
            }
            else
            if (goLeft == true)
                tankXpos_subject -= (tankXpos_subject - speed < 0) ? (tankXpos_subject) : speed;
            else
            if (goRight == true)
                tankXpos_subject += (tankXpos_subject + speed + tankWidth_subject > screenWidth)
                                        ? (screenWidth - tankXpos_subject - tankWidth_subject) : speed;
            else
            if (goUp == true)
                tankYpos_subject -= (tankYpos_subject - speed < 0) ? (tankYpos_subject) : speed;
            else
            if (goDown == true)
                tankYpos_subject += (tankYpos_subject + speed + tankHeight_subject > screenHeight)
                                    ? (screenHeight - tankYpos_subject - tankHeight_subject) : speed;
        }
        private void Appear_Enemy()
        {
            int tempX = 0, tempY = 0, tempScr = 80;
            int R = random.Next(1, 5);
            switch (R)
            {
                case 1:
                    tempX = random.Next(-180, -tempScr);
                    tempY = random.Next(-180, screenHeight + 180);
                    break;
                case 2:
                    tempX = random.Next(screenWidth + tempScr, screenWidth + 180);
                    tempY = random.Next(-180, screenHeight + 180);
                    break;
                case 3:
                    tempY = random.Next(-180, -tempScr);
                    tempX = random.Next(-180, screenWidth + 180);
                    break;
                case 4:
                    tempY = random.Next(screenHeight + tempScr, screenHeight + 180);
                    tempX = random.Next(-180, screenWidth + 180);
                    break;
            }
            int tempSize = random.Next(0, 50);
            if (tempSize <= 10)
            {
                Snipe_Monster X = new Snipe_Monster
                {
                    enemyXpos = (double)tempX * 1.0,
                    enemyYpos = (double)tempY * 1.0,
                    tankXpos = (double)tankXpos_subject + 1.0 * tankWidth_subject / 2,
                    tankYpos = (double)tankYpos_subject + 1.0 * tankHeight_subject / 2,
                    brush = brushes[random.Next(0, brushes.Count)],
                    enemyWidth = 30,
                    enemyHeight = 30
                };
                X.Solve(0, 3);
                enemy3.Add(X);
            }
            else
            {
                Normal_Monster X = new Normal_Monster
                {
                    enemyXpos = (double)tempX * 1.0,
                    enemyYpos = (double)tempY * 1.0,
                    tankXpos = (double)tankXpos_subject + 1.0 * tankWidth_subject / 2,
                    tankYpos = (double)tankYpos_subject + 1.0 * tankHeight_subject / 2,
                    brush = brushes[random.Next(0, brushes.Count)]
                };
                X.Solve(0, 1);
                enemy1.Add(X);
            }
        }
        private void Appear_EnergyBlock()
        {
            if (numberEnergyBlock >= limitEnergyBlock_number)
            {
                return;
            }
            int temp = -1;
            numberEnergyBlock++;
            for (int i = 0; i < energyBlockX.Count; i++)
            {
                if (energyBlockX[i] == -1)
                {
                    temp = i;
                    break;
                }
            }
            int u = random.Next(energyBlockWidth + 100, screenWidth - energyBlockWidth - 100);
            int v = random.Next(energyBlockHeight + 100, screenHeight - energyBlockHeight - 100);
            int val = random.Next(20, 150);
            if (temp == -1)
            {
                energyBlockX.Add(u);
                energyBlockY.Add(v);
                energyBlockval.Add(val);
            }
            else
            {
                energyBlockX[temp] = u;
                energyBlockY[temp] = v;
                energyBlockval[temp] = val;
            }
        }
        private void Appear_Bloodcells(int temp1, int temp2, int id)
        {
            speedCells_subject = 7.5;
            for (int i = 0; i <= ((id == 1) ? random.Next(15, 20) : random.Next(5, 10)); i++)
            {
                Bullet X = new Bullet();
                int u = random.Next(1, 31);
                u = (15 - u == 0) ? 1 : 15 - u;
                int v = random.Next(1, 31);
                v = (15 - v == 0) ? 1 : 15 - u;
                int temp3, temp4;
                X.angelX = (bulletDir[temp1].zz) + Math.Sin(1 / (1.0 * u));
                X.angelY = (bulletDir[temp1].zzz) + Math.Sin(1 / (1.0 * v));
                if (id == 1)
                {
                    temp3 = random.Next(bulletDir[temp1].Xpos - 0 * enemy1[temp2].enemyWidth, bulletDir[temp1].Xpos + 0 * enemy1[temp2].enemyWidth);
                    temp4 = random.Next(bulletDir[temp1].Ypos - 0 * enemy1[temp2].enemyHeight, bulletDir[temp1].Ypos + 0 * enemy1[temp2].enemyHeight);
                    X.brush = enemy1[temp2].brush;
                }
                else
                {
                    temp3 = random.Next(bulletDir[temp1].Xpos - 0 * enemy3[temp2].enemyWidth, bulletDir[temp1].Xpos + 0 * enemy3[temp2].enemyWidth);
                    temp4 = random.Next(bulletDir[temp1].Ypos - 0 * enemy3[temp2].enemyHeight, bulletDir[temp1].Ypos + 0 * enemy3[temp2].enemyHeight);
                    X.brush = enemy3[temp2].brush;
                }
                X.tempX = temp3;
                X.tempY = temp4;
                X.bloodcellsXpos = (int)Math.Round(X.tempX);
                X.bloodcellsYpos = (int)Math.Round(X.tempY);
                X.damage = true;
                X.speedCells = speedCells_subject;
                
                bloodcells.Add(X);
            }
        }
        private void Check_Shooting(int tempp)
        {
            //Create the bullet and continue the direction of the bullet
            //Bullet's TANK
            int temp = -1;
            for (int i = 0; i < bulletDir.Count; i++)
            {
                if (shoot && timedelayBullet_time > limitdelayBullet_time && temp == -1 && bulletDir[i].finish && !bulletDir[i].damage)
                {
                    temp = i;
                }
                bulletDir[i].Solve((double) speedBullet_subject);
                if (Finish_Bullet(bulletDir[i]))
                {
                        bulletDir.RemoveRange(i, 1);
                }
                else
                for (int j = 0; j < Math.Max(enemy1.Count, enemy3.Count); j++)
                {
                    if (j < enemy1.Count && !bulletDir[i].finish)
                    {
                        Bullet X = bulletDir[i];
                        Enemy Y = enemy1[j];
                        double aa = ((X.bulletXpos - Y.enemyXpos) * (X.bulletXpos - Y.enemyXpos))
                              + ((X.bulletYpos - Y.enemyYpos) * (X.bulletYpos - Y.enemyYpos));
                        double bb = 1.0 * ((X.bulletWidth / 2) + 1.0 * (Y.enemyWidth / 2));
                        if (aa <= bb * bb)
                        {
                            Appear_Bloodcells(i, j, 1);
                            bulletDir.RemoveRange(i, 1);
                            enemy1.RemoveRange(j, 1);
                            numberEnemy_number--;
                            if (score_enemy)
                            {
                                score += random.Next(10, 10);
                                SCORE_label.Text = "SCORE : " + score.ToString();
                            }
                            if ((score_enemy && score / 100 > difficult) || (!score_enemy && score / 10 > difficult))
                            {
                                limitdelayEnemy_time -= (limitdelayEnemy_time > 15) ? 3 : 0;
                                difficult = score / (score_enemy ? 100 : 10);
                                limitEnemy_number += (difficult % 2 == 0 ? 1 : 0);
                                speedEnemy_subject += (difficult % 2 == 0 ? 0.5 : 0);
                            }
                            
                            break;
                        }
                    }
                    if (j < enemy3.Count && !bulletDir[i].finish)
                    {
                        Bullet X = bulletDir[i];
                        Enemy Y = enemy3[j];
                        double aa = ((X.bulletXpos - Y.enemyXpos) * (X.bulletXpos - Y.enemyXpos))
                              + ((X.bulletYpos - Y.enemyYpos) * (X.bulletYpos - Y.enemyYpos));
                        double bb = 1.0 * ((X.bulletWidth / 2) + 1.0 * (Y.enemyWidth / 2));
                        if (aa <= bb * bb)
                        {
                            Appear_Bloodcells(i, j, 3);
                            bulletDir.RemoveRange(i, 1);
                            enemy3.RemoveRange(j, 1);
                            numberEnemy_number--;
                            if (score_enemy)
                            {
                                score += random.Next(10, 10);
                                SCORE_label.Text = "SCORE : " + score.ToString();
                            }
                            if ((score_enemy && score / 100 > difficult) || (!score_enemy && score / 10 > difficult))
                                {
                                limitdelayEnemy_time -= (limitdelayEnemy_time > 15) ? 3 : 0;
                                difficult = score / (score_enemy ? 100 : 10) ;
                                limitEnemy_number += (difficult % 2 == 0 ? 1 : 0);
                                speedEnemy_subject += (difficult % 2 == 0 ? 0.5 : 0);
                            }
                           
                            break;
                        }
                    }
                }
            }
            //Bullet's Snipe_Monster
            for (int i = 0; i < bulletEnemy.Count; i++)
            {
                bulletEnemy[i].Solve((double) speedBulletEnemy_subject);
                if (Finish_Bullet(bulletEnemy[i]))
                {
                    bulletEnemy.RemoveRange(i, 1);
                }
                else
                {
                    Bullet X = bulletEnemy[i];
                    double aa = ((X.bulletXpos - (tankXpos_subject + tankWidth_subject / 2)) * (X.bulletXpos - (tankXpos_subject + tankWidth_subject / 2)))
                              + ((X.bulletYpos - (tankYpos_subject + tankHeight_subject / 2)) * (X.bulletYpos - (tankYpos_subject + tankHeight_subject / 2)));
                    double bb = 1.0 * ((X.bulletWidth / 2) + 1.0 * (tankWidth_subject / 2));
                    if (aa <= bb * bb)
                    {
                        STOPOVER = true;
                        angel = -1;
                    }
                }
            }
            if (tempp == 1)
            {
                if (shoot && timedelayBullet_time > limitdelayBullet_time)
                {
                    timedelayBullet_time = 0;
                    Shoot(temp);
                }
            }
        }
        private bool Finish_Bullet(Bullet x)
        {
            return x.Xpos < -40 || x.Xpos > screenWidth
                || x.Ypos < -40 || x.Ypos > screenHeight;
        }
        private void Shoot(int temp)
        {
            if (temp == -1)
            {
                Bullet t = new Bullet
                {
                    mouseXpos = 1.0 * positionXMouse_position,
                    mouseYpos = 1.0 * positionYMouse_position,
                    bulletXpos = 1.0 * barrelXpos,
                    bulletYpos = 1.0 * barrelYpos
                };
                t.Prepare();
                bulletDir.Add(t);
            }
            else
            {
                bulletDir[temp] = new Bullet 
                {
                    mouseXpos = 1.0 * positionXMouse_position,
                    mouseYpos = 1.0 * positionYMouse_position,
                    bulletXpos = 1.0 * barrelXpos,
                    bulletYpos = 1.0 * barrelYpos
                };
                bulletDir[temp].Prepare();
                bulletDir[temp].finish = false;
            }
        }
        private void Game_Over()
        {
            //angel += 0.1;
            timer.Stop();
        }
        private void Show_Setting()
        {
            a_textBox.Text = speedEnemy_subject.ToString();
            b_textBox.Text = speedTank_subject.ToString();
            c_textBox.Text = speedBullet_subject.ToString();
            d_textBox.Text = limitdelayBullet_time.ToString();
            e_textBox.Text = limitEnemy_number.ToString();
            f_textBox.Text = limitEnergyBlock_number.ToString();
            g_textBox.Text = (screenWidth).ToString();
            h_textBox.Text = (screenHeight).ToString();
            a_comboBox.Text = (score_enemy) ? "ENERMY CACULATION" : "TIME CACULATION";
            Freeze_Box();
        }
        private void Freeze_Box()
        {
            a_textBox.Enabled = false;
            b_textBox.Enabled = false;
            c_textBox.Enabled = false;
            d_textBox.Enabled = false;
            e_textBox.Enabled = false;
            f_textBox.Enabled = false;
            g_textBox.Enabled = false;
            h_textBox.Enabled = false;
            //a_comboBox.Enabled = false;
        }
        private void Defreeze_Box()
        {
            a_textBox.Enabled = true;
            b_textBox.Enabled = true;
            c_textBox.Enabled = true;
            d_textBox.Enabled = true;
            e_textBox.Enabled = true;
            f_textBox.Enabled = true;
            g_textBox.Enabled = true;
            h_textBox.Enabled = true;
            a_comboBox.Enabled = true;
            a_comboBox.Text = (score_enemy ? "ENEMY CACULATION" : "TIME CACULATION");
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
                    STOPOVER = false;
                    STOP = true;
                    timer.Start();
                    break;
                case Keys.Space:
                    teleport1_skill = true;
                    break;
                case Keys.P:
                    if (!pause)
                        timer.Stop();
                    else
                        timer.Start();
                    pause = !pause;
                    break;
                case Keys.V:
                    godeyes = true;
                    break;
                case Keys.E:
                    timestop_skill = true;
                    posXtimestop_skill = (int)tankXpos_subject + tankWidth_subject / 2;
                    posYtimestop_skill = (int)tankYpos_subject + tankHeight_subject / 2;
                    break;
                case Keys.Q:
                    meteorshower_skill = true;
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
                    teleport1_skill = false;
                    break;
                case Keys.V:
                    godeyes = false;
                    break;
                case Keys.E:
                    timestop_skill = false;
                    break;
                case Keys.Q:
                    meteorshower_skill = false;
                    break;
                

            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                shoot = (teleport1_skill) ? false : true;
                teleport2_skill = true;
                positionXMouse_position = e.X;
                positionYMouse_position = e.Y;
                if (settingPanel == true && e.X >= 380 && e.X < 460 && e.Y >= 28 && e.Y <= 40)
                {
                    SETTINGS_panel.Visible = true;
                    CONTROL_panel.Visible = false;
                }
                else
                if (settingPanel == true &&e.X >= 460 && e.X <= 540 && e.Y >= 28 && e.Y <= 40)
                {
                    SETTINGS_panel.Visible = false;
                    CONTROL_panel.Visible = true;
                }
                else
                if (e.X >= 0 && e.X <= 40 && e.Y >= 0 && e.Y <= 40)
                {
                    if (settingPanel == false)
                    {
                        settingPanel = true;
                        Defreeze_Box();
                    }
                    else
                    {
                        Show_Setting();
                        panel1.Visible = false;
                        SETTINGS_panel.Visible = true;
                        CONTROL_panel.Visible = false;
                        settingPanel = false;
                    }
                }
            }
            else if (e.Button == MouseButtons.Right && energyleft_subject > consumeSkill3_skill && speedTank_subject + highspeed <= 5)
            {
                energyleft_subject -= consumeSkill3_skill;
                highspeed ++;
                SKILL3_label.Text = "HIGHSPEED : +" + (highspeed).ToString();
            }
            else
            if (e.Button == MouseButtons.Middle)
            {
                highspeed = 0;
                SKILL3_label.Text = "HIGHSPEED : +" + (highspeed).ToString();
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            
            shoot = false;
            teleport2_skill = false;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            positionXMouse_position = e.X;
            positionYMouse_position = e.Y;
            POSITION_label.Text = positionXMouse_position.ToString() + " : " + positionYMouse_position.ToString();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            if (settingPanel == false)
            {
                Pen pen = new Pen(Color.Green, 12);
                Pen pen1 = new Pen(Color.Blue, 5);
                Pen pen2 = new Pen(Color.White, 2);
                Pen pen3 = new Pen(Color.Olive, 10);
                Pen pen4 = new Pen(Color.Lavender, 10);
                //Loading game
                if (STOP) 
                {
                    temptime_time = 0;
                    Font drawFont = new Font("Arial", 25, FontStyle.Bold);
                    Rectangle drawRectangle = new Rectangle(screenWidth / 2 - 100, (screenHeight / 2 + tankHeight_subject / 2) + 140, 500, 50);
                    string drawString1 = "FUEL LOADING ...";
                    graphics.DrawString(drawString1, drawFont, Brushes.AntiqueWhite, drawRectangle);
                    graphics.DrawRectangle(new Pen(Color.LightBlue, 10), new Rectangle(screenWidth / 2 - 305, (screenHeight / 2 + tankHeight_subject / 2) + 195, 610, 40));
                    graphics.FillRectangle(Brushes.Gold, new RectangleF(screenWidth / 2 - 300, (screenHeight / 2 + tankHeight_subject / 2) + 200, (float) (Math.Min(timeStop_time, limitStop_time) / (1.0 * limitStop_time)) * 600F, 30));
                }
                else
                if (temptime_time < 50)
                {
                    temptime_time++;
                    Font drawFont = new Font("Arial", 25, FontStyle.Bold);
                    Rectangle drawRectangle = new Rectangle(screenWidth / 2 - 50, (screenHeight / 2 + tankHeight_subject / 2) + 140, 500, 50);
                    string drawString2 = "FINISH !!!";
                    graphics.DrawString(drawString2, drawFont, Brushes.AntiqueWhite, drawRectangle);
                    graphics.DrawRectangle(new Pen(Color.LightBlue, 10), new Rectangle(screenWidth / 2 - 305, (screenHeight / 2 + tankHeight_subject / 2) + 195, 610, 40));
                    graphics.FillRectangle(Brushes.Gold, new RectangleF(screenWidth / 2 - 300, (screenHeight / 2 + tankHeight_subject / 2) + 200, 600F, 30));
                }
                //SKILL TELEPORT
                double temp;
                if (!STOP1 && teleport1_skill && timedelayTele_time >= limitdelayTele_time)
                {
                    graphics.DrawEllipse(new Pen(Color.DarkBlue, 5), (int)(positionXMouse_position - 55), (int)(positionYMouse_position - 55), (int)(55 * 2), (int)(55 * 2));
                    graphics.DrawEllipse(new Pen(Color.DarkBlue, 5), (int)(positionXMouse_position - 10), (int)(positionYMouse_position - 10), (int)(10 * 2), (int)(10 * 2));
                }
                if (STOP1)
                {
                    int locX = (int)tankXpos_subject + tankWidth_subject / 2;
                    int locY = (int)tankYpos_subject + tankHeight_subject / 2;
                    int locXX = pasttankXpos_subject + tankWidth_subject / 2;
                    int locYY = pasttankYpos_subject + tankHeight_subject / 2;
                    if (timeStop_time <= 30)
                    {
                        radTele += 1.5;
                    }
                    else
                    if (timeStop_time >= 50)
                    {
                        radTele -= 1.5;
                    }
                    graphics.FillEllipse(Brushes.DarkBlue, (int)(locX - radTele), (int)(locY - radTele), (int)(radTele * 2), (int)(radTele * 2));
                    graphics.FillEllipse(Brushes.DarkBlue, (int)(locXX - radTele), (int)(locYY - radTele), (int)(radTele * 2), (int)(radTele * 2));
                    temp = angel;
                    for (int i = 0; i < 18; i++)
                    {
                        double tempX = (Math.Cos(temp * Math.PI / 180F) * radTele);
                        double tempY = (Math.Sin(temp * Math.PI / 180F) * radTele);
                        double tempXX = (Math.Cos(((temp + 50F > 360F) ? (temp + 50F - 360F) : (temp + 50F)) * Math.PI / 180F) * (radTele + 20F));
                        double tempYY = (Math.Sin(((temp + 50F > 360F) ? (temp + 50F - 360F) : (temp + 50F)) * Math.PI / 180F) * (radTele + 20F));
                        double tempcolorX = (Math.Cos(((temp + 50F > 360F) ? (temp + 50F - 360F) : (temp + 50F)) * Math.PI / 180F) * (radTele));
                        double tempcolorY = (Math.Sin(((temp + 50F > 360F) ? (temp + 50F - 360F) : (temp + 50F)) * Math.PI / 180F) * (radTele));
                        //graphics.DrawLine(new Pen(Color.LightBlue, 20), (int)(locX), (int)(locY), (int)(locX + tempcolorX), (int)(locY + tempcolorY));
                        //graphics.DrawLine(new Pen(Color.LightBlue, 20), (int)(locXX), (int)(locYY), (int)(locXX + tempcolorX), (int)(locYY + tempcolorY));
                        graphics.DrawLine(new Pen(Color.Black, 5), (int)(locX + tempX), (int)(locY + tempY), (int)(locX + tempXX), (int)(locY + tempYY));
                        graphics.DrawLine(new Pen(Color.Black, 5), (int)(locXX + tempX), (int)(locYY + tempY), (int)(locXX + tempXX), (int)(locYY + tempYY));
                        temp = temp + 20;
                        if (temp > 360) temp -= 360;
                    }
                    if (angel < 360)
                    {
                        angel += 3.5f;
                    }
                    else
                    {
                        angel = 0;
                    }
                }
                //SKILL TIMESTOP
                if (STOP2)
                {
                    if (timeStop_time <= 100)
                    {
                        graphics.FillEllipse(Brushes.Gray, posXtimestop_skill - radXtimestop_skill / 2, posYtimestop_skill - radYtimestop_skill / 2, radXtimestop_skill, radYtimestop_skill);
                        radXtimestop_skill += 45;
                        radYtimestop_skill += 45;
                    }
                    else
                    if (timeStop_time <= 200)
                    {
                        graphics.FillEllipse(Brushes.Gray, posXtimestop_skill - radXtimestop_skill / 2, posYtimestop_skill - radYtimestop_skill / 2, radXtimestop_skill, radYtimestop_skill);                        
                    }
                    else
                    {
                        //if (timeStop_time == 251) radXtimestop_skill = radYtimestop_skill = 2000;
                        posXtimestop_skill = (int)tankXpos_subject + tankWidth_subject / 2;
                        posYtimestop_skill = (int)tankYpos_subject + tankHeight_subject / 2;
                        radXtimestop_skill -= 45;
                        radYtimestop_skill -= 45;
                        graphics.FillEllipse(Brushes.Gray, posXtimestop_skill - radXtimestop_skill / 2, posYtimestop_skill - radYtimestop_skill / 2, radXtimestop_skill, radYtimestop_skill);
                    }
                    if (timeStop_time <= 200)
                    {
                        graphics.DrawArc(new Pen(Color.OrangeRed, 15), new Rectangle((int)tankXpos_subject + tankWidth_subject / 2 - 100, (int)tankYpos_subject + tankHeight_subject / 2 - 100, 200, 200), -90, -(int)(360.0 - ((1.0 * timeStop_time) / 201.0 * 360.0)));
                    }
                }
                //HighSpeed_skill
                if (!STOP1 && !STOP && !STOP2 && highspeed > 0)
                {
                    sizeHighSpeed_skill += highspeed;
                    if (sizeHighSpeed_skill <= 200) graphics.DrawEllipse(new Pen(Color.GreenYellow, 5), new Rectangle((int)tankXpos_subject + tankWidth_subject / 2 - sizeHighSpeed_skill / 2, (int)tankYpos_subject + tankHeight_subject / 2 - sizeHighSpeed_skill / 2, sizeHighSpeed_skill, sizeHighSpeed_skill));
                    if (sizeHighSpeed_skill > 600) sizeHighSpeed_skill = 0; 
                }
                //MeteorShower_skill
                if (meteorshower_skill == true)
                {
                        double temptime1 = Math.Min(1.0, 1.0 * timemeteorshower_time / 100.0);
                        double temptime2 = Math.Min(1.0, 1.0 * timemeteorshower_time / 200.0);
                        graphics.DrawEllipse(new Pen(Color.Aqua, 5), new Rectangle(positionXMouse_position - (int)(temptime1 * 100), positionYMouse_position - (int)(temptime1 * 100), (int)(temptime1 * 200),(int)(temptime1 * 200)));
                        graphics.DrawEllipse(new Pen(Color.Aqua, 5), new Rectangle(positionXMouse_position - (int)(temptime1 * 25), positionYMouse_position - (int)(temptime1 * 25), (int)(temptime1 * 50), (int)(temptime1 * 50)));
                        for (int i = -25; i >= -295; i -= 90)
                        {
                            if (i == -25 || i == -205)
                            graphics.DrawArc(new Pen(Color.Aqua, 5), new Rectangle(positionXMouse_position - 75, positionYMouse_position - 75, 150, 150), i, (int)(temptime1 * -40));
                            else
                            graphics.DrawArc(new Pen(Color.Aqua, 5), new Rectangle(positionXMouse_position - 75, positionYMouse_position - 75, 150, 150), i - 40,(int)(temptime1 * 40));
                        }
                }
                //Draw Bullet
                for (int i = 0; i < bulletDir.Count; i++)
                {
                    if (!bulletDir[i].finish)
                        graphics.FillEllipse(Brushes.Yellow, new Rectangle(bulletDir[i].Xpos - bulletDir[i].bulletWidth / 2,
                                                                           bulletDir[i].Ypos - bulletDir[i].bulletHeight / 2,
                                                                           bulletDir[i].bulletWidth, bulletDir[i].bulletHeight));
                }

                //Draw Bullet's Enemy
                for (int i = 0; i < bulletEnemy.Count; i++)
                {
                        graphics.FillEllipse(Brushes.DarkRed, new Rectangle(bulletEnemy[i].Xpos - bulletEnemy[i].bulletWidth / 2,
                                                                           bulletEnemy[i].Ypos - bulletEnemy[i].bulletHeight / 2,
                                                                           bulletEnemy[i].bulletWidth, bulletEnemy[i].bulletHeight));
                }

                //Draw Bloodcells
                for (int i = 0; i < bloodcells.Count; i++)
                {
                    if (bloodcells[i].damage == true) bloodcells[i].Solve(0);
                    if (bloodcells[i].damage == false) bloodcells.RemoveRange(i, 1);
                    else
                    {
                        Bullet X = bloodcells[i];
                        graphics.FillEllipse(X.brush, new Rectangle(X.bloodcellsXpos, X.bloodcellsYpos,
                                                                               X.bloodWidth, X.bloodHeight));
                    }
                }

                //Draw Enemy
                //Snipe_Monster
                for (int i = 0; i < enemy3.Count; i++)
                {
                    Snipe_Monster X = enemy3[i];
                    if (!X.Out)
                    {
                        if (X.Sniping)
                        {
                            graphics.DrawLine(new Pen(Color.Red, 2), X.Xpos, X.Ypos,
                               (int)(X.enemyXpos + 1800F * X.zz),
                                (int)(X.enemyYpos + 1800F * X.zzz));
                        }

                        graphics.DrawLine(pen4, X.Xpos, X.Ypos, (int)(X.enemyXpos + X.long_barrel * X.zz),
                                (int)(X.enemyYpos + X.long_barrel * X.zzz));

                        graphics.FillEllipse(X.brush, new Rectangle(X.Xpos - X.enemyWidth / 2,
                                                                                X.Ypos - X.enemyHeight / 2,
                                                                                X.enemyWidth, X.enemyHeight));
                        //Detect Enemy
                        if (X.targetX != -1 && X.targetX != -2)
                        {
                            X.time += 5;
                            if (X.time > 300) X.targetX = -1;
                        }
                        if (X.targetX != -1 && X.targetX != -2 && ((X.time >= 0 && X.time <= 100) || (X.time >= 200 && X.time <= 300)))
                        {
                            graphics.DrawPolygon(new Pen(Color.Red, 10), X.polypoint.ToArray());
                            graphics.FillRectangle(Brushes.Red, X.targetX - 7, X.targetY - 15, 14, 30);
                            graphics.FillRectangle(Brushes.Red, X.targetX - 7, X.targetY + 20, 14, 14);
                        }
                    }
                }
                //Normal_Monster
                for (int i = 0; i < enemy1.Count; i++)
                {
                    Normal_Monster X = enemy1[i];
                    if (!X.Out)
                    {
                        double angelX = X.angelX * 180F / Math.PI ;
                        if (X.zzz < 0) 
                        {
                            graphics.FillPie(X.brush, new Rectangle(X.Xpos - X.enemyWidth / 2, X.Ypos - X.enemyHeight / 2, X.enemyWidth, X.enemyHeight),
                            (float) -(angelX + X.sizeofMouth), (float) -(360F - (2F * X.sizeofMouth)));
                        }
                        else
                        {
                            graphics.FillPie(X.brush, new Rectangle(X.Xpos - X.enemyWidth / 2, X.Ypos - X.enemyHeight / 2, X.enemyWidth, X.enemyHeight),
                            (float) (angelX + X.sizeofMouth), (float) (360F - (2F*X.sizeofMouth)));
                        }
                        if (X.sizeofMouth == 60) X.plus = false;
                        if (X.sizeofMouth == 0) X.plus = true;
                        if (!STOP2) X.sizeofMouth += (X.plus) ? 2 : -2;

                        //Detect Enemy
                        if (X.targetX != -1 && X.targetX != -2)
                        {
                            X.time += 5;
                            if (X.time > 300) X.targetX = -1;
                        }
                        if (X.targetX != -1 && X.targetX != -2 && ((X.time >= 0 && X.time <= 100) || (X.time >= 200 && X.time <= 300)))
                        {
                            graphics.DrawPolygon(new Pen(Color.Red, 10), X.polypoint.ToArray());
                            graphics.FillRectangle(Brushes.Red, X.targetX - 7, X.targetY - 15, 14, 30);
                            graphics.FillRectangle(Brushes.Red, X.targetX - 7, X.targetY + 20, 14, 14);
                        }
                    }
                }

                //Draw EnergyBlock
                for (int i = 0; i < energyBlockX.Count; i++)
                {
                    int val = energyBlockval[i];
                    Brush brushes;
                    if (godeyes) brushes = Brushes.LightYellow;
                    else
                    if (val <= 40) brushes = Brushes.LightSteelBlue;
                    else
                    if (val <= 70) brushes = Brushes.SteelBlue;
                    else
                    if (val <= 100) brushes = Brushes.Blue;
                    else
                    if (val <= 130) brushes = Brushes.DarkBlue;
                    else
                        brushes = Brushes.Black;
                    if (energyBlockX[i] != -1)
                        graphics.FillRectangle(brushes, new Rectangle(energyBlockX[i] - energyBlockWidth / 2,
                                                                              energyBlockY[i] - energyBlockHeight / 2,
                                                                              energyBlockWidth, energyBlockHeight));
                }


                //Create TANK
                if (STOP1 && 30 <= timeStop_time && timeStop_time <= 50)
                {
                    temptank += 2;
                    graphics.DrawImage(tank, new Rectangle(pasttankXpos_subject + (temptank) / 2, pasttankYpos_subject + (temptank) / 2, tankWidth_subject - temptank, tankHeight_subject - temptank));
                    graphics.DrawImage(tank, new Rectangle((int)tankXpos_subject + (tankWidth_subject - temptank) / 2, (int)tankYpos_subject + (tankHeight_subject - temptank) / 2, temptank, temptank));
                }
                else
                if (STOP1 && timeStop_time < 30)
                {
                    graphics.DrawImage(tank, new Rectangle(pasttankXpos_subject, pasttankYpos_subject, tankWidth_subject, tankHeight_subject));
                }
                else
                {
                    graphics.DrawImage(tank, new Rectangle((int)tankXpos_subject, (int)tankYpos_subject, tankWidth_subject, tankHeight_subject));
                }


                // Timeleft-shooting
                if (tankYpos_subject - 25 > 0)
                {
                    graphics.DrawRectangle(pen2, (int)tankXpos_subject - 10, (int)tankYpos_subject - 25, tankWidth_subject + 20, 10);
                    double temp2 = 1.0 * (tankWidth_subject + 20) * ((double)Math.Min(timedelayBullet_time, limitdelayBullet_time) / limitdelayBullet_time);
                    graphics.FillRectangle(Brushes.Orange, (int)tankXpos_subject - 10, (int)tankYpos_subject - 25, (int)temp2, 10);
                }
                else
                {
                    graphics.DrawRectangle(pen2, (int)tankXpos_subject - 10, (int)tankYpos_subject + tankHeight_subject + 15, tankWidth_subject + 20, 10);
                    double temp2 = 1.0 * (tankWidth_subject + 20) * ((double)Math.Min(timedelayBullet_time, limitdelayBullet_time) / limitdelayBullet_time);
                    graphics.FillRectangle(Brushes.Orange, (int)tankXpos_subject - 10, (int)tankYpos_subject + tankHeight_subject + 15, (int)temp2, 10);
                }


                // Making gun barrel
                double x = (!STOP1) ? (1.0 * (tankXpos_subject + (tankWidth_subject / 2))) : ((STOP1 && timeStop_time <= 50)
                                    ? ((1.0 * (pasttankXpos_subject + (tankWidth_subject / 2)))) : (1.0 * (tankXpos_subject + (tankWidth_subject / 2))));
                double y = (!STOP1) ? (1.0 * (tankYpos_subject + (tankHeight_subject / 2))) : ((STOP1 && timeStop_time <= 50)
                                    ? ((1.0 * (pasttankYpos_subject + (tankHeight_subject / 2)))) : (1.0 * (tankYpos_subject + (tankHeight_subject / 2))));
                double xx = 1.0 * (1.0 * positionXMouse_position);
                double yy = 1.0 * (1.0 * positionYMouse_position);
                double z = Math.Sqrt(((xx - x) * (xx - x)) + ((yy - y) * (yy - y)));
                double zz = (1.0 * Math.Sin((xx - x) / z) * 50);
                double zzz = (1.0 * Math.Sin((yy - y) / z) * 50);
                double XXpos = (double)(x + zz);
                double YYpos = (double)(y + zzz);
                barrelXpos = (int)Math.Round(XXpos);
                barrelYpos = (int)Math.Round(YYpos);
                graphics.FillRectangle(Brushes.Green, new Rectangle((int)x - tankWidth_subject / 2 + 10,
                                                                (int)y - tankHeight_subject / 2 + 10, 20, 20));
                graphics.DrawLine(pen, (int)x, (int)y, barrelXpos, barrelYpos);


                //Draw enery left
                graphics.DrawRectangle(pen1, screenWidth - 245, 0, 230, 25);
                int tempenergy = (int)energyleft_subject;
                graphics.FillRectangle((energyleft_subject <= 30) ? Brushes.Red : (energyleft_subject <= 200) ? Brushes.Yellow : Brushes.Green, screenWidth - 240, 3, tempenergy, 20);

                //Draw Setting Panel
                if (settingpanelX_setting > 0 || settingpanelY_setting > 0)
                {
                    graphics.FillRectangle(Brushes.LightSalmon, new Rectangle(0, 40, settingpanelX_setting, settingpanelY_setting));
                    settingpanelX_setting -= (settingpanelX_setting > 0) ? 20 : 0;
                    settingpanelY_setting -= (settingpanelY_setting > 0) ? 20 : 0;
                }
                graphics.FillRectangle(Brushes.Orange, new Rectangle(0, 0, 40, 40));
                graphics.FillRectangle(Brushes.White, new Rectangle(10, 7, 20, 5));
                graphics.FillRectangle(Brushes.White, new Rectangle(10, 15, 20, 5));
                graphics.FillRectangle(Brushes.White, new Rectangle(10, 23, 20, 5));
            }
            else 
            {
                graphics.FillRectangle(Brushes.Orange, new Rectangle(0, 0, 40, 40));
                graphics.FillRectangle(Brushes.White, new Rectangle(7, 10, 5, 20));
                graphics.FillRectangle(Brushes.White, new Rectangle(15, 10, 5, 20));
                graphics.FillRectangle(Brushes.White, new Rectangle(23, 10, 5, 20));
                graphics.FillRectangle(Brushes.LightSalmon, new Rectangle(0, 40, settingpanelX_setting, settingpanelY_setting));
                if (settingpanelX_setting == 540 && settingpanelY_setting == 460)
                {
                    panel1.Visible = true;
                    StringFormat drawFormat  = new StringFormat();
                    drawFormat.Alignment = StringAlignment.Center;
                    Brush brush1;
                    Brush brush2;
                    if (SETTINGS_panel.Visible == true) 
                    { 
                        brush1 = Brushes.LightSalmon;
                        brush2 = Brushes.Gray;
                    }
                    else
                    {
                        brush1 = Brushes.Gray;
                        brush2 = Brushes.LightSalmon;
                    }
                    graphics.FillRectangle(((SETTINGS_panel.Visible) ? Brushes.LightSalmon : Brushes.Gray), new RectangleF(380, 28, 80, 12));
                    graphics.FillRectangle(((!SETTINGS_panel.Visible) ? Brushes.LightSalmon : Brushes.Gray), new RectangleF(460, 28, 80, 12));
                    graphics.DrawString("SETTING", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new RectangleF(380, 28, 80, 12), drawFormat);
                    graphics.DrawString("CONTROL", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, new RectangleF(460, 28, 80, 12), drawFormat);
                }
                settingpanelX_setting += (settingpanelX_setting < 540) ? 20 : 0;
                settingpanelY_setting += (settingpanelY_setting < 460) ? 20 : 0;
            }
        }
        private void APPLY_label_Click(object sender, EventArgs e)
        {
            
            int tempa = System.Convert.ToInt32(a_textBox.Text);
            if (tempa > 0 && tempa <= 10) speedEnemy_subject = tempa;
            int tempb = System.Convert.ToInt32(b_textBox.Text);
            if (tempb > 0 && tempb <= 10) speedTank_subject = tempb;
            int tempc = System.Convert.ToInt32(c_textBox.Text);
            if (tempc > 0 && tempc <= 50) speedBullet_subject = tempc;
            int tempd = System.Convert.ToInt32(d_textBox.Text);
            if (tempd >= 50 && tempd <= 100) limitdelayBullet_time = tempd;
            int tempe = System.Convert.ToInt32(e_textBox.Text);
            if (tempe > 0 && tempe <= 50) limitEnemy_number = tempe;
            int tempf = System.Convert.ToInt32(f_textBox.Text);
            if (tempf > 0 && tempf <= 10) limitEnergyBlock_number = tempf;
            if (a_comboBox.Text == "ENEMY CACULATION")
                score_enemy = true;
            else
            if (a_comboBox.Text == "TIME CACULATION")
                score_enemy = false;
            screenWidth = System.Convert.ToInt32(g_textBox.Text); 
            screenHeight = System.Convert.ToInt32(h_textBox.Text);
            if (BACKGROUND_picturebox.Size.Width - 10 != screenWidth || BACKGROUND_picturebox.Size.Height - 39 != screenHeight) {
                BACKGROUND_picturebox.Width = (BACKGROUND_picturebox.Size.Width - 10 != screenWidth) ? screenWidth : BACKGROUND_picturebox.Width;
                BACKGROUND_picturebox.Height = (BACKGROUND_picturebox.Size.Height - 39 != screenHeight) ? screenHeight : BACKGROUND_picturebox.Height;
                Size formSize = new Size(screenWidth + 10, screenHeight + 39);
                this.Size = new Size(formSize.Width, formSize.Height);
                this.Location = new Point((int) (countscreenWidth / 2 - (screenWidth + 10) / 2),(int) (countscreenHeight / 2 - (screenHeight + 39) / 2));               
                double tempp1 = 300.0, tempp2 = 70.0;
                screenWidth -= (BACKGROUND_picturebox.Size.Width != screenWidth) ? 10 : 0;
                screenHeight -= (BACKGROUND_picturebox.Size.Height != screenHeight) ? 39 : 0;
                a_pictureBox.Width = b_pictureBox.Width = c_pictureBox.Width = (int)Math.Round(screenWidth / countscreenWidth * tempp1);
                a_pictureBox.Height = b_pictureBox.Height = c_pictureBox.Height = (int)Math.Round(screenHeight / countscreenHeight * tempp2);
                SKILL1_label.Font = SKILL2_label.Font = SKILL3_label.Font = new Font("Showcard Gothic", (int)Math.Min(Math.Max(1, a_pictureBox.Size.Width / tempp1 * 22.0), Math.Max(1, a_pictureBox.Size.Height / tempp2 * 22.0)), FontStyle.Bold);
                c_pictureBox.Top = screenHeight - (int)Math.Round(1.0 * screenHeight / countscreenHeight * 1.0 * c_pictureBox.Height);
                b_pictureBox.Top = screenHeight - (int)Math.Round(1.0 * screenHeight / countscreenHeight * 1.0 * b_pictureBox.Height) * 2;
                a_pictureBox.Top = screenHeight - (int)Math.Round(1.0 * screenHeight / countscreenHeight * 1.0 * a_pictureBox.Height) * 3;
                SKILL1_label.Top = c_pictureBox.Top;// + Math.Max(0, c_pictureBox.Size.Height - SKILL1_label.Size.Height);
                SKILL2_label.Top = b_pictureBox.Top;// + Math.Max(0, b_pictureBox.Size.Height - SKILL2_label.Size.Height);
                SKILL3_label.Top = a_pictureBox.Top;// + Math.Max(0, a_pictureBox.Size.Height - SKILL3_label.Size.Height);
                POSITION_label.Left = screenWidth - 126 - 10;
                POSITION_label.Top = screenHeight - 25 - 15;
                ENERGY_label.Left = screenWidth - 245 - ENERGY_label.Size.Width;            
            } 
            Show_Setting();
            Init_Game();
            STOP = true;
            panel1.Visible = false;
            SETTINGS_panel.Visible = true;
            CONTROL_panel.Visible = false;
            settingPanel = false;
        }
        private void CANCEL_label_Click(object sender, EventArgs e)
        {
            Show_Setting();
            panel1.Visible = false;
            SETTINGS_panel.Visible = true;
            CONTROL_panel.Visible = false;
            settingPanel = false;
        }
        private void OK_label_Click(object sender, EventArgs e)
        {
            Show_Setting();
            panel1.Visible = false;
            SETTINGS_panel.Visible = true;
            CONTROL_panel.Visible = false;
            settingPanel = false;
        }
    }
}
