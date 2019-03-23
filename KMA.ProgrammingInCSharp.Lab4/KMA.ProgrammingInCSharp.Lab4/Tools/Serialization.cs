using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KMA.ProgrammingInCSharp.Lab4.Tools
{
    class Serialization
    {

        internal static class SerializationManager
        {
            internal static void Serialize<TObject>(TObject obj, string filePath)
            {
                try
                {
                    try
                    {
                        FileInfo file = new FileInfo(filePath);
                        if (!file.Directory.Exists)
                        {
                            file.Directory.Create();
                        }
                        if (!file.Exists)
                        {
                            file.Create().Close();
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    var formatter = new BinaryFormatter();
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        formatter.Serialize(stream, obj);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to serialize data to file {filePath}", ex);
                    throw;
                }
            }

            internal static TObject Deserialize<TObject>(string filePath) where TObject : class
            {
                try
                {
                    var formatter = new BinaryFormatter();
                    using (var stream = new FileStream(filePath, FileMode.Open))
                    {
                        return (TObject)formatter.Deserialize(stream);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to Deserialize Data From File {filePath}", ex);
                    return null;
                }
            }
        }
    }
}
