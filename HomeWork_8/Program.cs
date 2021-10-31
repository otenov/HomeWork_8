using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;


namespace HomeWork_8
{
    class Program
    {
        //Сериализация и десериализация ручная
        static void xmlSerialize(string Path, Company c)
        {
            XElement myCompany = new XElement("COMPANY");
            XAttribute companyName = new XAttribute("name", c.Name);
            myCompany.Add(companyName);

            XElement myPeoples = new XElement("PEOPLES");
            XAttribute peoplesName = new XAttribute("name", "Список сотрудников компании");
            myPeoples.Add(peoplesName);

            XElement myDepartments = new XElement("DEPARTMENTS");
            XAttribute departmentsName = new XAttribute("name", "Список департаментов компании");
            myDepartments.Add(departmentsName);


            //Добавляем теги
            myCompany.Add(myPeoples);
            myCompany.Add(myDepartments);

            //Добавляем коллекцию департаментов
            foreach(var item in c.departments)
            {
                XElement dep = new XElement("Department");
                XElement depName= new XElement("name", item.Name);
                XElement depDate = new XElement("date", item.Date);
                dep.Add(depName, depDate);
                foreach (var i in item.workers)
                {
                    XElement worker = new XElement("Worker");
                    XElement workerSurame = new XElement("Surname", i.Surname);
                    XElement workerId = new XElement("Id", i.Id);
                    worker.Add(workerSurame, workerId);
                    dep.Add(worker);
                }
                myDepartments.Add(dep);
            }
            
            //Добавляем коллекцию сотрудников
            foreach(var item in c.peoples)
            {
                XElement p = new XElement("Worker");
                XElement pId = new XElement("id", item.Id);
                XElement pName = new XElement("Name", item.Name);
                XElement pSurname = new XElement("Surname", item.Surname);
                XElement pAge = new XElement("Age", item.Age);
                XElement pSalary = new XElement("Salary", item.Salary);
                XElement pProjects = new XElement("CountofProjects", item.Projects);
                XElement pNameOfDepartment = new XElement("Department", item.NameOfDepartment);
                p.Add(pId, pName, pSurname, pAge, pSalary, pProjects, pNameOfDepartment);
                myPeoples.Add(p);
            }

            //Сохраняем
            myCompany.Save(Path+".xml");
        }

        static void xmlDeserialize(string Path)
        {
            string xml = File.ReadAllText(Path+".xml");
            XDocument document = XDocument.Parse(xml);

            string nameOfCompany = document.Element("COMPANY").Attribute("name").Value;
            Console.WriteLine("Компания "+nameOfCompany);

            Console.WriteLine("\t\t\tСписок сотрудников компании\n");
            var workers = document
                        .Descendants("COMPANY")
                        .Descendants("PEOPLES")
                        .Descendants("Worker").ToList();
            foreach (var item in workers)
            {
                Console.WriteLine("Номер сотрудника {0}\n" +
                    "Имя {1}\n" +
                    "Фамилия {2}\n" +
                    "Возраст {3}\n" +
                    "Зарплата {4}\n" +
                    "Количество проектов {5}\n" +
                    "Департамент {6}\n\n", item.Element("id").Value,
                    item.Element("Name").Value,
                    item.Element("Surname").Value,
                    item.Element("Age").Value,
                    item.Element("Salary").Value,
                    item.Element("CountofProjects").Value,
                    item.Element("Department").Value);
            }

            Console.WriteLine("\t\t\tСписок департаментов компании\n");
            var departments = document
                             .Descendants("COMPANY")
                             .Descendants("DEPARTMENTS")
                             .Descendants("Department").ToList();
            foreach (var item in departments)
            {
                Console.WriteLine("Название {0}\n" +
                  "Дата создания {1}\n",
                  item.Element("name").Value,
                  item.Element("date").Value);
                string lastNode = item.LastNode.ToString();
                XElement depWorker = XElement.Parse(lastNode);
                XName name = "Worker";
                if (depWorker.Name.Equals(name))
                {
                    Console.WriteLine("В отделе работают:");
                    var dWorkers = document.Descendants("COMPANY")
                             .Descendants("DEPARTMENTS")
                             .Descendants("Department")
                             .Descendants("Worker").ToList();
                    foreach (var w in dWorkers)
                    {
                        Console.WriteLine(w.Element("Surname").Value + "\nId" + w.Element("Id").Value + "\n");
                    }
                    Console.WriteLine("\n");
                } 
            }
        }

