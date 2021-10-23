using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{
    struct Company
    {
        public List<Worker> people;

        public void CreateWorker()
        {
            Worker w = new Worker();
            people.Add(w);
        }
    }
}
