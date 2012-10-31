using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MonoCross.Console;
using Sciendo.Fitas.Model;
using MonoCross.Navigation;

namespace Sciendo.Fitas.Containers.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialize container
            MXConsoleContainer.Initialize(new Sciendo.Fitas.App());

            // activity view
            MXConsoleContainer.AddView<ActivityInProgress>(new Views.ActivityView(), ViewPerspective.Default);

            // activity in progress view
            MXConsoleContainer.AddView<ActivityInProgress>(new Views.ActivityStartedView(), "STARTED");

            // activity view
            MXConsoleContainer.AddView<ActivityInProgress>(new Views.ActivityDoneView(), "DONE");

            //weeks list view
            MXConsoleContainer.AddView<List<WeekSummary>>(new Views.WeeksListView(), ViewPerspective.Default);

            //week view
            MXConsoleContainer.AddView<WeekDetail>(new Views.WeekView(), ViewPerspective.Default);

            //day view
            MXConsoleContainer.AddView<Day>(new Views.DayView(), ViewPerspective.Default);

            // navigate to first view
            MXConsoleContainer.Navigate(MXContainer.Instance.App.NavigateOnLoad);

        }
    }
}
