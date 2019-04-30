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
        Shot shot = new Shot();
        Drshot drshot = new Drshot();
        Image back;

        public Form1(Size size)
        {
            InitializeComponent();
            back = Image.FromFile(Directory.GetCurrentDirectory() + @"\sity.jpg");
            this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            gr = panel1.CreateGraphics();
            player.position = new Point(60, 320);
            drone.position = new Point(700, 150);
            vehicle.position = new Point(1500, 320);
        }


        public Form1(Form2 f)
        {
            InitializeComponent();
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
            }

            if (e.KeyCode == Keys.Down)
            {

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
            timer5.Enabled = true;
        }

        int time2 = 0, v = 20;
        bool visota = false;
        private void timer2_Tick(object sender, EventArgs e)
        {
            
            gr.DrawImage(player.jump, player.position);
            time2 += timer2.Interval;
            if (time2 >= 30 && visota == false)
            {
                v-=1;
                player.position.Y-= v;
                time2 = 0;
                if (player.position.Y < 150)
                {
                    visota = true;
                    v = 0;
                }
            }
            if (time2 >= 30 && visota == true)
            {
                v+=1;
                player.position.Y+=v;
                time2 = 0;
                if (player.position.Y > 320)
                {
                    player.position.Y = 320;
                    timer2.Enabled = false;
                    timer1.Enabled = true;
                    visota = false;
                    v = 20;
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
                vehicle.position.X -= 10;
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
            if (vehicle.position.Y + 20 > player.position.Y && vehicle.position.Y - 10 < player.position.Y && vehicle.position.X + 50 > player.position.X && vehicle.position.X - 40 < player.position.X && udar == false)
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


        int time5 = 0;
        bool startshot = false;
        bool popal = false;
        int num = 0;
        private void Timer5_Tick(object sender, EventArgs e)
        {
            if (startshot == false)
            {
                SoundPlayer piu = new SoundPlayer(Directory.GetCurrentDirectory() + @"\piu.wav");
                piu.Play();
                shot.position.X = player.position.X + 25;
                shot.position.Y = player.position.Y + 25;
                startshot = true;
                popal = false;
            }
            if (drone.position.X + 50 > shot.position.X && drone.position.X< shot.position.X
                && drone.position.Y + 50 > shot.position.Y && drone.position.Y < shot.position.Y 
                && popal == false)
            {
                if (num == 0 && popal == false)
                {
                    popal = true;
                    SoundPlayer popadanie = new SoundPlayer(Directory.GetCurrentDirectory() + @"\popal.wav");
                    popadanie.Play();
                    num++;
                    shot.position.X = -30;
                    startshot = false;
                    timer5.Enabled = false;
                }
                if (num == 1 && popal == false)
                {
                    popal = true;
                    SoundPlayer popadanie = new SoundPlayer(Directory.GetCurrentDirectory() + @"\guchiyea.wav");
                    popadanie.Play();
                    num++;
                    shot.position.X = -30;
                    startshot = false;
                    timer5.Enabled = false;
                }
                if (num == 2 && popal == false)
                {
                    popal = true;
                    SoundPlayer popadanie = new SoundPlayer(Directory.GetCurrentDirectory() + @"\guchiuron.wav");
                    popadanie.Play();
                    num++;
                    shot.position.X = -30;
                    startshot = false;
                    timer5.Enabled = false;
                }
                if (num == 3 && popal == false)
                {
                    popal = true;
                    SoundPlayer popadanie = new SoundPlayer(Directory.GetCurrentDirectory() + @"\theovernight.wav");
                    popadanie.Play();
                    num++;
                    shot.position.X = -30;
                    startshot = false;
                    timer5.Enabled = false;
                }
                if (num == 4 && popal == false)
                {
                    popal = true;
                    SoundPlayer popadanie = new SoundPlayer(Directory.GetCurrentDirectory() + @"\youlikechalanges.wav");
                    popadanie.Play();
                    num++;
                    shot.position.X = -30;
                    startshot = false;
                    timer5.Enabled = false;
                }
                pictureBox2.Width -= 50;
            }
            gr.DrawImage(shot.pum, shot.position);
            time5 += timer5.Interval;
            if (time5 >= 10)
            {
                time5 = 0;
                if (shot.position.X<1000 && popal == false)
                {
                    shot.position.X += 10;
                }
                else
                {
                    shot.position.X = -30;
                    popal = false;
                    startshot = false;
                    timer5.Enabled = false;
                }
            }
        }

        int x = 0;
        private void Timer6_Tick(object sender, EventArgs e)
        {
            gr.DrawImage(back, x, -300);
            if (x > -800)
            {
                x--;
            }
        }


        int time7 = 0;
        bool droneshot = false;
        bool dronepopal = false;
        private void Timer7_Tick(object sender, EventArgs e)
        {
            if (drone.position.Y < player.position.Y + 20 && drone.position.Y > player.position.Y - 20
                && droneshot == false && visota == false)
            {
                SoundPlayer piu = new SoundPlayer(Directory.GetCurrentDirectory() + @"\tiau.wav");
                piu.Play();
                droneshot = true;
                drshot.position.X = drone.position.X;
                drshot.position.Y = drone.position.Y + 10;
                droneshot = true;
                dronepopal = false;
            }
            if (player.position.X + 50 > drshot.position.X && player.position.X < drshot.position.X
                && player.position.Y + 50 > drshot.position.Y && player.position.Y < drshot.position.Y
                && dronepopal == false)
            {
                if (dronepopal == false)
                {
                    dronepopal = true;
                    SoundPlayer popadanie = new SoundPlayer(Directory.GetCurrentDirectory() + @"\krik.wav");
                    popadanie.Play();
                    drshot.position.X = -30;
                    droneshot = false;
                }
                HP.Width -= 50;
            }
            gr.DrawImage(drshot.pum, drshot.position);
            time7 += timer7.Interval;
            if (time7 >= 10)
            {
                time7 = 0;
                if (drshot.position.X > 0 && droneshot == true)
                {
                    drshot.position.X -= 10;
                }
                else
                {
                    drshot.position.X = -30;
                    dronepopal = false;
                    droneshot = false;
                }
            }
        }

        int time4 = 0;
        bool posit = false;
        bool alive = true;
        private void timer4_Tick(object sender, EventArgs e)
        {
            if (alive == true)
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
                if (pictureBox2.Width == 0)
                {
                    alive = false;
                }
            }
            if (alive == false && message == false)
            {
                time4 += timer4.Interval;
                gr.DrawImage(drone.deaddrone[drone.currentimage], drone.position);
                if (time4 >= 50)
                {
                    drone.currentimage++;
                    if (drone.currentimage == 6)
                    {
                        SoundPlayer win = new SoundPlayer(Directory.GetCurrentDirectory() + @"\guchimuchi.wav");
                        win.Play();
                        message = true;
                        MessageBox.Show("Вы пабидили)))");
                        this.Close();
                    }
                }
            }
        }
    }

    class Shot
    {
        public Point position;
        public Image pum;
        public bool zaniat;
        public DateTime timeshot;
        public Shot()
        {
            pum = Image.FromFile(Directory.GetCurrentDirectory() + @"\shot\shot-2.png");
            position.X = 200;
            position.Y = 100;
        }
    }
    class Drshot
    {
        public Point position;
        public Image pum;
        public bool zaniat;
        public DateTime timeshot;
        public Drshot()
        {
            pum = Image.FromFile(Directory.GetCurrentDirectory() + @"\shot-hit\shot-hit-1.png");
            position.X = 1;
            position.Y = -1;
        }
    }
    class Drone
    {
        public Point position;
        public Image droneimg;
        public Image boomdrone;
        public string[] spritedeaddrone;
        public Image[] deaddrone = new Image[6];
        public int currentimage = 0;
        public Drone()
        {
            droneimg = Image.FromFile(Directory.GetCurrentDirectory() + @"\drone_preview.gif");
            spritedeaddrone = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\enemy-explosion");
            for (int i = 0; i < deaddrone.Length; i++)
            {
                deaddrone[i] = Image.FromFile(spritedeaddrone[i]);
            }
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
