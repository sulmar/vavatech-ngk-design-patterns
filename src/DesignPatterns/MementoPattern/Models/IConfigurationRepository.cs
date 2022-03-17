using System;

namespace MementoPattern
{
    // Abstract Repository
    public interface IConfigurationRepository
    {
        byte[] Get();
        void Add(byte[] content);
    }

}
