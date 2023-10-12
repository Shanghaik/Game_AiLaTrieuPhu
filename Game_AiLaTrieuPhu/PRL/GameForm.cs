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
        int selectedID;
        public GameForm()
        {
            InitializeComponent();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            while (selectedQuestions.Count < services.CountQuestionLevel(1))
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
                    selectedID = question.Id; // Gán id câu hỏi cho biến lưu
                    break;
                }
                else continue;
            }
        }

        public void CheckTrue(string answer)
        {
            if (services.CheckTrueAnswer(selectedID, answer))
            {
                MessageBox.Show("Đúng");
            }
            else MessageBox.Show("Sai");
        }
        private void btn_A_Click(object sender, EventArgs e)
        {
            CheckTrue("A");
        }

        private void btn_B_Click(object sender, EventArgs e)
        {
            CheckTrue("B");
        }

        private void btn_C_Click(object sender, EventArgs e)
        {
            CheckTrue("C");
        }

        private void btn_D_Click(object sender, EventArgs e)
        {
            CheckTrue("D");
        }

        private void ptb_5050_Click(object sender, EventArgs e)
        {

        }

        private void ptb_Viewer_Click(object sender, EventArgs e)
        {
            // Thao túng tỉ lệ để xác xuất thua là nhỏ khi chọn hỗ trợ từ khán giả
            // Biết đáp án đúng
            string trueAnswer = services.GetTrueAnswer(selectedID);
            Random r = new Random();
            // random tỉ lệ cho những đáp án khác
            int r1 = r.Next(0, 30);
            int r2 = r.Next(0, 30);
            int r3 = r.Next(0, 30);
            int rTrue = 100 - r1 - r2 - r3;
            string show;
            if (trueAnswer == "A") show = $"A: {rTrue}\nB: {r1}\nC: {r2}\nD:{r3}";
            else if (trueAnswer == "B") show = $"A: {r1}\nB: {rTrue}\nC: {r2}\nD:{r3}";
            else if (trueAnswer == "C") show = $"A: {r1}\nB: {r2}\nC: {rTrue}\nD:{r3}";
            else show = $"A: {r1}\nB: {r2}\nC: {r3}\nD:{rTrue}";
            MessageBox.Show(show);
        }

        private void ptb_Pro_Click(object sender, EventArgs e)
        {

        }

        private void ptb_Change_Click(object sender, EventArgs e)
        {

        }
    }
}
