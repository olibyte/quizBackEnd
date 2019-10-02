using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quizBackEnd.Models
{
    public class Question
    {
        public int ID { get; set; }
        public string Text { get; set; }
        public string CorrectAnswer { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }
    }
}
