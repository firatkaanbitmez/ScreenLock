using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenLock
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void ScreenLoad()
        {
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Left = Top = 0;
            Width = Screen.PrimaryScreen.WorkingArea.Width;
            Height = Screen.PrimaryScreen.WorkingArea.Height;
            this.Bounds = Screen.PrimaryScreen.Bounds;
            this.TopMost = true;
            ShowInTaskbar = false;
            Visible = true;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ScreenLoad();

            

        }
    }
}
