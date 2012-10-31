using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoCross.Navigation;
using Sciendo.Fitas.Model;
using MonoCross.Console;

namespace Sciendo.Fitas.Containers.Console.Views
{
    public class DayView : MXView<Day>
    {
        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine("Day {0} Week {1} (Run: {2} min - Walk {3} min)x{4}", Model.DayId, Model.WeekId,
                Model.WeekSummary.RunDue, Model.WeekSummary.WalkDue, Model.WeekSummary.NoOfSerries);
            System.Console.WriteLine("Status: {0}", Model.Status);
            System.Console.WriteLine("Started at: {0}", Model.StartedAt);
            System.Console.WriteLine("Finished at: {0}", Model.FinishedAt);
            System.Console.WriteLine("Distance: {0}", Model.Distance);
            System.Console.WriteLine("Speed: {0}", Model.Speed);
            System.Console.WriteLine("No of steps: {0}", Model.NoOfSteps);

            System.Console.WriteLine();

            System.Console.WriteLine("(M)ap view, (P)ush to facebook, {0} day or Enter to go back",(Model.Status==Status.NotStarted)?"(S)tart":"(R)estart");
            do
            {
                string input = System.Console.ReadLine().Trim();

                if (input.Length == 0)
                {
                    this.Back();
                    return;
                }
                if (input.StartsWith("S") || input.StartsWith("R"))
                {
                    this.Navigate(string.Format("Activity/{0},{1}/GET", Model.WeekId, Model.DayId));
                }

            } while (true);
        }
    }
}
