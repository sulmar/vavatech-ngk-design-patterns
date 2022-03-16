using System.Collections.Generic;

namespace ProxyPattern
{
    public class DbPersonRepository
    {
        private readonly IImageRepository _imageRepository;

        public DbPersonRepository(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public Person Get(int id)
        {
            var people = new Dictionary<int, Person>()
            {
                { 1, new Person(1, "John") },
                { 2, new Person(2, "Ann") },
                { 3, new Person(3, "Bob") },
            };

            if (people.TryGetValue(id, out Person person))
            {
                person.Image = _imageRepository.Get(id);

                return person;
            }
            else
                return null;
        }
    }


}
