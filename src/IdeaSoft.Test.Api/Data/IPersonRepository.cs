using IdeaSoft.Test.Api.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdeaSoft.Test.Api.Data
{
    public interface IPersonRepository
    {
        IList<Person> GetPersonByFilter(string filter);
        Person GetPersonById(string id);
        Task<bool> SavePerson(Person person);
        Task<bool> UpdatePerson(string id, Person person);
        Task RemovePerson(string id);
    }
}
