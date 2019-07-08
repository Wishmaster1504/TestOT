using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestsOT
{
    public partial class Form1 : Form
    {
        // метод создания формы с проверкой
        // add form
        private Form2 questionform;

        public Form2 QuestionForm
        {
            get
            {
                if (questionform == null || questionform.IsDisposed)
                    questionform = new Form2();
                return questionform;
            }
            set { questionform = value; }
        }


        //-------------------------------------------
        
         


        public Form1()
        {
            InitializeComponent();

            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
            QuestionForm.ShowDialog();
            Show();
        }
    }
}
