namespace Игра
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WarpedCity = new System.Windows.Forms.PictureBox();
            this.PressEnter = new System.Windows.Forms.PictureBox();
            this.Exit2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.WarpedCity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressEnter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit2)).BeginInit();
            this.SuspendLayout();
            // 
            // WarpedCity
            // 
            this.WarpedCity.BackColor = System.Drawing.Color.Transparent;
            this.WarpedCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WarpedCity.ErrorImage = global::Игра.Resource2.title_screen;
            this.WarpedCity.Image = global::Игра.Resource2.title_screen;
            this.WarpedCity.InitialImage = global::Игра.Resource2.title_screen;
            this.WarpedCity.Location = new System.Drawing.Point(0, 0);
            this.WarpedCity.Name = "WarpedCity";
            this.WarpedCity.Size = new System.Drawing.Size(883, 391);
            this.WarpedCity.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.WarpedCity.TabIndex = 0;
            this.WarpedCity.TabStop = false;
            this.WarpedCity.Click += new System.EventHandler(this.WarpedCity_Click);
            // 
            // PressEnter
            // 
            this.PressEnter.BackColor = System.Drawing.Color.Transparent;
            this.PressEnter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PressEnter.Image = global::Игра.Resource2.press_enter_text;
            this.PressEnter.Location = new System.Drawing.Point(0, 316);
            this.PressEnter.Name = "PressEnter";
            this.PressEnter.Size = new System.Drawing.Size(883, 75);
            this.PressEnter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PressEnter.TabIndex = 1;
            this.PressEnter.TabStop = false;
            this.PressEnter.Click += new System.EventHandler(this.PressEnter_Click);
            // 
            // Exit2
            // 
            this.Exit2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit2.BackColor = System.Drawing.Color.Transparent;
            this.Exit2.ErrorImage = global::Игра.Resource2.banner_arrow;
            this.Exit2.Image = global::Игра.Resource2.banner_arrow;
            this.Exit2.Location = new System.Drawing.Point(855, 12);
            this.Exit2.Name = "Exit2";
            this.Exit2.Size = new System.Drawing.Size(16, 33);
            this.Exit2.TabIndex = 2;
            this.Exit2.TabStop = false;
            this.Exit2.Click += new System.EventHandler(this.Exit2_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Игра.Resource2.bg_1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(883, 391);
            this.Controls.Add(this.Exit2);
            this.Controls.Add(this.PressEnter);
            this.Controls.Add(this.WarpedCity);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form2_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.WarpedCity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PressEnter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox WarpedCity;
        private System.Windows.Forms.PictureBox PressEnter;
        private System.Windows.Forms.PictureBox Exit2;
    }
}