using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_AiLaTrieuPhu.DAL
{
    internal class Repositories
    {
        // Repo này chỉ để load câu hỏi ra thôi
        GameDbContext context;
        public Repositories()
        {
               context = new GameDbContext();
        }
        public List<Question> GetAllQuestion()
        {
            return context.Questions.ToList();
        }
    }
}
