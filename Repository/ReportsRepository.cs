using System;
using APIAutomation.Interfaces;
using MongoDB.Driver;

namespace APIAutomation.Repository;

public class ReportsRepository : IReports
{
	private IMongoDbContext _dbContext;

    private MongoClient client;
    private IMongoDatabase database;

    public ReportsRepository(IMongoDbContext dbContext)
    {
        _dbContext = dbContext;

        client = dbContext.GetMongoClient();
        database = dbContext.GetMongoDatabase();
    }

    public int GetHours()
    {
        return 1;
    }
}

