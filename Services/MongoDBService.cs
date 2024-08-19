using MongoDB.Models; // We will be using that MongoDBSettings class
// Dependencies to interact with the database
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson; // interact with the BSON data type

namespace MongoDB.Services;

public class MongoDBService {
    // creating a readonly private variable to represent the playlist collection
    // IMongoCollection is of type playlist

    private readonly IMongoCollection<Playlist> _playlistCollection;

    // constructor method
    // We will pass in the MongoDB settings. It will be handled by the Program.cs file. 
    // It's going to take our settings and pass them to the service which is going to be a Singleton class. Then
    // we will be able to use the variable throughout this particular class.
    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURL);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _playlistCollection = database.GetCollection<Playlist>(mongoDBSettings.Value.CollectionName);
    }
}