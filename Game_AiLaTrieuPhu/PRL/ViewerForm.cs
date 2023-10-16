using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_AiLaTrieuPhu.PRL
{
    public partial class ViewerForm : Form
    {
        int[] buttonPercent;
        public ViewerForm(int[] buttonPercent)
        {
            InitializeComponent();
            SoundPlayer play = new SoundPlayer(@"C:\Users\Acer\Desktop\DHBC\Nhac\Xoso.wav");
            play.Play();
            this.buttonPercent = buttonPercent;
            CreateControls();
        }
        private void CreateControls()
        {
            int y = 10;
            // Label 1
            Label APer = new Label();
            APer.Text = buttonPercent[0] + "%";
            APer.Location = new Point(10, y);
            APer.Font = new Font("Arial", 14, FontStyle.Bold);
            this.Controls.Add(APer);

            // Button 1
            Button A = new Button();
            A.Text = "";
            A.Height = 60; A.Width = 10 * buttonPercent[0];
            A.Location = new Point(10, y += APer.Height + 5);
            A.BackColor = Color.Red;
            this.Controls.Add(A);

            // Label 2 
            Label BPer = new Label();
            BPer.Text = buttonPercent[1] + "%";
            BPer.Location = new Point(10, y += A.Height + 5);
            BPer.Font = new Font("Arial", 14, FontStyle.Bold);
            this.Controls.Add(BPer);

            // Button 2
            Button B = new Button();
            B.Text = "";
            B.Height = 60; B.Width = 10 * buttonPercent[1];
            B.Location = new Point(10, y += BPer.Height + 5);
            B.BackColor = Color.Yellow;
            this.Controls.Add(B);

            // Label 3
            Label CPer = new Label();
            CPer.Text = buttonPercent[2] + "%";
            CPer.Location = new Point(10, y += B.Height + 5);
            CPer.Font = new Font("Arial", 14, FontStyle.Bold);
            this.Controls.Add(CPer);

            // Button 3 
            Button C = new Button();
            C.Text = "";
            C.Height = 60; C.Width = 10 * buttonPercent[2];
            C.Location = new Point(10, y += CPer.Height + 5);
            C.BackColor = Color.Blue;
            this.Controls.Add(C);

            // Label 4
            Label DPer = new Label();
            DPer.Text = buttonPercent[3] + "%";
            DPer.Location = new Point(10, y += C.Height + 5);
            DPer.Font = new Font("Arial", 14, FontStyle.Bold);
            this.Controls.Add(DPer);

            // Button 4
            Button D = new Button();
            D.Text = "";
            D.Height = 60; D.Width = 10 * buttonPercent[3];
            D.Location = new Point(10, y += DPer.Height + 5);
            D.BackColor = Color.Green; ;
            this.Controls.Add(D);


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
