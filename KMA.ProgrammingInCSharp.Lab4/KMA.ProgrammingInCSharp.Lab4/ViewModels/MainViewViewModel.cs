using System;
using KMA.ProgrammingInCSharp.Lab4.Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using KMA.ProgrammingInCSharp.Lab4.Managers;
using KMA.ProgrammingInCSharp.Lab4.Tools;
using System.Collections.ObjectModel;
using System.Linq;

namespace KMA.ProgrammingInCSharp.Lab4.ViewModels
{
    class MainViewViewModel : INotifyPropertyChanged
    {

        #region Command + Prop

        private ICommand _addPersonCommand;

        public ICommand AddPersonCommand
        {
            get { return _addPersonCommand ?? (_addPersonCommand = new RelayCommand<KeyEventArgs>(AddPersonExecute)); }
        }

        #endregion 

        public ObservableCollection<Person> PersonArr
        {
            get { return StationManager.PesonList; }
            private set { StationManager.PesonList = value; }
        }

        public MainViewViewModel()
        {
            ObservableCollection<Person> _prs = Serialization.SerializationManager.Deserialize<ObservableCollection<Person>>(Cnst.StorageFilePath);
            if (_prs != null)
                PersonArr = new ObservableCollection<Person>(_prs);
            else PersonArrSet();
            OnPropertyChanged();
        }

        private void AddPersonExecute(object o)
        {
            LoaderManager.Instance.ShowLoader();
            NavigationManager.Instance.Navigate(ModesEnum.AddPerson);
            LoaderManager.Instance.HideLoader();
            OnPropertyChanged();
        }

        private void PersonArrSet()
        {
            PersonArr = new ObservableCollection<Person>();
            PersonArr.Add(new Person("Anna", "Shkuta", "shkutaanna@gmail.com", new DateTime(1998, 10, 10)));
            PersonArr.Add(new Person("Katya", "Ivanova", "kate@gmail.com", new DateTime(1901, 12, 1)));
            PersonArr.Add(new Person("Alisa", "Belaya", "alice@gmail.com", new DateTime(1997, 3, 10)));
            PersonArr.Add(new Person("Masha", "Ivashchenko", "mary@gmail.com", new DateTime(1972, 12, 1)));
            PersonArr.Add(new Person("Alina", "Smirnova", "alinka@gmail.com", new DateTime(1965, 4, 9)));
            PersonArr.Add(new Person("Petya", "Petrov", "petro@gmail.com", new DateTime(2001, 12, 1)));
            PersonArr.Add(new Person("Andrij", "Chernenkij", "andrey@gmail.com", new DateTime(2004, 12, 10)));
            PersonArr.Add(new Person("Misha", "Ivanov", "michan@gmail.com", new DateTime(1988, 7, 6)));
            PersonArr.Add(new Person("Dima", "Krasnyj", "dimon@gmail.com", new DateTime(1961, 12, 1)));
            PersonArr.Add(new Person("Miron", "Polyakov", "miron1@gmail.com", new DateTime(2002, 8, 8)));
            PersonArr.Add(new Person("Vadym", "Lykavyj", "vadik@gmail.com", new DateTime(2004, 11, 6)));
            PersonArr.Add(new Person("Slavik", "Ruskij", "slavoon@gmail.com", new DateTime(1996, 12, 1)));
            PersonArr.Add(new Person("Daniil", "Nester", "dan@gmail.com", new DateTime(1993, 9, 9)));
            Random rnd = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = 0; i < 37; i++)
            {
                string fn = new string(Enumerable.Repeat(chars, 3).Select(s => s[rnd.Next(s.Length)]).ToArray());
                string sn = new string(Enumerable.Repeat(chars, 3).Select(s => s[rnd.Next(s.Length)]).ToArray()); ;
                string em = fn + sn + "@ukr.net";
                DateTime dt = new DateTime(rnd.Next(1900,2019),rnd.Next(1,12),rnd.Next(1,27));
                PersonArr.Add(new Person(fn,sn,em,dt));
            }
            Serialization.SerializationManager.Serialize(PersonArr,Cnst.StorageFilePath);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
