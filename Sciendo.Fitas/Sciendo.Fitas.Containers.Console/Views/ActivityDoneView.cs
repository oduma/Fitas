using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoCross.Navigation;
using Sciendo.Fitas.Model;
using MonoCross.Console;

namespace Sciendo.Fitas.Containers.Console.Views
{
    public class ActivityDoneView:MXView<ActivityInProgress>
    {
        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine("Well Done");
            System.Console.WriteLine();
            System.Console.WriteLine("Day {0}, Week {1}", Model.CurrentDay.DayId, Model.CurrentDay.WeekId);
            System.Console.WriteLine("({0} min Run - {1} min Walk)", Model.CurrentDay.WeekSummary.RunDue, Model.CurrentDay.WeekSummary.WalkDue);
            System.Console.WriteLine("{0:HH:mm:ss}", DateTime.Now);

            System.Console.WriteLine("(H)istory or Enter to go back");
            do
            {
                string input = System.Console.ReadLine().Trim();

                if (input.Length == 0)
                {
                    this.Back();
                    return;
                }
                if (input == "H")
                {
                    this.Navigate(string.Format("Weeks"));
                }

            } while (true);

        }
    }
}
