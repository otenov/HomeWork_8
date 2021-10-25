using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

//Почему не работает присваивание к списку списка
//Почему когда меняешь поля работника, они автоматически не меняются в списке

namespace HomeWork_8
{
    class Program
    {
        static void xmlSerialize(string Path, Company c)
        {
            XElement myCompany = new XElement("COMPANY");
            XElement myPeoples = new XElement("PEOPLES");
            XElement myDepartments = new XElement("DEPARTMENTS");
            XElement myWorker = new XElement("WORKER");

            XAttribute companyName = new XAttribute("name", c.Name);
            XAttribute peoplesName = new XAttribute("name", "Список сотрудников компании");
            XAttribute departmentsName = new XAttribute("name", "Список департаментов компании");
            myCompany.Add(companyName);

            myPeoples.Add(peoplesName);
            myDepartments.Add(departmentsName);

            myCompany.Add(myPeoples);
            myCompany.Add(myDepartments);
            myCompany.Save(Path);
        }
        static void Main(string[] args)
        {
            Company c = new Company("Рога и копыта");

            for(; ; )
            {
                Console.Write("Если вы хотите работать с департаментами, то нажмите 1\n" +
                    "Если вы хотите работать с сотрудниками, то нажмите 2\n" +
                    "Если вы хотите выйти, то нажмите 0\n" +
                    ">>> ");
                string answer = Console.ReadLine();
                Console.Clear();
                if (answer == "1")
                {
                    Console.Write("Если вы хотите создать новый департамент, то нажмите 1\n" +
                    "Если вы хотите удалить департамент, то нажмите 2\n" +
                    "Если вы хотите работать, с конкретным департаментом, то нажмите 3\n" +
                    "Если вы хотите получить список существующих департаментов, то нажмите 4\n" +
                    ">>> ");
                    answer = Console.ReadLine();
                    Console.Clear();
                    if (answer == "1")
                    {
                        Console.Write("Введите имя для нового департамента\n" +
                            ">>> ");
                        string name = Console.ReadLine();
                        Console.Clear();
                        c.CreateDepartment(name);
                    }
                    else if (answer == "2")
                    {
                        Console.Write("Введите имя департамента, который нужно удалить\n" +
                            ">>> ");
                        string name = Console.ReadLine();
                        Console.Clear();
                        c.DeleteDepartment(name);
                    }
                    else if (answer == "3")
                    {
                        Console.Write("Введите название департамента, с которым хотите работать\n" +
                            ">>> ");
                        string name = Console.ReadLine();
                        Department d5 = c.FindDepartment(name);
                        Console.Write("Если вы хотите добавить сотрудника в департамент, то нажмите 1\n" +
                        "Если вы хотите удалить сотрудника из департамента, то нажмите 2\n" +
                        "Если вы хотите редактировать департамент, то нажмите 3\n" +
                        "Если вы хотите прочитать список сотрудников в департаменте, то нажмите 4\n" +
                        ">>> ");
                        answer = Console.ReadLine();
                        if (answer == "1")
                        {
                            Console.Write("Если вы хотите создать нового сотрудника и добавить, то нажмите 1\n" +
                                "Если вы хотите добавить существующего сотрудника, то нажмите 2\n" +
                                ">>> ");
                            answer = Console.ReadLine();
                            if (answer == "1")
                            {
                                d5.Add(c.CreateWorker(d5));
                            }
                            else if (answer == "2")
                            {
                                Console.Write("Введите id сотрудника, которого нужно добавить в департамент\n" +
                                    ">>> ");
                                int id = int.Parse(Console.ReadLine());
                                Worker w = c.FindWorker(id);
                                if (!w.flagD) 
                                {
                                    c.peoples.Remove(w);
                                    w = d5.Add(w);
                                    c.peoples.Add(w);
                                }
                                else Console.WriteLine("Данный сотрудник прикреплен к другому департаменту, " +
                                    $"а именно к департаменту {w.NameOfDepartment}");
                            }
                        }
                        else if (answer == "2")
                        {
                            Console.Write("Введите id сотрудника, которого нужно удалить из департамента\n" +
                                ">>> ");
                            int id = int.Parse(Console.ReadLine());
                            Worker w = c.FindWorker(id, d5);
                            c.peoples.Remove(w);
                            w = d5.DeleteFromDepartment(w);
                            c.peoples.Add(w);
                        }
                        else if (answer == "3")
                        {
                            c.departments.Remove(d5);
                            Console.Write("Введите имя для нового департамента\n" +
                                          ">>> ");
                            name = Console.ReadLine();
                            Console.Write("Введите дату создания департамента\n" +
                                          ">>> ");
                            DateTime date = Convert.ToDateTime(Console.ReadLine());
                            d5.Edit(name, date);
                            c.departments.Add(d5);
                        }
                        else if (answer == "4") c.ReadWorkers(d5);
                        else
                        {
                            Console.WriteLine("Вы ввели что-то не то");
                        }
                    }
                    else if (answer == "4") c.ReadDepartments();
                }
                else if (answer == "2")
                {
                    Console.Write("Если вы хотите создать сотрудника, то нажмите 1\n" +
                    "Если вы хотите удалить сотрудника, то нажмите 2\n" +
                    "Если вы хотите редактировать сотрудника, то нажмите 3\n" +
                    "Если вы хотите прочитать список сотрудников в компании, то нажмите 4\n" +
                    ">>> ");
                    answer = Console.ReadLine();
                    if (answer == "1")
                    {
                        c.CreateWorker();
                    }
                    else if (answer == "2")
                    {
                        Console.Write("Введите id сотрудника, которого нужно удалить\n" +
                                ">>> ");
                        int id = int.Parse(Console.ReadLine());
                        c.DeleteWorker(id);
                    }
                    else if (answer == "3")
                    {
                        Console.Write("Введите id сотрудника, которого нужно редактировать\n" +
                                ">>> ");
                        int id = int.Parse(Console.ReadLine());
                        Worker w = c.FindWorker(id);
                        if (w.flagD)
                        {
                            Department d = c.FindDepartment(w.NameOfDepartment);
                            d.workers.Remove(w);
                        }
                        c.peoples.Remove(w);

                        Console.Write("Введите имя сотрудника\n" +
                          ">>> ");
                        string name = Console.ReadLine();
                        Console.Write("Введите фамилию сотрудника\n" +
                                      ">>> ");
                        string sername = Console.ReadLine();
                        Console.Write("Введите возраст сотрудника\n" +
                                      ">>> ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Введите зарплату сотрудника\n" +
                                      ">>> ");
                        int salary = int.Parse(Console.ReadLine());
                        Console.Write("Введите количество проектов сотрудника\n" +
                                      ">>> ");
                        int projects = int.Parse(Console.ReadLine());

                        w.Edit(name, sername, age, salary, projects);
                        c.peoples.Add(w);
                        if (w.flagD)
                        {
                            Department d = c.FindDepartment(w.NameOfDepartment);
                            d.workers.Add(w);
                        }
                    }
                    else if (answer == "4") c.ReadWorkers();

                }
                else if (answer == "0")
                {
                    break;
                }
            }

            string nameoffile = "trening.xml";
            xmlSerialize(nameoffile, c);
        }
    }
}
