using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;
using TourPlanner.Models;
using TourPlanner.Views;

namespace TourPlanner.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Tour> _tours;
        private TourPlannerContext _context;

        private INavigationService _navigationService;

        public AddTourViewModel addTourViewModel { get; private set; }
        public TourListViewModel tourListView { get; private set; }

        public MainViewModel(INavigationService navigationService)
        {
            _context = new TourPlannerContext();
            Tours = new ObservableCollection<Tour>(_context.Tours.ToList());

            _navigationService = navigationService;
            // AddTourCommand = new RelayCommand(() => _navigationService.NavigateToAddTourView());
            this.AddTourCommand = new RelayCommand(() => _navigationService.NavigateToAddTourView());

            addTourViewModel = new AddTourViewModel(_context);  // Initialize the new instance
            addTourViewModel.TourAdded += OnTourAdded;

            tourListView = new TourListViewModel(_context);
            addTourViewModel.TourAdded += tourListView.OnTourAdded;
        }

        private void OnTourAdded(Tour newTour)
        {
            Tours.Add(newTour);
        }


        public ICommand AddTourCommand { get; private set; }

        public ObservableCollection<Tour> Tours
        {
            get { return _tours; }
            set
            {
                _tours = value;
                OnPropertyChanged("Tours");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        private void OnPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
