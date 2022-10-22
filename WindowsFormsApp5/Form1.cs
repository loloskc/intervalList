using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var readsFile = new StreamReader("C:/logs.txt");    //путь файл
            int amountLitter = 0;
            int checkInt = 0;   // счетчик записей
            string str = readsFile.ReadToEnd(); // чтение файла
            readsFile.Close();
            char[] numbersLit = str.ToCharArray(); 
            string[] number = new String[numbersLit.Length];

            for(int i = 0; i < str.Length; i++) // цикл запис
            {
                if (numbersLit[i] !=' ')
                {
                    number[amountLitter] += numbersLit[i]; 
                }
                else
                {
                    amountLitter++;
                }
            }

            checkInt = amountLitter + 1; // кол - во записей
            int amountNumbers = Convert.ToInt32(Math.Floor(1+3.322+Math.Log10(checkInt))); // количество интервалов
            // проверка

            double[] num = new double[checkInt];

            for(int i = 0; i < checkInt; i++)
            {
                num[i] = double.Parse(number[i]);
            }

            Array.Sort(num);
            double razmah = num[checkInt-1] - num[0];// размах вариаци
            double lenthInt = razmah / amountNumbers; // длина интервала
            double[,] arrNum = new double[amountNumbers, 2];

            dataGridView1.RowCount = amountNumbers;
            dataGridView1.ColumnCount = 2;
            double a = num[0];
            for(int i =0;i<amountNumbers; i++)
            {   
                dataGridView1.Rows[i].Cells[0].Value = Convert.ToString(a) + " " + Convert.ToString(a + lenthInt);
                int kolIf = 0;
                for(int j = 0; j < checkInt; j++)
                {
                    if (a <= num[j] && a + lenthInt > num[j]) kolIf++; // под счет совпадений в промежутке i
                }
                dataGridView1.Rows[i].Cells[1].Value = kolIf; // вывод количество чисел попадающие в частичный интервал
                a += lenthInt;
            }
  
        }
    }
}
