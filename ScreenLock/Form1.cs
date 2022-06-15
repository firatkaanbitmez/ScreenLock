using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Squirrel;

namespace ScreenLock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();            

        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            textpass.UseSystemPasswordChar = true;
            textpass.Visible = false;
            ScreenLoad();


        }
        
        protected override void OnLoad(EventArgs e)
        {
            ed.KeyHook();                                                 
            base.OnLoad(e);            

        }

        EnableDisableKeys ed = new EnableDisableKeys();

        private void Form1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (textpass.Text == "")
            {

                if (textpass.CanFocus) textpass.Focus();
                e.Cancel = true;
                return;
            }            

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
        public string versionNum;
        private void AddVersionNumber()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            versionNum = versionInfo.FileVersion;


        }
        private async void CheckForUpdates()
        {
            try
            {
                using (var mgr = await UpdateManager.GitHubUpdateManager("https://github.com/firatkaanbitmez/ScreenLock"))
                {
                    var release = await mgr.UpdateApp();
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed check for updates" + e.ToString());
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            if (textpass.Visible == false) 
            { 
                textpass.Visible = true;
                textpass.SelectAll();
                textpass.Focus();
                
            }
            else
            {
                textpass.Visible = false;
            }


        }
       
        private void button1_Click(object sender, EventArgs e)
        {
             
            if (textpass.Text == "19051905asd")
            {
                this.Close();
                Application.Exit();
            }
        }

        
    }
}
