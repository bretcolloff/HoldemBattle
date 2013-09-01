//-----------------------------------------------------------------------
// <copyright file="User.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Represents user registration data.</summary>
//-----------------------------------------------------------------------

namespace Storage.Types
{
    using MongoDB.Bson;

    /// <summary>
    /// The user registration data.
    /// </summary>
    public sealed class User
    {
        /// <summary>
        /// Gets or sets the user key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the friendly name of the user.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Id for MongoDB.
        /// </summary>
        public ObjectId Id { get; set; }
    }
}
