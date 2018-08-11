using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSort
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
                {
                Id = 1, FirstName = "Tamara", LastName = "Ivanova", Age = 22, DepId = 2
                },
                new Employee()
                {
                Id = 2, FirstName = "Nikita", LastName = "Larin", Age = 33, DepId = 1
                },
                new Employee()
                {
                Id = 3, FirstName = "Alica", LastName = "Ivanova", Age = 43, DepId = 3
                },
                new Employee()
                {
                Id = 4, FirstName = "Lida", LastName = "Marusyk", Age = 22, DepId = 2
                },
                new Employee()
                {
                Id = 5, FirstName = "Lida", LastName = "Voron", Age = 36, DepId = 4
                },
                new Employee()
                {
                Id = 6, FirstName = "Ivan", LastName = "Kalyta", Age = 22, DepId = 2
                },
                new Employee()
                {
                Id = 7, FirstName = "Nikita", LastName = "Krotov", Age = 27, DepId = 4
                }
            };


            Console.WriteLine("1) Упорядочить имена и фамилии сотрудников по алфавиту, которые проживают в Украине.Выполнить запрос немедленно.");
            var EmploySortUkr = (from emp in employees
                                from dep in departments
                                where emp.DepId == dep.Id && dep.Country == "Ukraine"
                                orderby emp.LastName, emp.FirstName
                                select emp).ToList<Employee>();


            foreach (var item in EmploySortUkr)
            {
                Console.WriteLine(item.LastName+" "+item.FirstName);
            }

            Console.WriteLine("2) Отсортировать сотрудников по возрастам, по убыванию.Вывести Id, FirstName, LastName, Age.Выполнить запрос немедленно.");

            var EmplSortAge = (from emp in employees
                              orderby emp.Age descending
                              select emp).ToList<Employee>();

            foreach (var item in EmplSortAge)
            {
                Console.WriteLine("id="+item.Id+" "+ "LastName: "+item.FirstName+" LastName: "+item.LastName + " Age:" + item.Age);
            }

            Console.WriteLine("3) Сгруппировать студентов по возрасту. Вывести возраст и сколько раз он встречается в списке.\n");

            var GroupAge = employees.GroupBy(x => x.Age).Select(g => new { g.Key, Count = g.Count() });

            foreach (var item in GroupAge)
            {
                Console.WriteLine("Возраст {0} встречается {1}", item.Key, item.Count);
            }
        }
    }
}
