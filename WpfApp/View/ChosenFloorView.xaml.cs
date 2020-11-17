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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp.ViewModel;

namespace WpfApp.View
{
    /// <summary>
    /// Interaction logic for ChosenFloorView.xaml
    /// </summary>
    public partial class ChosenFloorView : UserControl
    {
        public ChosenFloorView(string build, int floor)
        {
            InitializeComponent();
            DataContext = new ChoesenFloorViewModel(CanvasFloor, build, floor);
        }
    }
}
