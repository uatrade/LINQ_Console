using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLinq
{
    class Program
    {
        class Employee
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
            public int DepId { get; set; }
        }
        class Department
        {
            public int Id { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
        }
        static void Main(string[] args)
        {
            List<Department> departments = new List<Department>()
                {
                    new Department(){ Id = 1, Country = "Ukraine", City = "Donetsk" },
                    new Department(){ Id = 2, Country = "Ukraine", City = "Kyiv" },
                    new Department(){ Id = 3, Country = "France", City = "Paris" },
                    new Department(){ Id = 4, Country = "Russia", City = "Moscow" }
                };
            List<Employee> employees = new List<Employee>()
                {
                    new Employee()
                    { Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2 },
                    new Employee()
                    { Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1 },
                    new Employee()
                    { Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3 },
                    new Employee()
                    { Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2 },
                    new Employee()
                    { Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4 },
                    new Employee()
                    { Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2 },
                    new Employee()
                    { Id = 7, FirstName = "Nikita", LastName = " Krotov ", Age = 27,DepId = 4 }
                };

            var EmploeNotDonet = from emp in employees
                                 from dp in departments
                                 where emp.DepId == dp.Id && dp.Country == "Ukraine" && dp.City != "Donetsk"
                                 select emp;

            var CountryNotRepeat = departments.Select(count => count.Country).Distinct();

            var EmploeFirst3Age25 = employees.Where(em => em.Age > 25).
                                    Select(em => new { em.FirstName, em.LastName }).Take(3);

            var EmploeKyiv21 = from emp in employees
                               from dp in departments
                               where emp.DepId == dp.Id && dp.City == "Kyiv" && emp.Age > 21
                               select emp;


            Console.WriteLine("1) Выбрать имена и фамилии сотрудников, работающих в Украине, но не в Донецке.");
            foreach (var item in EmploeNotDonet)
            {
                Console.WriteLine(item.FirstName+" "+item.LastName);
            }

            Console.WriteLine("2) Вывести список стран без повторений.");
            foreach (var item in CountryNotRepeat)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("3) Выбрать 3-x первых сотрудников, возраст которых превышает 25 лет.");

            foreach (var item in EmploeFirst3Age25)
            {
                Console.WriteLine(item.FirstName+" "+item.LastName);
            }
            Console.WriteLine("4) Выбрать имена, фамилии и возраст студентов из Киева, возраст которых превышает 21 года");

            foreach (var item in EmploeKyiv21)
            {
                Console.WriteLine(item.FirstName + " " + item.LastName);
            }

        }

    }
}
