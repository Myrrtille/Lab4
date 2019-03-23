using KMA.ProgrammingInCSharp.Lab4.Tools;
using KMA.ProgrammingInCSharp.Lab4.ViewModels;
using System;
using System.Windows;
using KMA.ProgrammingInCSharp.Lab4.Managers;

namespace KMA.ProgrammingInCSharp.Lab4.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView
    {
        private MainViewViewModel _mainViewViewModel;
        public MainView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Visibility = Visibility.Visible;
            _mainViewViewModel = new MainViewViewModel();
            DataContext = _mainViewViewModel;
        }

        private void PersonsGrid_OnCurrentCellChanged(object sender, EventArgs e)
        {
            personsGrid.Items.Refresh();
            Serialization.SerializationManager.Serialize(StationManager.PesonList, Cnst.StorageFilePath);
        }
    }
}
