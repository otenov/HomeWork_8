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
            Random rnd = new Random();
            Worker w1 = new Worker("Петя", "Сидоров", 18, 50_000, 2, 1);
            Worker w2 = new Worker("Виктор", "Сычев", 20, 90_000, 5, 2);

            Department d1 = new Department("Программисты");
            Department d2 = new Department("Управление");

            d1.Add(w1);
            d1.DeleteFromDepartment(w2);

            //Dictionary<int, string> dic1 = new Dictionary<int, string>();
            //dic1.Add(w1.Id, d1.Name);
            Console.ReadLine();
        }
    }
}
