//-----------------------------------------------------------------------
// <copyright file="MongoDBConnection.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Handles the MongoDB connection.</summary>
//-----------------------------------------------------------------------

namespace Storage
{
    using MongoDB.Driver;

    /// <summary>
    /// Handles the MongoDB database connection.
    /// </summary>
    public static class MongoDBConnection
    {
        /// <summary>
        /// The MongoDB client.
        /// </summary>
        private static MongoClient mongoClient;

        /// <summary>
        /// The MongoDB database.
        /// </summary>
        private static MongoDatabase mongoDatabase;

        /// <summary>
        /// The MongoDB server.
        /// </summary>
        private static MongoServer mongoServer;

        /// <summary>
        /// Gets the MongoDB database.
        /// </summary>
        public static MongoDatabase MongoDatabase
        {
            get
            {
                if (mongoDatabase == null)
                {
                    mongoDatabase = MongoServer.GetDatabase("HoldemBattle");
                }

                return mongoDatabase;
            }
        }

        /// <summary>
        /// Gets the MongoDB client.
        /// </summary>
        private static MongoClient MongoClient
        {
            get
            {
                if (mongoClient == null)
                {
                    mongoClient = new MongoClient("mongodb://localhost");
                }

                return mongoClient;
            }
        }

        /// <summary>
        /// Gets the MongoDB server.
        /// </summary>
        private static MongoServer MongoServer
        {
            get
            {
                if (mongoServer == null)
                {
                    mongoServer = MongoClient.GetServer();
                }

                return mongoServer;
            }
        }
    }
}
