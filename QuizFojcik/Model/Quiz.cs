using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizFojcik.Model
{
    class Quiz
    {
        public string tytul { get; set; }
        public List<Pytanie> zbiorPytan { get; set; }
        public Quiz()
        {
            zbiorPytan = new List<Pytanie>();
        }
    }
}
