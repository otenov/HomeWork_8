using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{
    struct Worker
    {
        public string Name { get; set; }

        public string SerName { get; set; }

        public int Age { get; set; }

        public int Salary { get; set; }

        public int Projects { get; set; }

        public int Id { get; set; }

        public string NameOfDepartment { get; set; }

        public bool flagD;



        public Worker(string name, string sername, int age, int salary, int projects, int id)
        {
            this.Name = name;
            this.SerName = sername;
            this.Age = age;
            this.Salary = salary;
            this.Projects = projects;
            this.Id = id;
            this.NameOfDepartment = "";
            this.flagD = false;
        }

        public Worker(string name, string sername, int age, int salary, int projects, int id, Department d)
        {
            this.Name = name;
            this.SerName = sername;
            this.Age = age;
            this.Salary = salary;
            this.Projects = projects;
            this.Id = id;
            this.NameOfDepartment = d.Name;
            this.flagD = true;
        }

        public void Edit(string name, string sername, int age, int salary, int projects)
        {
            this.Name = name;
            this.SerName = sername;
            this.Age = age;
            this.Salary = salary;
            this.Projects = projects;
        }
    }
}
