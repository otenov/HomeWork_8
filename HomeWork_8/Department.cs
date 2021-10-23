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
            worker.flagD = true;
        }

        public void DeleteFromDepartment(Worker worker)
        {
            workers.Remove(worker);
            worker.flagD = false;
        }

        public void Edit(string name, DateTime date)
        {
            this.Name = name;
            this.Date = date;
        }
    }
}
