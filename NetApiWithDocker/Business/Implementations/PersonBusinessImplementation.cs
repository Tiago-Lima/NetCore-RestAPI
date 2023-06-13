using NetApiWithDocker.Model;
using NetApiWithDocker.Model.Context;
using NetApiWithDocker.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NetApiWithDocker.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository ; //Criando uma instância da classe contexto para ser injetada nesta classe

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
        }
        public Person Create(Person person)
        {
         
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        
        }

        public List<Person> FindAll()
        {
           
            return _repository.FindAll();
        }

   

        public Person FindById(long id)
        {
            return _repository.FindById(id); //método da classe context injetada
        }

        public Person Update(Person person)
        {
         
            return _repository.Update(person);
        }

    }
}
