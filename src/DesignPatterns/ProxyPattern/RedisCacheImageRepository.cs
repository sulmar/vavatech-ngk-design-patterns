using StackExchange.Redis;
using System;
using System.Drawing;
using System.IO;

namespace ProxyPattern
{
    // Proxy
    public class RedisCacheImageRepository : IImageRepository
    {
        // Real Subject
        private readonly IImageRepository imageRepository;


        // dotnet add package StackExchange.Redis
        private readonly IDatabase db;

        public RedisCacheImageRepository(IConnectionMultiplexer connection, IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;

            this.db = connection.GetDatabase();
        }

        public Image Get(int personId)
        {
            string key = $"image-{personId}";

            Image image;

            if (db.KeyExists(key))
            {
                // GET key
                using var stream = new MemoryStream(db.StringGet(key));
                image = Image.FromStream(stream);
            }
            else
            {
                image = imageRepository.Get(personId);

                if (image!=null)
                {
                    using MemoryStream stream = new MemoryStream();

                    image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);

                    // SET key value
                    db.StringSet(key, RedisValue.CreateFrom(stream));
                }
            }

            return image;


        }
    }


}
