using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsOT
{
    public class AnswerResult
    {
        public int questionNumber;
        public int resultOK; // 0 неверный, 1-верный

        public AnswerResult() { }

        public AnswerResult(int qn, int ro)
        {
            questionNumber = qn;
            resultOK = ro;
        }
    }

    
}
