// This model represents the settings for connecting to MongoDB

// giving it a namespace - so that we can be consistent across the entire project
namespace MongoDB.Models;

// providing a class
public class MongoDBSettings {
    // defining variables for holding our MongoDB connection information
    public string ConnectionURL {get; set; } = null!; // It can be null
    public string DatabaseName {get; set; } = null!; // It can be null
    public string CollectionName {get; set; } = null!; // It can be null
    
    // defining the ConnectionURL, DatabaseName, and CollectionName in appsettings.json file for the project
    // added the MongoDB json object
}
