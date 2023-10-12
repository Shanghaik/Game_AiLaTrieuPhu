using Game_AiLaTrieuPhu.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_AiLaTrieuPhu.BUS
{
    internal class GameServices
    {
        Repositories repos;
        public GameServices()
        {
            repos = new Repositories();
        }
        // 1. Hàm random câu hỏi để load vào form
        public Question RandomQuestion(int level)
        {
            // B1: Lấy ra danh sách câu hỏi
            var listQuestion = repos.GetAllQuestion();
            // B2 lấy ra những câu hỏi trong lv đó
            var questionLv = listQuestion.Where(x => x.Level == level).ToList();
            // Random ra 1 câu hỏi trong lv đó
            Random r = new Random();
            int index = r.Next(questionLv.Count); // Random trong khoảng số lượng câu hỏi của lv
            return questionLv[index];
        }
        public int CountQuestionLevel(int level)
        {
            return repos.GetAllQuestion().Where(p => p.Level == level).Count();
        }
        // 2. Check xem câu hỏi đã đúng hay chưa
        public bool CheckTrueAnswer(int questionID, string answer)
        {
            var question = repos.GetAllQuestion().FirstOrDefault(p => p.Id == questionID);
            return question.TrueAnswer == answer;
        }
        // Trả về đáp án đúng
        public string GetTrueAnswer(int questionID)
        {
            return repos.GetAllQuestion().FirstOrDefault(p => p.Id == questionID).TrueAnswer;
        }
    }
}
