using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizFojcik.Model
{
    public class Cezar : ICoder<String>
    {
        public string Encode(string data)
        {
            byte[] dataAscii = Encoding.UTF8.GetBytes(data);
            for (int i = 0; i < dataAscii.Length; i++)
            {
                dataAscii[i] = (byte)(dataAscii[i] + 1);
            }
            return UTF8Encoding.UTF8.GetString(dataAscii);
        }
        public string Decode(string data)
        {
            byte[] dataAscii = Encoding.UTF8.GetBytes(data);
            for (int i = 0; i < dataAscii.Length; i++)
            {
                dataAscii[i] = (byte)(dataAscii[i] - 1);
            }
            return UTF8Encoding.UTF8.GetString(dataAscii);

        }
    }
}
