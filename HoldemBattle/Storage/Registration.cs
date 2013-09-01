//-----------------------------------------------------------------------
// <copyright file="Registration.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Handles registration by players.</summary>
//-----------------------------------------------------------------------

namespace Storage
{
    using System;

    using MongoDB.Driver;
    using MongoDB.Driver.Builders;
    using Storage.Types;

    /// <summary>
    /// Handles registration by players.
    /// </summary>
    public static class Registration
    {
        /// <summary>
        /// The <see cref="User"/> collection.
        /// </summary>
        private static MongoCollection<User> userCollection;

        /// <summary>
        /// Gets the <see cref="User"/> collection.
        /// </summary>
        private static MongoCollection<User> UserCollection
        {
            get
            {
                if (userCollection == null)
                {
                    userCollection = MongoDBConnection.MongoDatabase.GetCollection<User>("HoldemBattle");
                }

                return userCollection;
            }
        }

        /// <summary>
        /// Determines whether the provided key is related to a user in the database.
        /// </summary>
        /// <param name="key">The key to look up.</param>
        /// <returns>true if a related user exists, otherwise false.</returns>
        public static bool IsRegistered(string key)
        {
            IMongoQuery query = Query<User>.EQ(x => x.Key, key);
            return UserCollection.FindOne(query) != null;
        }

        /// <summary>
        /// Determines whether the provided name already exists in the <see cref="User"/>s database.
        /// </summary>
        /// <param name="name">The name to check in the database.</param>
        /// <returns>true if the name is already registered, otherwise false.</returns>
        public static bool NameExists(string name)
        {
            IMongoQuery query = Query<User>.EQ(x => x.Name, name);
            return UserCollection.FindOne(query) != null;
        }

        /// <summary>
        /// Registers the user in the database and returns the registration key.
        /// </summary>
        /// <param name="name">The name of the user to register.</param>
        /// <returns>A key to use to communicate with the service.</returns>
        public static string RegisterUser(string name)
        {
            var user = new User { Key = Guid.NewGuid().ToString(), Name = name };

            // Check to see whether it's already registered.
            if (!NameExists(name))
            {
                UserCollection.Insert(user);
                return user.Key;
            }
            else
            {
                throw new OperationCanceledException("The user already exists in the database.");
            }
        }
    }
}
