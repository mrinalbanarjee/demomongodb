using MongoDB.Driver;
using MongoDB.Bson;
using System;

class Program
{
    static void Main(string[] args)
    {
        // Connection string and database name
        string connectionString = "";
        string dbName = "product";
        // Create a MongoDB client
        MongoClient client = new MongoClient(connectionString);
        // Get a reference to the database
        IMongoDatabase database = client.GetDatabase(dbName);
        // Access a collection
        IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("Aparalles");
        // Insert a document
        BsonDocument document = new BsonDocument
        {
            { "name", "John Miller White TShirt Large" },
            { "quality", "pure cotton"},
            { "size", "L" },
            { "Brand","John Miller" }
        };
        collection.InsertOne(document);
        // Query the collection
        var result = collection.Find(new BsonDocument("size", "L")).ToList();
        foreach (var doc in result)
        {
            Console.WriteLine(doc.ToJson());
        }
    }
}