using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace IdeaSoft.Test.Api.Domain
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; private set; }

        public string Name { get; private set; }

        public string LastName { get; private set; }

        public string PhoneNumber { get; private set; }

        public Person(string name, string lastName, string phoneNumber)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }

        public void UpdatePerson(string name, string lastName, string phoneNumber)
        {
            Name = name;
            LastName = lastName;
            PhoneNumber = phoneNumber;
        }
        
    }
}
