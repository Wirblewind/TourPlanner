using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TourPlanner.Models;
using static System.Net.Mime.MediaTypeNames;

namespace TourPlanner.Views
{
    /// <summary>
    /// Interaction logic for AddTourView.xaml
    /// </summary>
    public partial class AddTourView : Window
    {
        private AddTourViewModel? viewModel;
        private TourPlannerContext _context;
        public AddTourView()
        {
            InitializeComponent();
            _context = new TourPlannerContext();
            this.viewModel = new AddTourViewModel(_context);
            this.DataContext = viewModel;
        }

        private async void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel != null)
            {
                // Validate the input fields
                if (string.IsNullOrEmpty(viewModel.Tourname) ||
                    string.IsNullOrEmpty(viewModel.Tourfrom) ||
                    string.IsNullOrEmpty(viewModel.Tourto) ||
                    string.IsNullOrEmpty(viewModel.Tourtransporttype.Content.ToString()))
                {
                    MessageBox.Show("All fields must be filled out.");
                    return;
                }

                viewModel.LoadingBackGroundVisibility = Visibility.Visible;
                viewModel.LoadingForeGroundVisibility = Visibility.Visible;

                // Perform the add tour logic here
                await viewModel.AddTourAsync();  // Call the AddTourAsync method here

                // Perform the add tour logic here
                // ...

                // Close the window if needed
                MessageBox.Show("Your Tour has been added.");
                Close();
            }
        }

    }
}
