using NetApiWithDocker.Data.Converter.Implementation;
using NetApiWithDocker.Data.VO;
using NetApiWithDocker.Model;
using NetApiWithDocker.Repository.Implementations;
using System.Collections.Generic;

namespace NetApiWithDocker.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {
        private readonly IRepository<Person> _repository ;
        private readonly PersonConverter _converter;//Criando uma instância da classe contexto para ser injetada nesta classe

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }
        public PersonVO Create(PersonVO person)
        {
            var personEntity = _converter.Parse(person);
            personEntity = _repository.Create(personEntity);
            return _converter.Parse(personEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        
        }

        public List<PersonVO> FindAll()
        {
           
            return _converter.Parse(_repository.FindAll());
        }

   

        public PersonVO FindById(long id)
        {
            return _converter.Parse(_repository.FindById(id)); //método da classe context injetada
        }

        public PersonVO Update(PersonVO person)
        {

            var personEntity = _converter.Parse(person);
            personEntity = _repository.Update(personEntity);
            return _converter.Parse(personEntity);
        }

    }
}
