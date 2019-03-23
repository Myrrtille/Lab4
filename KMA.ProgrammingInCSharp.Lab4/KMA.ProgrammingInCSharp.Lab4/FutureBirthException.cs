
using System;
using System.Windows;

namespace KMA.ProgrammingInCSharp.Lab4
{
    class FutureBirthException : Exception
    {
        public FutureBirthException()
        {
            MessageBox.Show("Not born yet.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public FutureBirthException(string message)
            : base(message)
        {
            Console.WriteLine(message);
        }

        public FutureBirthException(string message, Exception inner)
            : base(message, inner)
        {
            Console.WriteLine(message);
        }
    }
}
