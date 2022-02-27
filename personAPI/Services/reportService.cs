using MongoDB.Driver;
using PersonAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonAPI.Services
{
    public class reportService
    {
        private readonly IMongoCollection<report> _report;
        public reportService(IPersonSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _report = database.GetCollection<report>(settings.PersonCollectionName[1]);
        }

        public List<report> Get()
        {
            List<report> report;
            report = _report.Find(p => true).ToList();
            return report;
        }
    }
}
