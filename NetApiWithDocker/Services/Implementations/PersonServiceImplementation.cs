using NetApiWithDocker.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetApiWithDocker.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long Id)
        {
           
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i=0; i<8; i++)
            {
                Person person = MockPersons(i);
                persons.Add(person);
            }
           
            return persons;
        }

   

        public Person FindById(long id)
        {
            return new Person
            { 
                Id = IncrementAndGet(),
                FirstName = "Joaquim",
                LastName = "Ferreira",
                Address = "Rua Theodoro de Freitas, 87 - SãoPaulo/SP",
                Gender = "Male"


            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person MockPersons(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Person Name" + i,
                LastName = "Person Last Name" + i,
                Address = "Some Address" + i,
                Gender = "Male"


            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
