using System;
using System.Windows;

namespace KMA.ProgrammingInCSharp.Lab4
{
    class OldManException : Exception
    {
        public OldManException()
        {
            MessageBox.Show("Too old, 135 - max age.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public OldManException(string message)
            : base(message)
        {
            Console.WriteLine(message);
        }

        public OldManException(string message, Exception inner)
            : base(message, inner)
        {
            Console.WriteLine(message);
        }
    }
}
