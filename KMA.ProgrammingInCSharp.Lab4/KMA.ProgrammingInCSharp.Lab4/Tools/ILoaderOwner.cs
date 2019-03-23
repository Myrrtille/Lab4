using System.ComponentModel;
using System.Windows;

namespace KMA.ProgrammingInCSharp.Lab4.Tools
{
    internal interface ILoaderOwner : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsEnabled { get; set; }
    }
}
