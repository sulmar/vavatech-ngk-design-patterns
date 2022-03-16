using System.Drawing;

namespace ProxyPattern
{
    // Real Subject
    public class FileImageRepository : IImageRepository
    {
        public Image Get(int personId)
        {
            return Image.FromFile($@"Images\Image{personId}.jpg");
        }
    }


}
