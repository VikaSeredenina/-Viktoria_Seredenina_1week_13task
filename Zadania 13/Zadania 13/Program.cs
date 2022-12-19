
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace абстракт7
{
    
    abstract class telephone_directory //абстрактный класс
    {
        abstract public void Print(); //метод для вывода информации на экран
        abstract public bool Name(string temp); //метод для проверки данных в бд
    }
   
    class Persona : telephone_directory //класс персона
    {
      
        string name;
        string adres;
       double telefone;
        public Persona(string name, string adres, double telefone)
        {
            this.name = name;
            this.adres = adres;
            this.telefone = telefone;

        }
        public override void Print()
        {
            Console.WriteLine("Персона" + "\nФамилия:" + name + "\nАдрес:" + adres + "\nНомер телефона:" + telefone);
        }
        public override bool Name(string temp) //проверка на фамилию
        {
            return temp.Contains(name);
        }
    }
  
    class Organization : telephone_directory //класс организация
    {
        
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
        public override void Print()
        {
            Console.WriteLine("Организация" + "\nНазвание организации:" + name + "\nАдрес:" + adres + "\nТелефон:" + adres + "\nФакс:" + faks + "\nКонтактное лицо:" + contLico);
        }
        public override bool Name(string temp) //проверка на название
        {
            return temp.Contains(name);
        }
    }
    //Класс друг
    class Friend : telephone_directory
    {
       
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
        public override void Print()
        {
            Console.WriteLine("Друг" + "\nФамилия:" + name + "\nАдрес:" + adres + "\nНомер телефона:" + telefone + "\nДата Рождения:" + data);
        }
        public override bool Name(string temp) //проверка на фамилию
        {
            return temp.Contains(name);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            string temp;

            //Запись из файла
            string[] str1;
            int Line = File.ReadAllLines("C:\\Users\\Пользователь\\Desktop\\Учебная практика (осень) 3 курс\\4 неделя\\13 задание\\text.txt").Length;

            telephone_directory[] newObj = new telephone_directory[Line];
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

            //поиск по фамилии
            for (int i = 0; i < Line; i++)
                newObj[i].Print();
         
            Console.Write("Введите фамилию или организацию, которую хотите найти: ");
              
                temp = Console.ReadLine();
                for (int i = 0; i < Line; i++)
                    if (newObj[i].Name(temp))
                    {
                        newObj[i].Print();
                        count++;
                    }

              
                if (count == 0)
                    Console.WriteLine("К сожалению, в базе нет такой фамилии/организации");

        }
    }
}