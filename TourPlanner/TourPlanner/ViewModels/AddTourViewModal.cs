using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;
using TourPlanner.Models;
using System.Windows.Controls;
using System.Reflection.Metadata;
using System.Windows;

public class AddTourViewModel : INotifyPropertyChanged
{
    // ... Ihre vorhandenen Eigenschaften und Methoden
    public int Tourid { get; set; }
    public string Tourname { get; set; } = null!;
    public string? Tourdescription { get; set; }
    public string Tourfrom { get; set; } = null!;
    public string Tourto { get; set; } = null!;
    public ComboBoxItem Tourtransporttype { get; set; } = null!;
    public string Tourdistance { get; set; } = null!;
    public string Tourtimeestimate { get; set; } = null!;
    public string Tourrouteinformation { get; set; } = null!;

    public event Action<Tour> TourAdded;

    private TourPlannerContext context;
    //public event Action<Tour> TourEdited;

    // Visability of Loader
    private Visibility _loadingBackGroundVisibility = Visibility.Collapsed;
    public Visibility LoadingBackGroundVisibility
    {
        get { return _loadingBackGroundVisibility; }
        set
        {
            if (_loadingBackGroundVisibility != value)
            {
                _loadingBackGroundVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoadingBackGroundVisibility)));
            }
        }
    }

    private Visibility _loadingForeGroundVisibility = Visibility.Collapsed;
    public Visibility LoadingForeGroundVisibility
    {
        get { return _loadingForeGroundVisibility; }
        set
        {
            if (_loadingForeGroundVisibility != value)
            {
                _loadingForeGroundVisibility = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoadingForeGroundVisibility)));
            }
        }
    }

    public AddTourViewModel(TourPlannerContext context)
    {
        this.context = context;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    public async Task AddTourAsync()
    {
        using (context)
        {
            MapQuestAPIService apiService = new MapQuestAPIService();
            Tour newTour = await apiService.GetTourApiData(this.Tourname, this.Tourdescription, this.Tourfrom, this.Tourto, this.Tourtransporttype);

            Tour tour = new Tour
            {
                Tourname = this.Tourname,
                Tourdescription = this.Tourdescription,
                Tourfrom = this.Tourfrom,
                Tourto = this.Tourto,
                Tourtransporttype = newTour.Tourtransporttype,
                Tourdistance = newTour.Tourdistance,
                Tourtimeestimate = newTour.Tourtimeestimate,
                Tourrouteinformation = newTour.Tourrouteinformation,
            };
            // System.Diagnostics.Debug.WriteLine($"Tour: {tour.Tourname}");
            context.Tours.Add(tour);
            await context.SaveChangesAsync();

            // TourAdded?.Invoke(tour);

            tour.Tourrouteinformation = await apiService.GetApiMapData(tour);

            System.Diagnostics.Debug.WriteLine($"Tourid: {tour.Tourid}");
        }
    }
}
