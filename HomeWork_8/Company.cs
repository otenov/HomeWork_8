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

        /// <summary>
        /// Создание сотрудника без определения в департамент
        /// </summary>
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

        /// <summary>
        /// Создание сотрудника с определением в департамент
        /// </summary>
        /// <param name="d">Департамент, в который будет определен сотрудник</param>
        /// <returns>Сотрудник, состоящий в департаменте</returns>
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

        /// <summary>
        /// Удаление сотрудника из компании по id.
        /// Удаление из списка сотрудников и одновременно из департамента
        /// </summary>
        /// <param name="id">Уникальный номер сотрудника</param>
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

        /// <summary>
        /// Создание департамента
        /// </summary>
        /// <param name="name">Название департамента</param>
        public void CreateDepartment(string name)
        {
            Department d = new Department(name);
            departments.Add(d);
        }

        /// <summary>
        /// Удаление департамента
        /// </summary>
        /// <param name="name">Название департамента</param>
        public void DeleteDepartment(string name)
        {
            for (int i = 0; i <= departments.Count-1; i++)
            {
                if (departments[i].Name.ToLower() == name.ToLower())
                {
                    for (int j = 0; j <= departments[i].workers.Count-1; i++)
                    {
                        departments[i].workers[j].flagD = ;
                    }
                    departments.Remove(item);
                }
  
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
