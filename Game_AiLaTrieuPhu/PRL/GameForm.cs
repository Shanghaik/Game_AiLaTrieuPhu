using Game_AiLaTrieuPhu.BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_AiLaTrieuPhu.PRL
{
    public partial class GameForm : Form
    {
        GameServices services = new GameServices();
        public GameForm()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            var question = services.RandomQuestion(1);
            tbt_Question.Text = question.QuestionText;
            btn_A.Text = question.AnswerA;
            btn_B.Text = question.AnswerA;
            btn_C.Text = question.AnswerA;
            btn_D.Text = question.AnswerA;

        }
    }
}
