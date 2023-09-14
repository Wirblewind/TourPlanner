using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.Models;

public class TourListViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;
    private ObservableCollection<Tour> _tours;
    private TourPlannerContext context;

    public TourListViewModel(TourPlannerContext context)
    {
        this.context = context;
        this.Tours = new ObservableCollection<Tour>(context.Tours.ToList());
    }

    public void OnTourAdded(Tour newTour)
    {
        Tours.Add(newTour);
        context.SaveChanges();
    }

    public ObservableCollection<Tour> Tours
    {
        get { return _tours; }
        set
        {
            if (_tours != value)
            {
                _tours = value;
                OnPropertyChanged("Tours");
            }
        }
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
