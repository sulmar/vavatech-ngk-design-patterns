using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;
using System.Xml.Serialization;
using Force.DeepCloner;

namespace PrototypePattern
{
    public class Phone : ICloneable
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public Batery Batery { get; set; }

        public object Clone()
        {
            // return this.BinaryDeepClone();

            // return this.DeepCloneXml();

            // return this.DeepCloneJson();

            // Install-Package DeepCloner
            // https://github.com/force-net/DeepCloner
            return this.DeepClone();
        }
    }

    

    public static class Extensions
    {
        // Serializacja binarna - wymaga atrybutu [Serializable] na klasie
        public static T BinaryDeepClone<T>(this T self)
        {
            using (Stream stream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, self);

                stream.Seek(0, SeekOrigin.Begin);

                object copy = binaryFormatter.Deserialize(stream);
                return (T)copy;
            }
        }

        // Serializacja Xml
        public static T DeepCloneXml<T>(this T self)
        {
            using (Stream stream = new MemoryStream())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(stream, self);

                stream.Seek(0, SeekOrigin.Begin);

                object copy = serializer.Deserialize(stream);
                return (T)copy;
            }
        }

        // Serializacja json
        public static T DeepCloneJson<T>(this T self)
        {
            string json = JsonSerializer.Serialize<T>(self);

            object copy = JsonSerializer.Deserialize<T>(json);
            return (T)copy;
        }

       

       
    }
}
