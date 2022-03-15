namespace AdapterPattern
{
    public class AndroidAdapter : Android, ITarget
    {
        public byte GetBateryLevel()
        {
            return base.GetLevel();
        }
    }
}
