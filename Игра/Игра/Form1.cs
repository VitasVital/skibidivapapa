using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;


namespace Игра
{
    public partial class Form1 : Form
    {
        Graphics gr;
        Thread shooting;
        Stack<Point> grenades = new Stack<Point>();
        string[] sprites = new string[9];
        Image[] images = new Image[9];
        Player player = new Player();
        Drone drone = new Drone();
        Vehicles vehicle = new Vehicles();
        Point pos = new Point(60, 60);
        //Image back;
        Image shot;

        public Form1(Size size)
        {
            InitializeComponent();
            //back = Image.FromFile(Directory.GetCurrentDirectory() + @"\sity.jpg");
            this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            gr = panel1.CreateGraphics();
            player.position = new Point(60, 320);
            drone.position = new Point(700, 150);
            vehicle.position = new Point(1500, 320);
            shooting = new Thread(shoot);
            shot = Image.FromFile(Directory.GetCurrentDirectory() + @"\shot\shot-2.png");
            SoundPlayer sndPlayer = new SoundPlayer(Directory.GetCurrentDirectory() + @"\MinecraftMain.wav");
            sndPlayer.Play();
        }


        public Form1(Form2 f)
        {
            InitializeComponent();
        }
        
        

        private void shoot(object playerIn)
        {
            /*Player player = (Player)playerIn;
            int currentdirection = player.Direction;
            Point f = new Point(0, 0);
            try
            {
                f = grenades.Pop();
            }
            catch { return; }
            f.X = player.position.X + player.player.Width / 2 - 5;
            f.Y = player.position.Y + player.player.Height / 2 - 5;
            while (f.X > 0 && f.X < panel1.Width && f.Y > 0 && f.Y < panel1.Height)
            {
                try
                {
                    switch (currentdirection)
                    {
                        case 0: { f.Y -= 10; break; }
                        case 1: { f.Y += 10; break; }
                        case 2: { f.X -= 10; break; }
                        case 3: { f.X += 10; break; }

                    }
                    gr.DrawImage(shot, f);
                    Thread.Sleep(50);
                }
                catch { }
            }
            grenades.Push(new Point(-5, -5));*/


        }

        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }

            if (e.KeyCode == Keys.Up)
            {
                timer1.Enabled = false;
                timer2.Enabled = true;
                timer1.Enabled = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                //player.position = new Point(player.position.X, player.position.Y + 5);
            }

            if (e.KeyCode == Keys.Left)
            {
                player.position = new Point(player.position.X - 5, player.position.Y);
            }

            if (e.KeyCode == Keys.Right)
            {
                player.position = new Point(player.position.X + 5, player.position.Y);
            }


        }

        private void Exit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int time1 = 0;
        public void timer1_Tick(object sender, EventArgs e)
        {
            gr.Clear(Color.Green);
            gr.DrawImage(player.imagesshoot[player.currentimage], player.position);
            time1 += timer1.Interval;
            if (time1 >= 50)
            {
                player.currentimage++;
                if (player.currentimage == images.Length)
                    player.currentimage = 0;
                time1 = 0;
            }
        }
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            SoundPlayer piu = new SoundPlayer(Directory.GetCurrentDirectory() + @"\piu.wav");
            piu.Play();
            shooting = new Thread(shoot);
            shooting.Start(player);
        }

        int time2 = 0;
        bool visota = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            gr.Clear(Color.Green);
            gr.DrawImage(player.jump, player.position);
            time2 += timer2.Interval;
            if (time2 >= 10 && visota == false)
            {
                player.position.Y-=3;
                time2 = 0;
                if (player.position.Y < 100)
                {
                    visota = true;
                }
            }
            if (time2 >= 10 && visota == true)
            {
                player.position.Y+=3;
                time2 = 0;
                if (player.position.Y > 320)
                {
                    timer2.Enabled = false;
                    visota = false;
                }
            }
        }

        int time3 = 0;
        bool viselzagran = false;
        bool udar = false;
        bool message = false;
        private void timer3_Tick(object sender, EventArgs e)
        {
            gr.DrawImage(vehicle.imagesvehicles[vehicle.currentimage], vehicle.position);
            time3 += timer3.Interval;
            if (time3 >= 10 && viselzagran == false)
            {
                vehicle.position.X -= 3;
                time3 = 0;
                if (vehicle.position.X < -500)
                {
                    viselzagran = true;
                }
            }
            if (viselzagran == true)
            {
                vehicle.currentimage++;
                if (vehicle.currentimage == 4)
                {
                    vehicle.currentimage = 0;
                }
                vehicle.position.X = 1500;
                viselzagran = false;
                udar = false;
            }
            if (vehicle.position.Y + 20 > player.position.Y && vehicle.position.Y - 20 < player.position.Y && vehicle.position.X + 20 > player.position.X && vehicle.position.X - 20 < player.position.X && udar == false)
            {
                SoundPlayer uronchik = new SoundPlayer(Directory.GetCurrentDirectory() + @"\uron.wav");
                uronchik.Play();
                udar = true;
                HP.Width -= 100;
            }
            if (HP.Width == 0 && message == false)
            {
                message = true;
                MessageBox.Show("Вы погибли(((");
                this.Close();
            }
        }

        int time4 = 0;
        bool posit = false;
        private void timer4_Tick(object sender, EventArgs e)
        {
            gr.DrawImage(drone.droneimg, drone.position);
            time4 += timer4.Interval;
            if (time4 >= 10)
            {
                time4 = 0;
                if (drone.position.Y < 300 && posit == false)
                {
                    drone.position.Y += 3;
                    if (drone.position.Y > 270)
                    {
                        posit = true;
                    }
                }
                if (drone.position.Y > 100 && posit == true)
                {
                    drone.position.Y -= 3;
                    if (drone.position.Y < 130)
                    {
                        posit = false;
                    }
                }
            }
        }
    }

    class Drone
    {
        public Point position;
        public Image droneimg;
        public Image boomdrone;
        public Drone()
        {
            droneimg = Image.FromFile(Directory.GetCurrentDirectory() + @"\drone_preview.gif");
            boomdrone = Image.FromFile(Directory.GetCurrentDirectory() + @"\enemy-explosion-3.png");
        }
    }

    class Vehicles
    {
        public Point position;
        public string[] spritesvehicles;
        public Image[] imagesvehicles = new Image[4];
        public int currentimage = 0;
        public Vehicles()
        {
            spritesvehicles = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\vehicles");
            for (int i = 0; i < imagesvehicles.Length; i++)
            {
                imagesvehicles[i] = Image.FromFile(spritesvehicles[i]);
            }
        }
    }

    public class Player
    {
        public Point position;
        public int Direction = 0, prevDirection = 0;
        public string [] spritesrun;
        public string[] spritesshoot;
        public Image[] imagesrun = new Image[9];
        public Image[] imagesshoot = new Image[9];
        public Image player;
        public Image jump;
        public int currentimage=0;
        public Player()
        {
            jump = Image.FromFile(Directory.GetCurrentDirectory() + @"\jump-4.png");
            spritesrun = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\run");
            spritesshoot = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\run-shoot");
            for (int i = 0; i < imagesrun.Length; i++)
            {
                imagesrun[i] = Image.FromFile(spritesrun[i]);
            }
            for (int i = 0; i < imagesshoot.Length; i++)
            {
                imagesshoot[i] = Image.FromFile(spritesshoot[i]);
            }
        }
    }
}
