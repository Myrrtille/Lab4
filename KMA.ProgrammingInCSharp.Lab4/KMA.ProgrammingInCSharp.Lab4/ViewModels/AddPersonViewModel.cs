using KMA.ProgrammingInCSharp.Lab4.Managers;
using KMA.ProgrammingInCSharp.Lab4.Models;
using KMA.ProgrammingInCSharp.Lab4.Tools;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KMA.ProgrammingInCSharp.Lab4.ViewModels
{
    class AddPersonViewModel : INotifyPropertyChanged
    {
        #region Fields

        private Person _person;

        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthDate = new DateTime(1999, 1, 1);

        #endregion

        #region Properties

        internal Person Person
        {
            get { return _person; }
            set { _person = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Command + Prop

        private ICommand _proceedCommand;

        public ICommand ProceedCommand
        {
            get { return _proceedCommand ?? (_proceedCommand = new RelayCommand<KeyEventArgs>(ProceedExecute, ProceedCanExecute)); }
        }

        private ICommand _backCommand;

        public ICommand BackCommand
        {
            get { return _backCommand ?? (_backCommand = new RelayCommand<KeyEventArgs>(BackExecute)); }
        }

        #endregion

        private async void BackExecute(object o)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                BirthDate = new DateTime(1999, 1, 1);
                Person = null;
                FirstName = "";
                LastName = "";
                Email = "";
                return true;
            });
            if (result)
            {
                NavigationManager.Instance.Navigate(ModesEnum.Main);
            }
            LoaderManager.Instance.HideLoader();
            OnPropertyChanged();
        }

        private async void ProceedExecute(object o)
        {
            LoaderManager.Instance.ShowLoader();
            var result = await Task.Run(() =>
            {
                try
                {
                    if (DateTime.Today < BirthDate)
                    {
                        BirthDate = new DateTime(1999, 1, 1);
                        Person = null;
                        FirstName = "";
                        LastName = "";
                        Email = "";
                        throw new FutureBirthException();
                    }
                    else
                    {
                        if (((DateTime.Today.Subtract(BirthDate)).TotalDays / 365) > 135)
                        {
                            BirthDate = new DateTime(1999, 1, 1);
                            Person = null;
                            FirstName = "";
                            LastName = "";
                            Email = "";
                            throw new OldManException();
                        }
                        else
                        {
                            try
                            {
                                var addr = new System.Net.Mail.MailAddress(_email);
                                Person = new Person(FirstName, LastName, Email, BirthDate);
                                Console.WriteLine(FirstName);
                                Console.WriteLine(Email);
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show("Failed to validate email. " + e.Message);
                            }
                        }
                    }
                    if (Person != null)
                    {
                        if (Person.BirthDate.Month == DateTime.Today.Month && Person.BirthDate.Day == DateTime.Today.Day)
                            MessageBox.Show("Happy Birthday!!!");
                        FirstName = "";
                        LastName = "";
                        Email = "";
                        BirthDate = new DateTime(1999, 1, 1);
                        App.Current.Dispatcher.BeginInvoke((Action)delegate ()
                        {
                            StationManager.PesonList.Add(Person);
                            Person = null;
                            Serialization.SerializationManager.Serialize(StationManager.PesonList, Cnst.StorageFilePath);
                        });
                        return true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                return false;
            });
            if (result)
            {
                NavigationManager.Instance.Navigate(ModesEnum.Main);
            }
            LoaderManager.Instance.HideLoader();
            OnPropertyChanged();
        }

        private bool ProceedCanExecute(object obj)
        {
            return !String.IsNullOrEmpty(FirstName) &&
                   !String.IsNullOrEmpty(LastName) &&
                   !String.IsNullOrEmpty(Email);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        internal virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
