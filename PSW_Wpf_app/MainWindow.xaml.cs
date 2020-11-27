﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using PSW_Wpf_app.Model;
using PSW_Wpf_app.View;
using PSW_Wpf_app.ViewModel;

namespace PSW_Wpf_app
{

    public partial class MainWindow : Window
    {
        public List<string> names = new List<string>();

        List<GraphicElement> elements = new List<GraphicElement>();


        private List<RoomWrapper> foundRooms = new List<RoomWrapper>();

        public List<RoomWrapper> FoundRooms
        {
            get { return foundRooms; }
            set { foundRooms = value; }
        }

        public List<string> Names
        {
            get { return names; }
            set { }

        }

        public MainWindow()
        {
            InitializeComponent();
            elements = ShapeViewModel.Read();
            foreach (GraphicElement e in elements)
            {
                names.Add(e.Name);
            }
            userControl.Content = new MainBuildingView();

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (buildC.SelectedItem == null)
            {
                MessageBox.Show("You must choose building.");
            }
            else if (floorC.SelectedItem == null)
            {
                MessageBox.Show("You must choose floor.");
            }
            else
            {
                this.userControl.Content = new ChosenFloorView(((GraphicElement)buildC.SelectedItem).Name, int.Parse(floorC.SelectedItem.ToString()), FoundRooms);
            }
        }

        private void Button_Click_HOME(object sender, RoutedEventArgs e)
        {
            this.userControl.Content = new MainBuildingView();
            FoundRooms = new List<RoomWrapper>();
        }

        private void OnMoreInfoClick(object sender, RoutedEventArgs e)
        {
            BuildingsInformationView buildingsInformationView = new BuildingsInformationView();
            buildingsInformationView.Show();
        }

        private void Search(object sender, RoutedEventArgs e)
        {
            if (SearchBuilding.Text == "")
            {
                MessageBox.Show("You must enter room for search.");
            }
            else
            {
                FoundRooms = new List<RoomWrapper>();

                SearchResultView searchResultView = new SearchResultView(SearchBuilding.Text);
                searchResultView.Show();

                SearchResultViewModel sw = (SearchResultViewModel)searchResultView.DataContext;
                FoundRooms = sw.SearchResults;
            }
        }

        private void ValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9a-zA-Z_]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }

}
