using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoCross.Navigation;
using Sciendo.Fitas.Model;
using MonoCross.Console;
using System.Diagnostics;

namespace Sciendo.Fitas.Containers.Console.Views
{
    public class ActivityView:MXConsoleView<ActivityInProgress>
    {
        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine("Activity");
            System.Console.WriteLine();
            System.Console.WriteLine("Series{0}, Day {1}, Week {2}", Model.SeriesId, Model.CurrentDay.DayId, Model.CurrentDay.WeekId);
            System.Console.WriteLine("({0} min Run - {1} min Walk)", Model.CurrentDay.WeekSummary.RunDue, Model.CurrentDay.WeekSummary.WalkDue);
            System.Console.WriteLine("{0:HH:mm:ss}", DateTime.Now);
            
            System.Console.WriteLine("(S)tart activity, (H)istory or Enter to go back");
            do
            {
                string input = System.Console.ReadLine().Trim();

                if (input.Length == 0)
                {
                    this.Back();
                    return;
                }
                if (input == "S")
                {
                    this.Navigate(string.Format("Activity/START"));
                }
                if (input == "H")
                {
                    this.Navigate(string.Format("Weeks"));
                }
            } while (true);
        }
    }
}
