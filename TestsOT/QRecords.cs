using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TestsOT
{
    public class QRecords
    {
        public static List<QuestonRecord> QuestonRecords;
        //  ---  folder directory + filename
        private static readonly string _testDbPath = Path.Combine(Environment.CurrentDirectory, "questions.csv");
        protected bool filefound;
        public QRecords()
        {
            QuestonRecords = new List<QuestonRecord>();
            filefound = false;
        }

        public void SetDataList(int questionCount)
        {
            // счетчик номеров вопросов
            var number = new int();
            // создадим массив случайно выбранных номеров вопросов
            var questionNumbers = new int[questionCount];
             
            // загрузка данных из CSV файла 
            string[] fileLine = null;
            string[] lines;
            try
            {
                 lines = File.ReadAllLines(_testDbPath,System.Text.Encoding.Default);
                filefound = true;
            }
            catch (Exception)
            {
                MessageBox.Show(@"Файл не найден");
                filefound = false; 
                return; 
            }
            

            // посчитаем количество не пустых строк = количество вопросов
            var totalQuestionCounts = lines.Count(t => !String.IsNullOrEmpty(t));

            // проверим что в файле записей больше, чем необходимо вопросов для теста
            if (totalQuestionCounts < questionCount) return;

            // сгенерируем массив случайно выбранных номеров вопросов
            SetQn(questionNumbers, totalQuestionCounts+1);

            number = 1;
            /*for (int index = 0; index < lines.Length; index++)
            {
                string t = lines[index];
                if (!String.IsNullOrEmpty(t))
                {
                    fileLine = t.Split(';');
                    var a = new int();
                    a = int.Parse(fileLine[0]);

                    // если этот вопрос есть в массиве - добавляем
                    if (FindNum(questionNumbers, a))
                    {
                        //создаём новую строку
                        QuestonRecords.Add(new QuestonRecord(number, fileLine[1], fileLine[2],
                            fileLine[3],
                            fileLine[4], fileLine[5], int.Parse(fileLine[6])));

                        number++;
                    }
                }
            }*/

            // почистим список
            QuestonRecords.Clear();
            for (int index = 0; index < questionNumbers.Count(); index++)
            {
                string t = lines[questionNumbers[index] - 1];
                if (!String.IsNullOrEmpty(t))
                {
                    fileLine = t.Split(';');
                    var a = new int();
                    a = int.Parse(fileLine[0]);

                     
                    //создаём новую строку
                    QuestonRecords.Add(new QuestonRecord(number, fileLine[1], fileLine[2],
                            fileLine[3],
                            fileLine[4], fileLine[5], int.Parse(fileLine[6])));

                    number++;
                        
                }
            }


            // temp
            //QuestonRecords.Add(new QuestonRecord() { q_number = 1, question = "Вопрос 1", answer1 = "Answer1", answer2 = "answer2", answer3 = "answer3", answer4 = "answer4", right_answer = 1 });
            //QuestonRecords.Add(new QuestonRecord() { q_number = 2, question = "Вопрос 2", answer1 = "Answer1", answer2 = "answer2", answer3 = "answer3", answer4 = "answer4", right_answer = 2 });
            //QuestonRecords.Add(new QuestonRecord() { q_number = 3, question = "Вопрос 3", answer1 = "Answer1", answer2 = "answer2", answer3 = "answer3", answer4 = "answer4", right_answer = 3 });
            //QuestonRecords.Add(new QuestonRecord() { q_number = 4, question = "Вопрос 4", answer1 = "Answer1", answer2 = "answer2", answer3 = "answer3", answer4 = "answer4", right_answer = 4 });
            //QuestonRecords.Add(new QuestonRecord() { q_number = 5, question = "Вопрос 5", answer1 = "Answer1", answer2 = "answer2", answer3 = "answer3", answer4 = "answer4", right_answer = 4 });
            //QuestonRecords.Add(new QuestonRecord() { q_number = 6, question = "Вопрос 6", answer1 = "Answer1", answer2 = "answer2", answer3 = "answer3", answer4 = "answer4", right_answer = 4 });
            //QuestonRecords.Add(new QuestonRecord() { q_number = 7, question = "Вопрос 7", answer1 = "Answer1", answer2 = "answer2", answer3 = "answer3", answer4 = "answer4", right_answer = 4 });
            //QuestonRecords.Add(new QuestonRecord() { q_number = 8, question = "Вопрос 8", answer1 = "Answer1", answer2 = "answer2", answer3 = "answer3", answer4 = "answer4", right_answer = 4 });
            //QuestonRecords.Add(new QuestonRecord() { q_number = 9, question = "Вопрос 9", answer1 = "Answer1", answer2 = "answer2", answer3 = "answer3", answer4 = "answer4", right_answer = 4 });
            //QuestonRecords.Add(new QuestonRecord() { q_number = 10, question = "Вопрос 10", answer1 = "Answer1", answer2 = "answer2", answer3 = "answer3", answer4 = "answer4", right_answer = 4 });
            //QuestonRecords.Add(new QuestonRecord() { q_number = 11, question = "Вопрос 11", answer1 = "Answer1", answer2 = "answer2", answer3 = "answer3", answer4 = "answer4", right_answer = 4 });

        }

        public QuestonRecord GetDataRecord(int q_num)
        {
            var qeRec = new QuestonRecord();

            foreach (var questonRecord in QuestonRecords)
            {
                if (questonRecord.q_number == q_num)
                {
                    return questonRecord;
                }

            }
            return qeRec;
        }

        public void SetQn(int[] arr, int totalQuestionCountss)
        {
            // защита от дурака
            if (totalQuestionCountss == 0) return;

            var rnd = new Random();

            for (var i= 0;i < arr.Count();i++)
            {
                var a = rnd.Next(1, totalQuestionCountss); // 99 -  количество вопросов

                while (FindNum(arr, a)) // только уникальные номера
                {
                    a = rnd.Next(1, totalQuestionCountss); 
                }
                arr[i] = a;

            }
        }

        //
        public bool FindNum(int[] arr, int num)
        {
            return arr.Any(ar => ar == num);
        }

        public bool FileIsFound()
        {
            return filefound;
        }
    }
}
