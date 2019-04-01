using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Игра
{
    public partial class Form1 : Form
    {
        void Run()
        {
           
        }
        
        void Shoot()
        {

        }

        public Form1(Size size)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
        }

        Enemy e = new Enemy();

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
        public int Direction = 0, prevDirection = 0;
        public Image PlayerImage;
        int type = 0;
        public Keys keyUp;
        public Keys keyDown;
        public Keys keyLeft;
        public Keys keyRight;
        public Keys keyFire;
    }
}
