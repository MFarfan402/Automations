using System;
using System.Collections;
using APIAutomation.Interfaces;
using MongoDB.Driver;

namespace APIAutomation.Config;

public class MongoDbContext : IMongoDbContext
{
    private IConfiguration _configuration;
    private string _connectionString, _databaseName;
    private MongoClient _client;
    private IMongoDatabase _database;

    public MongoDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        var pair = configuration.AsEnumerable();

        _connectionString = pair.FirstOrDefault(key => key.Key.Equals("CONN_STRING_USER")).Value;
        _databaseName = pair.FirstOrDefault(key => key.Key.Equals("DATABASE")).Value;

        //Console.WriteLine("CONN_STRING_USER: " + _connectionString);
        //Console.WriteLine("DATABASE: " + _databaseName);

        Console.WriteLine("GetEnvironmentVariables: ");
        foreach (DictionaryEntry de in Environment.GetEnvironmentVariables())
        {
            Console.WriteLine("  {0} = {1}", de.Key, de.Value);
        }

    }

    public MongoClient GetMongoClient()
    {
        _client = new MongoClient(_connectionString);
        return _client;
    }

    public IMongoDatabase GetMongoDatabase()
    {
        _database = _client.GetDatabase(_databaseName);
        return _database;
    }
}

