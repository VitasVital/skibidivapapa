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

namespace Игра
{
    public partial class Form1 : Form
    {
        Graphics gr;
        Thread shooting;
        Stack<Point> grenades = new Stack<Point>();
        Image dot;
        Player player = new Player();

        void Run()
        {
           
        }
        

        public Form1(Size size)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
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
                //player.position = new Point(player.position.X, player.position.Y + 2);
                player1.Location = new Point(player1.Top + 10, player1.Left); //вопрос
            }

            if (e.KeyCode == Keys.Down)
            {
                player.position = new Point(player.position.X, player.position.Y + 2);
            }

            if (e.KeyCode == Keys.Left)
            {
                player.position = new Point(player.position.X, player.position.Y + 2);
            }

            if (e.KeyCode == Keys.Right)
            {
                player.position = new Point(player.position.X, player.position.Y + 2);
            }
            

        }

        private void Exit1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
    class Enemy
    {
        //private:

    }
    public class Player
    {
        public Point position;
        public Image player;
        public Player()
        {
            player = Image.FromFile(Directory.GetCurrentDirectory() + @"\walk-13.png");
        }
    }
}
