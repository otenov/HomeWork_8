using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Company c = new Company();

            for(; ; )
            {
                Console.Write("Если вы хотите работать с департаментами, то нажмите 1\n" +
                    "Если вы хотите работать с сотрудниками, то нажмите 2\n" +
                    ">>> ");
                string answer = Console.ReadLine();
                Console.Clear();
                if (answer == "1")
                {
                    Console.Write("Если вы хотите создать новый департамент, то нажмите 1\n" +
                    "Если вы хотите удалить департамент, то нажмите 2\n" +
                    "Если вы хотите работать, с конкретным департаментом, то нажмите 3\n" +
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
                        ">>> ");
                        answer = Console.ReadLine();
                        if (answer == "1")
                        {
                            Console.Write("Если вы хотите создать нового сотрудника и добавить, то нажмите 1\n" +
                                "Если вы хотите добавить существующего сотрудника, то нажмите 2\n" +
                                ">>> ");
                            answer = Console.ReadLine();
                            if(answer == "1")
                            {
                                d5.Add(c.CreateWorker(d5));
                            }
                            else if (answer == "2")
                            {
                                Console.Write("Введите id сотрудника, которого нужно добавить в департамент\n" +
                                    ">>> ");
                                int id = int.Parse(Console.ReadLine());
                                Worker w = c.FindWorker(id);
                                if (!w.flagD) d5.Add(w);
                                else Console.WriteLine("Данный сотрудник прикреплен к другому департаменту," +
                                    $"а именно к департаменту {w.NameOfDepartment}"); 
                            }
                        }
                        else if (answer == "2")
                        {
                            Console.Write("Введите id сотрудника, которого нужно удалить из департамента\n" +
                                ">>> ");
                            int id = int.Parse(Console.ReadLine());
                            Worker w = c.FindWorker(id, d5);
                            d5.DeleteFromDepartment(w);
                        }
                        else if (answer == "3")
                        {
                            Console.Write("Введите имя для нового департамента\n" +
                                          ">>> ");
                            name = Console.ReadLine();
                            Console.Write("Введите имя для нового департамента\n" +
                                          ">>> ");
                            DateTime date = Convert.ToDateTime(Console.ReadLine());
                            d5.Edit(name, date);
                        }
                        else
                        {
                            Console.WriteLine("Вы ввели что-то не то");
                        }
                    }
                }
                else if (answer == "2")
                {

                }
                else 
            }

            Console.ReadLine();

        }
    }
}
