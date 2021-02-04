using IdeaSoft.Test.Api.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdeaSoft.Test.Api.Domain
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _repository;

        public PersonService(IPersonRepository repository)
        {
            _repository = repository;
        }
        public Person GetPersonById(string id)
        {
            return _repository.GetPersonById(id);
        }

        public async Task<bool> SavePerson(Person person)
        {
            return await _repository.SavePerson(person);
        }

        public async Task<bool> UpdatePerson(string id, Person person)
        {
            return await _repository.UpdatePerson(id, person);
        }

        public async Task RemovePerson(string id)
        {
            await _repository.RemovePerson(id);
        }

        public IList<Person> GetPersonByFilter(string filter)
        {
            return _repository.GetPersonByFilter(!string.IsNullOrEmpty(filter) ? filter : string.Empty);
        }
    }
}
