using System.Windows;
using KMA.ProgrammingInCSharp.Lab4.ViewModels;

namespace KMA.ProgrammingInCSharp.Lab4.Views
{
    /// <summary>
    /// Interaction logic for AddPersonView.xaml
    /// </summary>
    public partial class AddPersonView
    {
        private AddPersonViewModel _addPersonViewModel;
        public AddPersonView()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Visibility = Visibility.Visible;
            _addPersonViewModel = new AddPersonViewModel();
            DataContext = _addPersonViewModel;
        }
    }
}
