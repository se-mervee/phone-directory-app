using MongoDB.Driver;
using PersonAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace PersonAPI.Services
{
    public class personService
    {
        private readonly IMongoCollection<person> _person;
        public personService(IPersonSettings settings)
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("riseTechnology");

            _person = database.GetCollection<person>("person");
        }

        public List<person> Get()
        {
            List<person> person;
            person = _person.Find(p => true).ToList();
            return person;
        }

        public person Get(string id) =>
            _person.Find<person>(p => p.id == id).FirstOrDefault();

        public void InsertPerson(person person)
        {
            _person.InsertOne(person);
        }

        public void Update(string id, person updatedPerson)
        {
            FilterDefinition<person> filter = Builders<person>.Filter.Eq("id", id);
            UpdateDefinition<person> update = Builders<person>.Update.Set("firstName", updatedPerson.firstName).
                Set("lastName", updatedPerson.lastName).
                Set("company", updatedPerson.company).
                Set("contactInfo.phone", updatedPerson.contactInfo.phone).
                Set("contactInfo.email", updatedPerson.contactInfo.email).
                Set("contactInfo.location", updatedPerson.contactInfo.location).
                Set("contactInfo.infoContent", updatedPerson.contactInfo.infoContent);

            var result = _person.FindOneAndUpdate(filter, update);
        }

        public void Delete(string id)
        {
            FilterDefinition<person> deletedPerson = Builders<person>.Filter.Eq("id", id);

            if (deletedPerson != null)
            {
                _person.DeleteOneAsync(deletedPerson);
            }
        }
    }
}
