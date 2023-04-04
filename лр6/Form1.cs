using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace лр6
{
    public partial class Form1 : Form
    {
        // Треугольник

        public Triangle tr;
        public Form1()
        {
            InitializeComponent();
        }

        // Инициализация треугольника

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = $"Введите точки для треугольника через тире\nПорядок точек: x1, y1, x2, y2, x3, y3. Пример: 6-6-1-2-4-5";

        }

        // При нажатии на кнопку вызывается метод Изменение размера треугольника

        private void radioButton1_Click(object sender, EventArgs e)
        {
            try
            {
                int change_size = Convert.ToInt32(textBox1.Text);
                tr.ChangeSize(change_size);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Если 2 раза нажать на текстовое поле, создастся треугольник

        private void textBox1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                int j = 0;
                int[] dotes = new int[6];
                foreach (var i in textBox1.Text.Split('-'))
                {
                    dotes[j] = int.Parse(i);
                    j++;
                }
                tr = new Triangle(dotes[0], dotes[1], dotes[2], dotes[3], dotes[4], dotes[5]);
                MessageBox.Show("Треугольник создан");
                textBox1.Text = "Вам доступны действия: изменение сторон (1), полная информация (2), поворот (3), перемещение (4). Чтобы подробнее узнать про каждое, нужно стереть эту запись, ввести цифру действия и дважды щёлкнуть по форме. Номера действий также можно просмотреть в списке ниже.";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
            }

        // Вызов метода Поворот

        private void radioButton2_Click(object sender, EventArgs e)
        {
            
            string[] symb = new string[2];
            int j = 0;
            foreach (var i in textBox1.Text.Split('-'))
            {
                symb[j] = i;
                j++;
            }
            int angular_ = int.Parse(symb[1]);
            string center_ = symb[0];
            tr.Turn(center_,angular_);
        }

        // Вызов метода Перемещение

        private void radioButton3_Click(object sender, EventArgs e)
        {
           
            int moving = int.Parse(textBox1.Text);
            tr.MoveOnPlane(moving);
        }

        // Свойство Полная информация

        private void radioButton4_Click(object sender, EventArgs e)
        {
            textBox1.Text = tr.Definition;
        }

        // При 1 щелчке появляются сообщения в соответствии с введённой цифрой

        private void Form1_DoubleClick(object sender, EventArgs e)
        {
            string h = textBox1.Text;
            switch (h)
            {
                case "1":
                    MessageBox.Show("Напишите число - изменение размера треугольника. Уменьшение - число со знаком минус. Увеличение - просто число. Нажмите на кнопку 'Изменение сторон'");
                    break;
                case "2":
                    MessageBox.Show("Нажмите на кнопку 'Полная информация'.");
                    break;
                case "3":
                    MessageBox.Show("Выберете Х в качестве центра. Напишите через тире Х и число. Число является углом поворота. Например, х1-180. Нажмите на кнопку 'Поворот'");
                    break;
                case "4":
                    MessageBox.Show("Напишите число - насколько переместятся точки. Например, 10. Нажмите на кнопку 'Перемещение'");
                    break;
            }
        }
    }

}
