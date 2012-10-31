using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoCross.Navigation;
using Sciendo.Fitas.Model;
using MonoCross.Console;

namespace Sciendo.Fitas.Containers.Console.Views
{
    public class WeeksListView:MXView<List<WeekSummary>>
    {
        public override void Render()
        {
            System.Console.Clear();
            System.Console.WriteLine("Weeks List");
            System.Console.WriteLine();
            Model.ForEach((w) => {
                System.Console.WriteLine("Week {0} (Run: {1} min - Walk {2} min)x{3} {4}", w.WeekId,w.RunDue,w.WalkDue,w.NoOfSerries,w.Status);
                
            });

            System.Console.WriteLine("(W#) or Enter to go back");
            do
            {
                string input = System.Console.ReadLine().Trim();

                if (input.Length == 0)
                {
                    this.Back();
                    return;
                }
                int weekId = 0;
                if (input.StartsWith("W") && int.TryParse(input.Replace("W",""), out weekId))
                {
                    this.Navigate(string.Format("Weeks/{0}",weekId));
                }

            } while (true);


        }
    }
}
