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
        int timeLimit = 30; // Gán 1 biến toàn cục để làm thời gian để đếm ngược
        int level = 1; // level mặc định là 1
        // Mảng question Money chứa tiền thưởng ứng với từng mốc câu hỏi
        int[] questionMoney = new int[15] { 1000000, 2000000, 3000000, 5000000, 10000000, 15000000, 23000000, 40000000,
            60000000, 100000000, 150000000, 250000000, 400000000, 600000000, 999999999 };
        int selectedIndex = 0;
        public GameForm()
        {
            InitializeComponent();
        }


        public void RandomQuestionShow()
        {
            lb_Time.Text = "30";
            timeLimit = 30;
            
            while (selectedQuestions.Count < services.CountQuestionLevel(level)) // Kiểm tra số lượng câu hỏi theo lv nó nhỏ hơn cái lv đ
            {
                var question = services.RandomQuestion(level);
                // Nếu câu hỏi random được chọn có id không nằm trong danh sách đã dc chọn
                if (!selectedQuestions.Contains(question.Id))
                {
                    tbt_Question.Text = $"Câu  hỏi số {(selectedIndex + 1)}: "+  question.QuestionText; // Hiển thị là câu hỏi số mấy
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
                // Update tiền thắng
                lb_Money.Text = questionMoney[selectedIndex].ToString();
                selectedIndex++; // Update vị trí phần thưởng ứng với câu hỏi
                // Nếu vị trí câu hỏi từ 6 đên 10 thì lv 2 (selectedIndex (5-9)
                // Nếu vị trí câu hỏi từ 11 - 15 thì là lv 3 (selectedIndex (10-14)
                if (selectedIndex == 10) { level = 3; selectedQuestions.Clear(); }
                else if (selectedIndex == 5) { level = 2; selectedQuestions.Clear(); }
                // Sau khi update level thì randomQuestion sẽ theo lv đó
                RandomQuestionShow(); // Khi đúng thì ta load thêm câu hỏi mới
            }
            else
            {
                MessageBox.Show("Sai, bạn ra về với số tiền là " + lb_Money.Text);
                grb_Cauhoi.Enabled = false;
                return;
            }
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
            string trueAnswer = services.GetTrueAnswer(selectedID);
            Random r = new Random();
            int hold = r.Next(1, 3);
            if (trueAnswer == "A")
            {
                if (hold == 1) { btn_C.Text = ""; btn_D.Text = ""; }
                else if (hold == 2) { btn_B.Text = ""; btn_D.Text = ""; }
                else { btn_C.Text = ""; btn_B.Text = ""; }
            }
            else if (trueAnswer == "B")
            {
                if (hold == 1) { btn_C.Text = ""; btn_D.Text = ""; }
                else if (hold == 2) { btn_A.Text = ""; btn_D.Text = ""; }
                else { btn_C.Text = ""; btn_A.Text = ""; }
            }
            else if (trueAnswer == "C")
            {
                if (hold == 1) { btn_B.Text = ""; btn_D.Text = ""; }
                else if (hold == 2) { btn_A.Text = ""; btn_D.Text = ""; }
                else { btn_A.Text = ""; btn_B.Text = ""; }
            }
            else
            {
                if (hold == 1) { btn_C.Text = ""; btn_B.Text = ""; }
                else if (hold == 2) { btn_A.Text = ""; btn_C.Text = ""; }
                else { btn_A.Text = ""; btn_B.Text = ""; }
            }
            // Cách 1 => Disable pictureBox này - thuộc tính Enable chỉ khả năng thao tác vói control
            //ptb_5050.Enabled = false;
            // Cách 2 là ẩn nó luôn đi - thuộc tính Visible là thuộc tính chỉ về khả năng hiện thị của 1 control
            ptb_5050.Visible = false;
        }

        private void ptb_Viewer_Click(object sender, EventArgs e) //Khán giả
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
            ptb_Viewer.Visible = false;
        }

        private void ptb_Pro_Click(object sender, EventArgs e)
        {
            string trueAnswer = services.GetTrueAnswer(selectedID);
            MessageBox.Show("Chuyên gia khuyên bạn nên chọn đáp án: " + trueAnswer);
            ptb_Pro.Visible = false;
        }

        private void ptb_Change_Click(object sender, EventArgs e) // Nút skip câu hỏi
        {
            // Khi skip thì cái gì thay đổi?
            // TH1: Cho không 1 câu hỏi
            // Load ra câu hỏi mới
            //RandomQuestionShow();
            // Chia ra 2 trường hợp 1: 
            // Update tiền hiển thị
            // lb_Money.Text = questionMoney[selectedIndex].ToString();
            // Thực hiện update selectedIndex (Vị trí câu hỏi trong 15 câu)
            // selectedIndex++;

            // TH2: Chỉ thay đổi câu hỏi thôi
            RandomQuestionShow();
            ptb_Change.Visible = false;
        }
        private void btn_Start_Click(object sender, EventArgs e)
        {
            time_Limit.Start(); // Kích hoạt timer
            btn_1.BackColor = Color.LightBlue; // Đổi màu cột mốc đầu tiên
            btn_Start.Enabled = false; // Disable nút này để tránh người ta nhấn nhiều lần
            RandomQuestionShow();
        }
        private void time_Limit_Tick(object sender, EventArgs e)
        {
            // Khi nào timer chạy: Khi bắt đầu trò chơi hoặc có câu hỏi mới
            // 1. TimeLimit giảm dần từng giây
            timeLimit--;
            time_Limit.Interval = 1000; // Set thuộc tính interval của timer = 1000
            // 2: Gán giá trị của timer cho label hiển thị thời gian đếm ngược
            lb_Time.Text = timeLimit.ToString();
            // 3. Nếu hết giờ thì báo thua cuộc
            if (lb_Time.Text == "0")
            {
                time_Limit.Stop();
                MessageBox.Show($"Hết thời gian suy nghĩ, " +
                    $"bạn ra về với {lb_Money.Text} đồng");

            }
        }
    }
}
