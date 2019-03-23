using KMA.ProgrammingInCSharp.Lab4.Views;
using System;
using System.Windows;

namespace KMA.ProgrammingInCSharp.Lab4.Tools
{
    internal enum ModesEnum
    {
        Main,
        AddPerson
    }
    class NavigationModel
    {
        private readonly Window _contentWindow;
        private MainView _mainView;
        private AddPersonView _addPersonView;

        internal NavigationModel(Window contentWindow)
        {
            _contentWindow = contentWindow;
        }

        internal MainView MainView
        {
            get { return _mainView; }
        }

        internal void Navigate(ModesEnum mode)
        {
            switch (mode)
            {
                case ModesEnum.Main:
                    _contentWindow.Content = _mainView ?? (_mainView = new MainView());
                    break;
                case ModesEnum.AddPerson:
                    _contentWindow.Content = _addPersonView ?? (_addPersonView = new AddPersonView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        }
    }
}
