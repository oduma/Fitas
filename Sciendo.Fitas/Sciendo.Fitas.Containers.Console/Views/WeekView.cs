using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoCross.Navigation;
using Sciendo.Fitas.Model;
using MonoCross.Console;

namespace Sciendo.Fitas.Containers.Console.Views
{
    public class WeekView : MXView<WeekDetail>
    {
        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine("Week {0} (Run: {1} min - Walk {2} min)x{3} {4}", Model.WeekId,
                Model.RunDue, Model.WalkDue, Model.NoOfSerries, Model.Status);
            System.Console.WriteLine();
            Model.DaySummaries.ForEach((d) =>
            {
                System.Console.WriteLine("Day {0} x{1} {2}", d.DayId, Model.NoOfSerries, d.Status);
            });

            System.Console.WriteLine("(D#) for details, (S#) start day, or Enter to go back");
            do
            {
                string input = System.Console.ReadLine().Trim();

                if (input.Length == 0)
                {
                    this.Back();
                    return;
                }
                int dayId = 0;
                if (input.StartsWith("D") && int.TryParse(input.Replace("D", ""), out dayId))
                {
                    this.Navigate(string.Format("Day/{0},{1}", Model.WeekId,dayId));
                }
                if (input.StartsWith("S") && int.TryParse(input.Replace("S", ""), out dayId))
                {
                    this.Navigate(string.Format("Activity/{0},{1}/START", Model.WeekId, dayId));
                }

            } while (true);


        }
    }
}
