using NetApiWithDocker.Model;
using System.Collections.Generic;

namespace NetApiWithDocker.Repository.Implementations
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long Id);
        bool Exists(long id);
    }
}
