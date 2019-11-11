using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TestsOT
{
    public partial class ResultForm : Form
    {
        public List<AnswerResult> AnswerResults;
        public int CountOfAllQuestions; // общее количество вопросов
        protected string stringResult;
        protected int countOfRightAnw; // количество верных ответов

        public ResultForm(List<AnswerResult> ans, int qCount)
        {
            InitializeComponent();

            
            CountOfAllQuestions = qCount;
            AnswerResults = new List<AnswerResult>();
            AnswerResults = ans;
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            listBox1.ClearSelected();
            Refresh();
            countOfRightAnw = 0;

            foreach (var answerResult in AnswerResults)
            {
                if (answerResult.resultOK > 0)
                {
                    countOfRightAnw++;
                    stringResult = "Верно";
                }
                else
                {
                    stringResult = "Неверно";
                }
                 
                listBox1.Items.Add(string.Format(@"Вопрос №{0}: {1}", answerResult.questionNumber, stringResult));
                Refresh();
            }

              
            listBox1.Items.Add("---------------------------------");  
            listBox1.Items.Add(string.Format(@"Итого {0} верных ответов из {1}", countOfRightAnw, CountOfAllQuestions)); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
