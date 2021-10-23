using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{
    struct Department
    {
        public string Name { get; set; }

        public DateTime Date { get; set; }

        public List<Worker> workers;

        public Department(string name )
        {
            this.Name = name;
            this.Date = DateTime.Now;
            this.workers = new List<Worker>();
        }

        public void Add(Worker worker)
        {
            workers.Add(worker);
        }

        public void DeleteFromDepartment(Worker worker)
        {
            workers.Remove(worker);
        }

        public void Edit()
        {
            this.Name = Console.ReadLine();
            this.Date = Convert.ToDateTime(Console.ReadLine());
            for (; ; )
            {
                Console.WriteLine("Хотите ли вы добавить сотрудников в отдел?");
                string answer1 = Console.ReadLine();
                if (answer1.ToLower() == "да")
                {
                    Console.WriteLine("Если вы хотите добавить существующего сотрудника, то нажмите 1" +
                        "Если вы хотите создать нового сотрудника и добавить, то нажмите 2" +
                        "Если вы передумали, то нажмите 0");
                    int answer2 = Convert.ToInt32(Console.ReadLine());
                    if (answer2 == 1)
                    {
                        Console.WriteLine("Введите уникальный номер сотрудника (Id)");
                        int id = Convert.ToInt32(Console.ReadLine());

                         
                    }
                    else if (answer2 == 2)
                    {
                        Worker worker = new Worker()
                        {
                            Name = Console.ReadLine(),
                            SerName = Console.ReadLine(),
                            Age = Convert.ToInt32(Console.ReadLine()),
                            Salary = Convert.ToInt32(Console.ReadLine()),
                            Projects = Convert.ToInt32(Console.ReadLine()),
                            Id = Convert.ToInt32(Console.ReadLine()),
                            NameOfDepartment = Name,
                            flagDepartment = true,
                        }; 
                        Add(worker);
                    }
                    else if (answer2 == 0) break;
                }
                else break;
            }

        }
    }
}
