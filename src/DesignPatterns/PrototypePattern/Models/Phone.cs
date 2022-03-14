using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PrototypePattern
{
    [Serializable]
    public class Phone : ICloneable
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public Batery Batery { get; set; }

        public object Clone()
        {
            return this.DeepClone();
        }

        
    }

    public static class Extensions
    {
        public static T DeepClone<T>(this T self)
        {
            using(Stream stream = new MemoryStream())
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, self);

                stream.Seek(0, SeekOrigin.Begin);

                object copy = binaryFormatter.Deserialize(stream);
                return (T)copy;
            }
        }
    }
}
