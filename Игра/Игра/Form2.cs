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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            InitializeComponent();
            SoundPlayer sndPlayer = new SoundPlayer(Directory.GetCurrentDirectory() + @"\golosovanie.wav");
            sndPlayer.Play();
        }
        
        

        private void PressEnter_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1(this.Size);
            f1.Show();
        }
        

        private void Exit2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Form1 f1 = new Form1(this.Size);
                f1.Show();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void WarpedCity_Click(object sender, EventArgs e)
        {
            SoundPlayer sndPlayer = new SoundPlayer(Directory.GetCurrentDirectory() + @"\golosovanie.wav");
            sndPlayer.Play();
        }
    }
    
    
}
