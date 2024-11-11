using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizPortfolioApp
{
    public class QuizData
    {
        public List<Category> Categories { get; set; }  
    }
    public class Category
    {
        public string CategoryName { get; set; } 
        public List<Question> Questions { get; set; }  
    }
    public class Question
    {
        public string QuestionText { get; set; } 
        public string CorrectAnswer { get; set; } 
        public List<string> Options { get; set; }  
    }
}
