using System;
using System.IO;

namespace KMA.ProgrammingInCSharp.Lab4.Tools
{
    static class Cnst
    {
        private static readonly string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        internal static readonly string ClientFolderPath = Path.Combine(AppDataPath, "KMA.SHARP.LAB4.PERSON");
        internal static readonly string StorageFilePath = Path.Combine(ClientFolderPath, "Storage.per");
    }
}
