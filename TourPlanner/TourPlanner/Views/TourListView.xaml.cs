using Microsoft.EntityFrameworkCore;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TourPlanner.Models;
using TourPlanner.ViewModels;

namespace TourPlanner.Views
{
    /// <summary>
    /// Interaction logic for TourListView.xaml
    /// </summary>
    /// 
    public partial class TourListView : UserControl
    {
        private TourListViewModel? viewModel;
        private TourPlannerContext _context;
        public TourListView()
        {
            InitializeComponent();
            this._context = new TourPlannerContext();
            this.viewModel = new TourListViewModel(_context);
            this.DataContext = this.viewModel;
        }
    }
}
