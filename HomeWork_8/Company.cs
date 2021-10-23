using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{
    struct Company
    {
        public List<Department> departments;

        public List<Worker> peoples;

        public void CreateWorker()
        {
            string name = Console.ReadLine();
            string sername = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            int projects = int.Parse(Console.ReadLine());
            int id = int.Parse(Console.ReadLine());
            Worker w = new Worker(name, sername, age, salary, projects, id);
            peoples.Add(w);
        }

        public Worker CreateWorker(Department d)
        {
            string name = Console.ReadLine();
            string sername = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            int projects = int.Parse(Console.ReadLine());
            int id = int.Parse(Console.ReadLine());
            Worker w = new Worker(name, sername, age, salary, projects, id, d);
            peoples.Add(w);
            return w;
        }

        public void DeleteWorker(int id)
        {
            foreach (var item in peoples)
            {
                if (item.Id == id) peoples.Remove(item);
            }
            foreach (var item in departments)
            {
                foreach(Worker w in item.workers)
                {
                    if (w.Id == id) item.workers.Remove(w);
                }
            }
        }

        public void CreateDepartment(string name)
        {
            Department d = new Department(name);
            departments.Add(d);
        }

        public void DeleteDepartment(string name)
        {
            foreach (var item in departments)
            {
                if (item.Name.ToLower() == name.ToLower()) departments.Remove(item);
            }
        }

        public Department FindDepartment(string name)
        {
            Department d = new Department();
            foreach (var item in departments)
            {
                if (item.Name.ToLower() == name.ToLower()) d = item;
            }
            return d;
        }

        public Worker FindWorker(int id)
        {
            Worker w = new Worker();
            foreach (var item in peoples)
            {
                if (item.Id == id) w = item;
            }
            return w;
        }

        public Worker FindWorker(int id, Department d)
        {
            Worker w = new Worker();
            foreach (var item in d.workers)
            {
                if (item.Id == id) w = item;
            }
            return w;
        }



    }
}
