using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationApp
{
    class Case
    {
        public int id { get; set; }

        public int age { get; set; }

        public string underlyingDisease { get; set; }

        public bool Symptoms { get; set; }

        public bool seriousSymptoms { get; set; } // e.g. very high fever, inability to breathe




        public string Severity() //example of a function (Not medically proven)
        {
            if (age > 75)
            {
                if (underlyingDisease != "None")
                {
                    return "high";
                }
                else
                {
                    if (!Symptoms)
                    {
                        return "medium";
                    }
                    else return "high";
                }
            }
            else if (age > 50 && age < 75)
            {
                if (seriousSymptoms)
                {
                    return "high";
                }
                else if (underlyingDisease != "None" && Symptoms)
                {
                    return "medium";
                }
                else return "low";
            }
            else
            {
                if (underlyingDisease != "None" && seriousSymptoms)
                {
                    return "high";
                }
                else if (seriousSymptoms && underlyingDisease == "None")
                {
                    return "medium";
                }
                else return "low";
            }
        }

    }
}
