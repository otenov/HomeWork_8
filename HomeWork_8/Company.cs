﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{
    public struct Company
    {
        public string Name { get; set; }

        public List<Department> departments;

        public List<Worker> peoples;

        public Company(string name)
        {
            this.Name = name;
            this.peoples = new List<Worker>();
            this.departments = new List<Department>();
        }

        /// <summary>
        /// Создание сотрудника без определения в департамент
        /// </summary>
        public void CreateWorker()
        {
            Console.Write("Введите имя сотрудника\n" +
                ">>> ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию сотрудника\n" +
                          ">>> ");
            string surname = Console.ReadLine();
            Console.Write("Введите возраст сотрудника\n" +
                          ">>> ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Введите зарплату сотрудника\n" +
                          ">>> ");
            int salary = int.Parse(Console.ReadLine());
            Console.Write("Введите количество проектов сотрудника\n" +
                          ">>> ");
            int projects = int.Parse(Console.ReadLine());
            Console.Write("Введите оригинальный номер сотрудника\n" +
                          ">>> ");
            int id = int.Parse(Console.ReadLine());
            Worker w = new Worker(name, surname, age, salary, projects, id);
            peoples.Add(w);
        }

        /// <summary>
        /// Создание сотрудника с определением в департамент
        /// </summary>
        /// <param name="d">Департамент, в который будет определен сотрудник</param>
        /// <returns>Сотрудник, состоящий в департаменте</returns>
        public Worker CreateWorker(Department d)
        {
            Console.Write("Введите имя сотрудника\n" +
                          ">>> ");
            string name = Console.ReadLine();
            Console.Write("Введите фамилию сотрудника\n" +
                          ">>> ");
            string surname = Console.ReadLine();
            Console.Write("Введите возраст сотрудника\n" +
                          ">>> ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Введите зарплату сотрудника\n" +
                          ">>> ");
            
            int salary = int.Parse(Console.ReadLine());
            Console.Write("Введите количество проектов сотрудника\n" +
                          ">>> ");
            int projects = int.Parse(Console.ReadLine());
            Console.Write("Введите оригинальный номер сотрудника\n" +
                          ">>> ");
            int id = int.Parse(Console.ReadLine());
            Worker w = new Worker(name, surname, age, salary, projects, id, d);
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
            for (int i = 0; i <= peoples.Count-1; i++)
            {
                if (peoples[i].Id == id) peoples.Remove(peoples[i]);
            }
            foreach (var item in departments)
            {
                for (int i = 0; i <= item.workers.Count-1; i++)
                {
                    if (item.workers[i].Id == id) item.workers.Remove(item.workers[i]);
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
            foreach (var item in departments)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    for (int i = 0; i <= item.workers.Count-1; i++)
                    {
                        Worker w = item.workers[i];
                        int number = peoples.IndexOf(w);
                        peoples.RemoveAt(number);
                        w.flagD = false;
                        w.NameOfDepartment = null;
                        peoples.Insert(number, w);
                    }
                    departments.Remove(item);
                    break;
                }
            }
        }

        /// <summary>
        /// Поиск департамента по названию
        /// </summary>
        /// <param name="name">Название департамента</param>
        /// <returns>Департамент с указанным именем</returns>
        public Department FindDepartment(string name)
        {
            Department d = new Department();
            foreach (var item in departments)
            {
                if (item.Name.ToLower() == name.ToLower()) d = item;
            }
            return d;
        }

        /// <summary>
        /// Поиск работника из списка всех работников компании по id
        /// </summary>
        /// <param name="id">Уникальный номер сотрудника</param>
        /// <returns>Сотрудник с указанным номером</returns>
        public Worker FindWorker(int id)
        {
            Worker w = new Worker();
            foreach (var item in peoples)
            {
                if (item.Id == id) w = item;
            }
            return w;
        }

        /// <summary>
        /// Поиск сотрудника в департаменте
        /// </summary>
        /// <param name="id">Уникальный номер сотрудника</param>
        /// <param name="d">Департамент</param>
        /// <returns>Сотрудник</returns>
        public Worker FindWorker(int id, Department d)
        {
            Worker w = new Worker();
            foreach (var item in d.workers)
            {
                if (item.Id == id) w = item;
            }
            return w;
        }

        /// <summary>
        /// Вывод информации о депаратментах
        /// </summary>
        public void ReadDepartments()
        {
            foreach(var item in departments)
            {
                Console.WriteLine($"Название департамента - {item.Name}\n" +
                    $"Дата создания - {item.Date}\n" +
                    $"");
            }
        }

        /// <summary>
        /// Вывод информации о сотрудниках в компании
        /// </summary>
        public void ReadWorkers()
        {
            foreach (var item in peoples)
            {
                Console.WriteLine($"Имя сотрудника - {item.Name}\n" +
                    $"Фамилия - {item.Surname}\n" +
                    $"Возраст - {item.Age}\n" +
                    $"Зарплата - {item.Salary}\n" +
                    $"Количество проектов - {item.Projects}\n" +
                    $"Id - {item.Id}\n" +
                    $"Департамент - {item.NameOfDepartment}\n" +
                    $"");
            }
        }

        /// <summary>
        /// Вывод информации о сотрдуниках в департаменте
        /// </summary>
        /// <param name="d">Департамент с сотрудниками</param>
        public void ReadWorkers(Department d)
        {
            foreach (var item in d.workers)
            {
                Console.WriteLine($"Имя сотрудника - {item.Name}\n" +
                    $"Фамилия - {item.Surname}\n" +
                    $"Возраст - {item.Age}\n" +
                    $"Зарплата - {item.Salary}\n" +
                    $"Количество проектов - {item.Projects}\n" +
                    $"Id - {item.Id}\n" +
                    $"Департамент - {item.NameOfDepartment}\n" +
                    $"");
            }
        }





    }
}
