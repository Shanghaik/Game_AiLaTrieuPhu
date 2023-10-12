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
        // tạo 1 biến dạng List<int> toàn cục để lưu lại danh sách Id những câu hỏi đã dc chọn
        List<int> selectedQuestions = new List<int>();
        public GameForm()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            while(selectedQuestions.Count< services.CountQuestionLevel(1))
            {
                var question = services.RandomQuestion(1);
                // Nếu câu hỏi random được chọn có id không nằm trong danh sách đã dc chọn
                if (!selectedQuestions.Contains(question.Id))
                {
                    tbt_Question.Text = question.QuestionText;
                    btn_A.Text = question.AnswerA;
                    btn_B.Text = question.AnswerB;
                    btn_C.Text = question.AnswerC;
                    btn_D.Text = question.AnswerD;
                    selectedQuestions.Add(question.Id);
                    break;
                }
                else continue;
            }
        }
    }
}
