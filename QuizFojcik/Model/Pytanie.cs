using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizFojcik.Model
{
    public class Pytanie
    {
        //public string tresc { get; set; }
        //public Odpowiedz odpowiedz1 { get; set; }
        //public Odpowiedz odpowiedz2 { get; set; }
        //public Odpowiedz odpowiedz3 { get; set; }
        //public Odpowiedz odpowiedz4 { get; set; }

        
        public string tresc { get; set; }
        public List<Odpowiedz> odpowiedzi { get; set; }

        public Pytanie()
        {
            odpowiedzi = new List<Odpowiedz>();
        }

        public override string ToString()
        {
            String result = tresc + ": A: " + odpowiedzi[0].tresc + ", B: " + odpowiedzi[1].tresc +
                ", C: " + odpowiedzi[2].tresc + ", D: " + odpowiedzi[3].tresc + " poprawne: ";
            if (odpowiedzi[0].poprawnosc)
                result += "A ";
            if (odpowiedzi[1].poprawnosc)
                result += "B ";
            if (odpowiedzi[2].poprawnosc)
                result += "C ";
            if (odpowiedzi[3].poprawnosc)
                result += "D ";
            return result;
        }
    }
}
