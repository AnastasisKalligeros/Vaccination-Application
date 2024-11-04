using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationApp
{
    class Worker
    {
        public String Firstname { get; set; }

        public String Surname { get; set; }

        public String HiWorker()
        {
            return "Hi " + Firstname + " " + Surname;
        }
    }
}
