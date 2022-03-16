namespace MementoPattern.Problem
{
    public interface IConfigurationRepository
    {
        byte[] Get();
        void Add(byte[] content);
    }


}
