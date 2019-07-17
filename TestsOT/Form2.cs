using System;
using System.Collections.Generic; 
using System.Globalization; 
using System.Windows.Forms;

namespace TestsOT
{
    public partial class Form2 : Form
    {

        public QRecords QRec = new QRecords();
        public int QuestionNumber = new int();
        public int AnswerChoise = new int();
        public QuestonRecord QuestonRecord = new QuestonRecord();
        public int CountOfAllQuestions; // общее количество вопросов 
        public List<AnswerResult> AnswerResults;
        public bool isControlDown; // нажат Ctrl?
        public bool isWDown; // нажата ли кнопка W

        // метод создания формы с проверкой
        // add form
        private ResultForm _resultform;

        public ResultForm ResultForm
        {
            get
            {
                if (_resultform == null || _resultform.IsDisposed)
                    _resultform = new ResultForm(AnswerResults, CountOfAllQuestions);
                return _resultform;
            }
            set { _resultform = value; }
        }

    public Form2()
        {
            InitializeComponent();
         
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            isControlDown = false;
            isWDown = false;

            timer1.Start();

            // clear
            QuestionNumber = 1;
            AnswerChoise = 0;
            CountOfAllQuestions = 10; // Количество вопросов для теста

            // заполнение коллекции с вопросами
            QRec.SetDataList(CountOfAllQuestions);
            if (!QRec.FileIsFound()) Close();
             
            AnswerResults = new List<AnswerResult>(); // массив ответов 
            AnswerResults.Clear();
            //**
            QuestonRecord = QRec.GetDataRecord(QuestionNumber); // получим вопрос с ответами
            // заполним радиобатоны
            SetQuestionOnScreen();

            //radioButton1.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            AnswerChoise = 0;
             
                if (radioButton1.Checked)
                {
                    AnswerChoise = 1;
                }
                if (radioButton2.Checked)
                {
                    AnswerChoise = 2;
                }
                if (radioButton3.Checked)
                {
                    AnswerChoise = 3;
                }
                if (radioButton4.Checked)
                {
                    AnswerChoise = 4;
                }


                if (AnswerChoise == 0)
                { 
                    MessageBox.Show("Выберите ответ");
                    return;
                }

                AnswerResults.Add(AnswerChoise == QuestonRecord.right_answer
                    ? new AnswerResult(QuestionNumber, 1)
                    : new AnswerResult(QuestionNumber, 0));

                QuestionNumber++;
                QuestonRecord = QRec.GetDataRecord(QuestionNumber); // получим вопрос с ответами
                SetQuestionOnScreen();
          

            if (QuestionNumber <= CountOfAllQuestions) return;

            // спряем форму 2 на время формы 3
            Hide();
            // создание формы 3
            // с выводом результата
            _resultform = new ResultForm(AnswerResults, CountOfAllQuestions);
            _resultform.ShowDialog();

            //закрыть 2 форму
            Close();
        }

        // вопрос на экран
        public void SetQuestionOnScreen()
        {
            label2.Text = QuestonRecord.q_number.ToString(CultureInfo.InvariantCulture);
            richTextBox1.Text = QuestonRecord.question;
            radioButton1.Text = QuestonRecord.answer1;
            radioButton2.Text = QuestonRecord.answer2;
            radioButton3.Text = QuestonRecord.answer3;
            radioButton4.Text = QuestonRecord.answer4;

            //radioButton1.Checked = true;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            Refresh();
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                isControlDown = true;

            if (e.KeyCode == Keys.W)
                isWDown = true;
                
               
        }

        private void Form2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
                isControlDown = false;

            if (e.KeyCode == Keys.W)
                isWDown = false;
                
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isControlDown && isWDown)
            {
                //label3.Text = "Ctrl + W"; 
            }
        }

        

      
    }
}
