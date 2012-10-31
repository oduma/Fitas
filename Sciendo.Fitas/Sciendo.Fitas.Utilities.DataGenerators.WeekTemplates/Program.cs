using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sciendo.Fitas.Model;
using System.Xml.Serialization;
using System.IO;

namespace Sciendo.Fitas.Utilities.DataGenerators.WeekTemplates
{
    class Program
    {
        static void Main(string[] args)
        {
            List<WeekSummary> weekTemplates = new List<WeekSummary> 
                { 
                    new WeekSummary { WeekId = 1, NoOfSerries = 12, RunDue = 1, WalkDue = 4, Status = Status.NotStarted,NoOfDays=5 },
                    new WeekSummary { WeekId = 2, NoOfSerries = 12, RunDue = 2, WalkDue = 3, Status = Status.NotStarted,NoOfDays=5 },
                    new WeekSummary { WeekId = 3, NoOfSerries = 12, RunDue = 3, WalkDue = 2, Status = Status.NotStarted,NoOfDays=5 },
                    new WeekSummary { WeekId = 4, NoOfSerries = 12, RunDue = 4, WalkDue = 1, Status = Status.NotStarted,NoOfDays=5 },
                    new WeekSummary { WeekId = 5, NoOfSerries = 4, RunDue = 13, WalkDue = 2, Status = Status.NotStarted,NoOfDays=5 },
                    new WeekSummary { WeekId = 6, NoOfSerries = 4, RunDue = 14, WalkDue = 1, Status = Status.NotStarted,NoOfDays=5 },
                    new WeekSummary { WeekId = 7, NoOfSerries = 1, RunDue = 30, WalkDue = 0, Status = Status.NotStarted,NoOfDays=5 }
                };
            XmlSerializer xmlSerialzer = new XmlSerializer(typeof(List<WeekSummary>));
            using (FileStream fs = File.Open("weektemplates.xml", FileMode.Create))
            {
                xmlSerialzer.Serialize(fs, weekTemplates);
            }

            
        }
    }
}
