//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="TODO">
//     Not really copyright. 
// </copyright>
// <summary>Used for testing against the service.</summary>
//-----------------------------------------------------------------------

namespace TestApplication
{
    using Storage;

    /// <summary>
    /// The default program.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static void Main()
        {
            // Create user data.
            Registration.RegisterUser("Bret");
        }
    }
}
