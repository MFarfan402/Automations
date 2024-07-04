using System;
using MongoDB.Driver;

namespace APIAutomation.Interfaces
{
	public interface IMongoDbContext
	{
		MongoClient GetMongoClient();
        IMongoDatabase GetMongoDatabase();
	}
}

