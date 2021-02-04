using System.Collections.Generic;
using System.Threading.Tasks;

namespace IdeaSoft.Test.Api.Domain
{
    public interface IPersonService
    {
        IList<Person> GetPersonByFilter(string filter);
        Person GetPersonById(string id);
        Task<bool> SavePerson(Person person);
        Task<bool> UpdatePerson(string id, Person person);
        Task RemovePerson(string id);
    }
}
