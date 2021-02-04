using MongoDB.Driver;
using System.Threading.Tasks;
using IdeaSoft.Test.Api.Domain;
using System.Collections.Generic;

namespace IdeaSoft.Test.Api.Data
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMongoCollection<Person> _persondb;

        public PersonRepository(IPersonDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DataBaseName);
            _persondb = database.GetCollection<Person>(settings.PersonCollectionName);
        }
        public Person GetPersonById(string id)
        {
            return _persondb.Find(p => p.Id == id).FirstOrDefault();
        }

        public async Task<bool> SavePerson(Person person)
        {
            await _persondb.InsertOneAsync(person);
            return true;
        }

        public async Task<bool> UpdatePerson(string id, Person person)
        {
            await _persondb.ReplaceOneAsync(p => p.Id == id, person);
            return true;
        }

        public async Task RemovePerson(string id)
        {
            await _persondb.DeleteOneAsync(p => p.Id == id);
        }

        public IList<Person> GetPersonByFilter(string filter)
        {
            return _persondb.Find(p => 
                p.Name.ToLower().Contains(filter.ToLower()) ||
                p.LastName.ToLower().Contains(filter.ToLower())).ToList();
        }
    }
}
