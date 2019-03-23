using KMA.ProgrammingInCSharp.Lab4.Managers;
using KMA.ProgrammingInCSharp.Lab4.Tools;
using KMA.ProgrammingInCSharp.Lab4.ViewModels;
using System.Windows;

namespace KMA.ProgrammingInCSharp.Lab4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            var navigationModel = new NavigationModel(this);
            NavigationManager.Instance.Initialize(navigationModel);
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            DataContext = mainWindowViewModel;
            mainWindowViewModel.StartApplication();
        }
    }
}
