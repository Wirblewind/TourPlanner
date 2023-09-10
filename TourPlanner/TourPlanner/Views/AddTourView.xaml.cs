﻿using System;
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

namespace TourPlanner.Views
{
    /// <summary>
    /// Interaction logic for AddTourView.xaml
    /// </summary>
    public partial class AddTourView : Window
    {
        public AddTourView()
        {
            InitializeComponent();
            System.Diagnostics.Debug.WriteLine("AddTourView");
            var viewModel = DataContext as AddTourViewModel;
            if (viewModel != null)
            {
                viewModel.CloseRequested += Close;
            }
        }

    }
}
