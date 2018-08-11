using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_console
{
    class Program
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string City { get; set; }
        }
        static void Main(string[] args)
        {
            List<Person> person = new List<Person>()
                {
                new Person(){ Name = "Andrey", Age = 24, City = "Kyiv" },
                new Person(){ Name = "Liza", Age = 18, City = "Moscow" },
                new Person(){ Name = "Oleg", Age = 15, City = "London" },
                new Person(){ Name = "Sergey", Age = 55, City = "Kyiv" },
                new Person(){ Name = "Sergey", Age = 32, City = "Kyiv" }
                };
            //старших 25 лет.
            var resultAge25 = from p in person      
                              where p.Age > 25
                              select p;
            var resultNotKyiv = from p in person
                              where p.City != "Kyiv"
                              select p;
            var resultNameKyiv = from p in person
                                where p.City == "Kyiv"
                                select p.Name;
            var resultSerg35 = from p in person
                                 where p.Name == "Sergey" && p.Age>35
                                 select p;
            var resultMoscow = from p in person
                                where p.City == "Moscow"
                                select p;

            Console.WriteLine("1) Выбрать людей, старших 25 лет.");
            foreach (var item in resultAge25)
            {
                Console.WriteLine("Name:"+item.Name+" Age:"+item.Age+" City:"+item.City);
            }

            Console.WriteLine("2) Выбрать людей, проживающих не в Киеве.");
            foreach (var item in resultNotKyiv)
            {
                Console.WriteLine("Name:" + item.Name + " Age:" + item.Age + " City:" + item.City);
            }

            Console.WriteLine("3) Выбрать имена людей, проживающих в Киеве.");
            foreach (var item in resultNameKyiv)
            {
                Console.WriteLine("Name:" + item);
            }

            Console.WriteLine("4) Выбрать людей старших 35 лет с именем Sergey.");
            foreach (var item in resultSerg35)
            {
                Console.WriteLine("Name:" + item.Name + " Age:" + item.Age + " City:" + item.City);
            }
            Console.WriteLine("5) Выбрать людей, проживающих в Москве.");
            foreach (var item in resultMoscow)
            {
                Console.WriteLine("Name:" + item.Name + " Age:" + item.Age + " City:" + item.City);
            }

        }
    }
}
