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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace Zadania_13__form_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        abstract class telephone_directory //абстрактный класс
        {
            abstract public void Print(TextBox text); //метод для вывода информации
            abstract public bool Name(string temp); //метод для проверки введенных данных
        }

        class Persona : telephone_directory //класс персона
        {
            string pers = "Персона";
            string name;
            string adres;
            double telefone;
            public Persona(string name, string adres, double telefone)
            {
                this.name = name;
                this.adres = adres;
                this.telefone = telefone;

            }
            public override void Print(TextBox text)
            {
               text.Text+=pers + "Фамилия:" + name + Environment.NewLine + "Адрес:" + adres + Environment.NewLine  + "Номер телефона:" + telefone + Environment.NewLine;
            }
            public override bool Name(string temp) //проверка на фамилию
            {
                return temp.Contains(name);
            }
        }

        private class Organization : telephone_directory //класс организация
        {
            string org = "Организация";
            string name;
            string adres;
            double telefone;
            double faks;
            string contLico;
            public Organization(string name, string adres, double telefone, double faks, string contLico)
            {
                this.name = name;
                this.adres = adres;
                this.telefone = telefone;
                this.faks = faks;
                this.contLico = contLico;
            }
            public override void Print(TextBox text)
            {
               text.Text+= org + "Название организации:" + name + Environment.NewLine+ "Адрес:" + adres + Environment.NewLine + "Телефон:" + adres + Environment.NewLine + "Факс:" + faks + Environment.NewLine + "Контактное лицо:" + contLico + Environment.NewLine;
            }
            public override bool Name(string temp) //проверка на название
            {
                return temp.Contains(name);
            }
        }
        //Класс друг
        class Friend : telephone_directory
        {
            string dr = "Друг";
            string name;
            string adres;
            double telefone;
            string data;
            public Friend(string name, string adres, double telefone, string data)
            {
                this.name = name;
                this.adres = adres;
                this.telefone = telefone;
                this.data = data;
            }
            public override void Print(TextBox text)
            {
               text.Text += dr + "Фамилия:" + name + Environment.NewLine +  "Адрес:" + adres + Environment.NewLine+ "Номер телефона:" + telefone + Environment.NewLine + "Дата Рождения:" + data + Environment.NewLine;
            }
            public override bool Name(string temp) //проверка на фамилию
            {
                return temp.Contains(name);
            }
        }
        telephone_directory[] newObj;
            int Line = File.ReadAllLines("C:\\Users\\Пользователь\\Desktop\\Учебная практика (осень) 3 курс\\4 неделя\\13 задание\\text form.txt").Length;


           

        private void Form1_Load(object sender, EventArgs e)
        {

            int count = 0;
            string temp;

            //Запись из файла
            string[] str1;
            newObj = new telephone_directory[Line];
          
            using (StreamReader sr = new StreamReader("C:\\Users\\Пользователь\\Desktop\\Учебная практика (осень) 3 курс\\4 неделя\\13 задание\\text.txt")) //чтение файла
            {
                int i = 0;
                while (sr.Peek() > -1)
                {
                    str1 = sr.ReadLine().Split(',');

                    if (str1[0] == "Persona")
                        newObj[i] = new Persona(str1[1], str1[2], double.Parse(str1[3]));
                    else if (str1[0] == "Organization")
                        newObj[i] = new Organization(str1[1], str1[2], double.Parse(str1[3]), double.Parse(str1[4]), str1[5]);
                    else if (str1[0] == "Friend")
                        newObj[i] = new Friend(str1[1], str1[2], double.Parse(str1[3]), str1[4]);
                    i++;
                }
            }
            for (int i = 0; i < Line; i++)
                newObj[i].Print(textBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
              int  count = 0;
              string  temp = textBox2.Text;
                for (int i = 0; i < Line; i++)
                    if (newObj[i].Name(temp))
                    {
                        newObj[i].Print(textBox3);
                        count++;
                    }

               
                if (count == 0)
                   MessageBox.Show("К сожалению, в базе нет такой фамилии/организации");

            
    }

        private void button3_Click(object sender, EventArgs e)
        {
            
            textBox2.Text = "";
            textBox2.Text = "";
            textBox3.Clear();
            textBox3.Clear();

        }
    }
    }

