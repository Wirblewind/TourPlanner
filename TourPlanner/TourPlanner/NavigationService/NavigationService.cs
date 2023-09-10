using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Views;

public class NavigationService : INavigationService
{
    public void NavigateToAddTourView()
    {
        AddTourView addTourView = new AddTourView();
        addTourView.Show();
    }
}
