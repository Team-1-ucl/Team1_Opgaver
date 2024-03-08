namespace MyMusic.Services
{
    public class Service : IService
    {
        private int _count = 0;

        public void Increment()
        {
            _count++;    
        }

        public int GetCount()
        {
            return _count;
        }

       
    }
}
