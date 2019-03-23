using System;
using KMA.ProgrammingInCSharp.Lab4.Managers;
using KMA.ProgrammingInCSharp.Lab4.Tools;

namespace KMA.ProgrammingInCSharp.Lab4.Models
{
    [Serializable]
    class Person
    {
        #region Fields

        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthDate;
        private string _sunSign;
        private string _chineseSign;

        private readonly string[] _westSignsArr =
        {
            "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio",
            "Sagittatius", "Capricorn"
        };

        private readonly string[] _chineseSignArr =
        {
            "Monkey", "Rooster", "Dog", "Pig", "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Sheep"
        };

        #endregion

        #region Constructors
        public Person(string firstName, string lastName, string email, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            try
            {
                Email = email;
            }
            catch
            {
                Email = "null@null.null";
            }
            BirthDate = birthDate;
        }

        public Person(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            try
            {
                Email = email;
            }
            catch
            {
                Email = "null@null.null";
            }
        }

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }
        #endregion

        #region Properties

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                Serialization.SerializationManager.Serialize(StationManager.PesonList,Cnst.StorageFilePath);
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                Serialization.SerializationManager.Serialize(StationManager.PesonList, Cnst.StorageFilePath);
            }
        }
        public string Email
        {
            get { return _email; }
            set
            {
                var addr = new System.Net.Mail.MailAddress(value);
                _email = addr.ToString();
                Serialization.SerializationManager.Serialize(StationManager.PesonList, Cnst.StorageFilePath);
            }
        }
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                DateTime last = new DateTime(1999,1,1);
                if (_birthDate != null)
                    last = _birthDate;
                if (DateTime.Today >= value && ((DateTime.Today.Subtract(value)).TotalDays / 365) < 135)
                {
                    _birthDate = value;
                    _sunSign = GetSunSign();
                    _chineseSign = GetChineseSign();
                    Serialization.SerializationManager.Serialize(StationManager.PesonList, Cnst.StorageFilePath);
                }
                else
                    _birthDate = last;
            }
        }

        public bool IsAdult
        {
            get { return ((DateTime.Today.Subtract(_birthDate)).TotalDays / 365) > 18; }
            private set { }
        }

        public string SunSign
        {
            get { return _sunSign; }
            private set
            {
                _sunSign = value;
                Serialization.SerializationManager.Serialize(StationManager.PesonList, Cnst.StorageFilePath);
            }
        }

        public string ChineseSign
        {
            get { return _chineseSign; }
            private set
            {
                _chineseSign = value;
                Serialization.SerializationManager.Serialize(StationManager.PesonList, Cnst.StorageFilePath);
            }
        }

        public bool IsBirthday
        {
            get { return (_birthDate.Month == DateTime.Today.Month && _birthDate.Day == DateTime.Today.Day); }
            private set { }
        }
        #endregion

        private string GetSunSign()
        {
            switch (_birthDate.Month)
            {
                case 1:
                    return _birthDate.Day <= 20 ? _westSignsArr[11] : _westSignsArr[0];
                case 2:
                    return _birthDate.Day <= 18 ? _westSignsArr[0] : _westSignsArr[1];
                case 3:
                    return _birthDate.Day <= 20 ? _westSignsArr[1] : _westSignsArr[2];
                case 4:
                    return _birthDate.Day <= 20 ? _westSignsArr[2] : _westSignsArr[3];
                case 5:
                    return _birthDate.Day <= 20 ? _westSignsArr[3] : _westSignsArr[4];
                case 6:
                    return _birthDate.Day <= 21 ? _westSignsArr[4] : _westSignsArr[5];
                case 7:
                    return _birthDate.Day <= 22 ? _westSignsArr[5] : _westSignsArr[6];
                case 8:
                    return _birthDate.Day <= 22 ? _westSignsArr[6] : _westSignsArr[7];
                case 9:
                    return _birthDate.Day <= 22 ? _westSignsArr[7] : _westSignsArr[8];
                case 10:
                    return _birthDate.Day <= 23 ? _westSignsArr[8] : _westSignsArr[9];
                case 11:
                    return _birthDate.Day <= 22 ? _westSignsArr[9] : _westSignsArr[10];
                case 12:
                    return _birthDate.Day <= 21 ? _westSignsArr[10] : _westSignsArr[11];
                default:
                    return "";
            }
        }

        private string GetChineseSign()
        {
            try
            {
                return _chineseSignArr[_birthDate.Year % 12];
            }
            catch (Exception)
            {
                return "";
            }
        }
    }
}
