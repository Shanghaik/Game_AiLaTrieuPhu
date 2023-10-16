using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_AiLaTrieuPhu.PRL
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            SoundPlayer play = new SoundPlayer(@"C:\Users\Acer\Desktop\DHBC\Nhac\Intro.wav");
            play.Play();
            ptb_Play.BackColor = Color.FromArgb(0, 0, 0, 0);
            ptb_Exit.BackColor = Color.FromArgb(0, 0, 0, 0);
        }

        private void ptb_Play_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm();
            this.Visible = false;
            gameForm.ShowDialog();
            this.Close();
            
            
        }
    }
}
