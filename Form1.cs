using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyProject
{
    public partial class Form1 : Form
    {
        /*Исследовать зависимость количества сравнений в сортировках простыми и бинарными вставками 
         от количества элементов в этих массивах. При этом отобразить необходимое количество перестановок. 
         Задача выполнена с помощью алгоритмов Вирта из учебника*/

        //сортировка вставками
        static int[] InsertionSortSimple(ref int[] array)
        {
            int CountInsert = 0; // количество пересылок (присваиваний) по Вирту
            int CountCompare = 0; // количество сравнений
            for (var i = 2; i < (array.Length); i++)
            {
                
                var key = array[i];
                array[0] = key;
                CountInsert +=2;
                var j = i;
                CountCompare++;
                while (key < array[j-1])
                {
                    array[j] = array[j - 1];
                    j--;
                    CountInsert++;
                    CountCompare++;
                }
                array[j] = key;
                CountInsert++;

            }
            int[] FinishArr = new int[2] { CountCompare, CountInsert };
           return FinishArr;
        }

        static int[] InsertionSortBinary(ref int[] array)
        {
            int CountInsert1 = 0;
            int CountCompare1 = 0;
            var mid = 0;
            for (var i = 1; i < (array.Length); i++)
            {
                var key = array[i];
                var l = 1;
                var r = i;
                CountInsert1+=3;

                CountCompare1++;
                while (l < r)
                {
                    
                    mid = (l+r)/ 2;
                    CountInsert1++;
                    CountCompare1++;
                    if (array[mid]<=key)
                    {
                        l = mid+1;
                        CountInsert1++;

                    }
                    else
                    {
                        r=mid;
                        CountInsert1++;
                    }
                }
            
                for (var j = i; j<r; j--)
                {
                    array[j] = array[j - 1];
                    CountInsert1++;
                }
                array[r] = key;
                CountInsert1++;
               

            }
            int[] FinishArr = new int[2] { CountCompare1, CountInsert1 };
            return FinishArr;
        }
        

       


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsLetter(e.KeyChar)) return;
            else
                e.Handled = true;
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";

            int n;
            bool result = int.TryParse(textBox1.Text, out n);
            if (result != true) 
            {
                MessageBox.Show("Вы ввели не целое число!", "Предупреждение");
            }
                
            else
            {
                if (n<1)
                {
                    MessageBox.Show("Количество элементов должно быть больше 0!", "Предупреждение");
                }
                else
                { 
                    int[] myArray = new int[n];
                    Random rand = new Random();
                    for (int x = 0; x < myArray.Length; x++)
                    {
                        myArray[x] = rand.Next(1000);
                    }

                    int[] Arr = new int[2];
                    Arr = InsertionSortSimple(ref myArray);
                    textBox2.Text = Convert.ToString(Arr[0]);
                    textBox5.Text = Convert.ToString(Arr[1]);

                    int[] Arr1 = new int[2];
                    Arr1 = InsertionSortBinary(ref myArray);
                    textBox4.Text = Convert.ToString(Arr1[0]);
                    textBox3.Text = Convert.ToString(Arr1[1]);
                }
            }
        }

    }
}
