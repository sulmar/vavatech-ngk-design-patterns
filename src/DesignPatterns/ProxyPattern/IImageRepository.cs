using System.Drawing;

namespace ProxyPattern
{
    // Subject    
    public interface IImageRepository
    {
        Image Get(int personId);
    }


}
