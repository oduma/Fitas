using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoCross.Navigation;
using Sciendo.Fitas.Model;
using System.Threading;

namespace Sciendo.Fitas.Containers.Console.Views
{
    public class ActivityStartedView:MXView<ActivityInProgress>
    {
        private static int counter = 1;
        
        public override void Render()
        {
            while (Model.ActivityRemainingTime.TotalSeconds > 0)
            {
                System.Console.Clear();
                System.Console.WriteLine("Activity");
                System.Console.WriteLine();
                System.Console.WriteLine("Series{0}, Day {1}, Week {2}", Model.SeriesId, Model.CurrentDay.DayId, Model.CurrentDay.WeekId);
                System.Console.WriteLine("({0} min Run - {1} min Walk)", Model.CurrentDay.WeekSummary.RunDue, Model.CurrentDay.WeekSummary.WalkDue);

                System.Console.WriteLine("{0:HH:mm:ss}", DateTime.Now);
                System.Console.WriteLine("{0} till: {1:HH:mm:ss} ({2}:{3} left)", Model.SeriesStatus.ToString(), 
                    Model.TargetFinishBy, Model.ActivityRemainingTime.Minutes, Model.ActivityRemainingTime.Seconds);
                Model.ActivityRemainingTime = Model.ActivityRemainingTime.Subtract(new TimeSpan(0, 0, 1));
                System.Console.WriteLine("(S)top activity and forfeit day");
                Thread.Sleep(1000);
            }
            this.Navigate(string.Format("Activity/{0}/CHANGE", Model.SeriesId));
        }
    }
}
