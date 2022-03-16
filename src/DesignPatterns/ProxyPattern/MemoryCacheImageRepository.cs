using System.Collections.Generic;
using System.Drawing;

namespace ProxyPattern
{
    // Proxy
    public class MemoryCacheImageRepository : IImageRepository
    {
        // Real Subject
        private readonly IImageRepository imageRepository;

        private IDictionary<int, Image> images;

        public MemoryCacheImageRepository(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;

            images = new Dictionary<int, Image>();
        }

        public Image Get(int personId)
        {
            if (images.TryGetValue(personId, out Image image))
            {
                return image;
            }
            else
            {
                image = imageRepository.Get(personId);

                if (image!=null)
                {
                    images.Add(personId, image);
                }

                return image;
            }

        }
    }


}