        //Сериализация и десериализация с помощью XmlSerializer
        static void xmlSerialize2(string Path, Company c)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Company));

            using (FileStream f = new FileStream(Path, FileMode.OpenOrCreate))
            {
                xml.Serialize(f, c);
            }
        }

        static Company xmlDeserialize2(string Path)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Company));

            using (FileStream f = new FileStream(Path, FileMode.Open))
            {
                Company company = (Company)xml.Deserialize(f);
                return company;
            }
        }

        static void Main(string[] args)
        {
            Company c = new Company("Рога и копыта");

            string file = "Company";
            for(; ; )
            {
                Console.Write("Если вы хотите, начать работу с компанией, то нажмите 1\n" +
                        "Если вы хотите загрузить данные из собственно собранного файла, то нажмите 2\n" +
                        "Если вы хотите выйти, то нажмите 0\n" +
                        ">>> ");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    for (; ; )
                    {
                        Console.Write("Если вы хотите работать с департаментами, то нажмите 1\n" +
                            "Если вы хотите работать с сотрудниками, то нажмите 2\n" +
                            "Если вы хотите сохранить данные и выйти, то нажмите 3\n" +
                            "Если вы хотите выйти, то нажмите 0\n" +
                            ">>> ");
                        answer = Console.ReadLine();
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
                                            int index = c.peoples.IndexOf(w);
                                            c.peoples.RemoveAt(index);
                                            w = d5.Add(w);
                                            c.peoples.Insert(index, w);
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

                                    int index = c.peoples.IndexOf(w);
                                    c.peoples.RemoveAt(index);
                                    w = d5.DeleteFromDepartment(w);
                                    c.peoples.Insert(index, w);
                                }
                                else if (answer == "3")
                                {
                                    int index = c.departments.IndexOf(d5);
                                    c.departments.RemoveAt(index);
                                    Console.Write("Введите имя для нового департамента\n" +
                                                  ">>> ");
                                    name = Console.ReadLine();
                                    Console.Write("Введите дату создания департамента\n" +
                                                  ">>> ");
                                    DateTime date = Convert.ToDateTime(Console.ReadLine());
                                    d5.Edit(name, date);
                                    c.departments.Insert(index, d5);

                                    for (int i = 0; i <= d5.workers.Count - 1; i++)
                                    {
                                        Worker worker = d5.workers[i];
                                        index = c.peoples.IndexOf(worker);
                                        d5.workers.RemoveAt(i);
                                        worker.EditDepartment(d5.Name);
                                        d5.workers.Insert(i, worker);
                                        c.peoples.RemoveAt(index);
                                        c.peoples.Insert(index, worker);
                                    }
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
                                int indexD = 0, indexP = c.peoples.IndexOf(w);
                                if (w.flagD)
                                {
                                    Department d = c.FindDepartment(w.NameOfDepartment);
                                    indexD = d.workers.IndexOf(w);
                                    d.workers.RemoveAt(indexD);
                                }
                                c.peoples.RemoveAt(indexP);

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

                                w.Edit(name, surname, age, salary, projects);
                                c.peoples.Insert(indexP, w);
                                if (w.flagD)
                                {
                                    Department d = c.FindDepartment(w.NameOfDepartment);
                                    d.workers.Insert(indexD, w);
                                }
                            }
                            else if (answer == "4") c.ReadWorkers();

                        }
                        else if (answer == "3")
                        {
                            Console.Write("Введите имя файла\n" +
                                ">>> ");
                            string name = Console.ReadLine();
                            xmlSerialize2( name + ".xml", c);
                            Console.WriteLine("\n\nДесериализация");
                            Company company = xmlDeserialize2(name+".xml");
                            foreach (Department item in company.departments)
                            {
                                    Console.WriteLine($"Список департаментов\n" +
                                        $"{item.Name}\n" +
                                        $"{item.Date}\n");
                            }
                            foreach (Worker item in company.peoples)
                            {
                                    Console.WriteLine($"Список сотрудников\n" +
                                        $"{item.Name}\n" +
                                        $"{item.Id}");
                            }
                        }
                        else if (answer == "0")
                        {
                            xmlSerialize(file, c);
                            Console.WriteLine($"Был создан файл с именем {file}.xml\nПока!)");
                            break;
                        }
                    }
                }
                else if (answer == "2")
                {
                    xmlDeserialize(file);
                }
                else
                {
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
