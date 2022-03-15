namespace AdapterPattern
{
    public class IPhoneAdapter : IPhone, ITarget
    {
        byte ITarget.GetBateryLevel()
        {            
            return (byte) (base.GetBateryLevel() * 100);
        }
    }
}
