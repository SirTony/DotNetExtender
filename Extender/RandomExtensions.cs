namespace System
{
    /// <summary>
    /// Provides a set of extension methods for the System.Random class.
    /// </summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// Generates a random string of the specified length using alphanumeric characters.
        /// </summary>
        /// <param name="rng">The random number generator to use.</param>
        /// <param name="length">The length of the randomized string.</param>
        /// <returns>A string of the specified length with random characters.</returns>
        public static string GenerateString( this Random rng, int length )
        {
            const string AlphaNumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            return rng.GenerateString( length, AlphaNumeric.ToCharArray() );
        }

        /// <summary>
        /// Generates a random string of the specified length using the specified characters.
        /// </summary>
        /// <param name="rng">The random number generator to use.</param>
        /// <param name="length">The length of the randomized string.</param>
        /// <param name="characters">The array of characters the random number generator is to pick from.</param>
        /// <returns>A string of the specified length with random characters.</returns>
        public static string GenerateString( this Random rng, int length, char[] characters )
        {
            var result = String.Empty;

            for( var i = 1; i <= length; ++i )
            {
                int position = rng.Next( 0, characters.Length );
                result += characters[position];
            }

            return result;
        }
    }
}