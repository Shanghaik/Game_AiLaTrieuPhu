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
    public partial class ProForm : Form
    {
        string answer;
        public ProForm(string answer)
        {
            InitializeComponent();
            this.answer = answer;
            lb_Answer.BackColor = Color.White;
            lb_Answer.Text = "Hãy chọn:\n    "+answer;
            SoundPlayer play = new SoundPlayer(@"C:\Users\Acer\Desktop\DHBC\Nhac\dun dun dun.wav");
            play.Play();

        }
    }
}
