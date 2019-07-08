using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsOT
{
    public class QuestonRecord
    {
        public int q_number; // номер вопроса
        public string question;
        public string answer1;
        public string answer2;
        public string answer3;
        public string answer4;
        public int right_answer; // номер верного ответа 


        // constructor
        public QuestonRecord() { }
        public QuestonRecord(int q_num, string q, string a1, string a2, string a3, string a4, int r_a)
        {
            this.q_number  = q_num;
            this.question = q;
            this.answer1 = a1;
            this.answer2 = a2;
            this.answer3 = a3;
            this.answer4 = a4;
            this.right_answer = r_a;
        }

        //public string Q_number { get ; set ; }
        //public string Answer1 { get; set; }
        //public string Answer2 { get; set; }
        //public string Answer3 { get; set; }
        //public string Answer4 { get; set; }
        //public string Right_answer { get; set; }


    }
}
