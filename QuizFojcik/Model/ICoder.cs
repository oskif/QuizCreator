using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizFojcik.Model
{
    public interface ICoder<T>
    {
        T Encode(string obj);
        T Decode(string obj);
    }
}
