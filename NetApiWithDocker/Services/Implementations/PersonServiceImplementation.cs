using NetApiWithDocker.Model;
using NetApiWithDocker.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetApiWithDocker.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private MySQLContext _context ;

        public PersonServiceImplementation( MySQLContext context)
        {
            _context = context;
        }
        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long Id)
        {
           
        }

        public List<Person> FindAll()
        {
           
            return _context.Persons.ToList();
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
            return 0;
        }
    }
}
