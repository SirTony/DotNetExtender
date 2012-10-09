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
        /// <param name="iRandom">The random number generator to use.</param>
        /// <param name="Length">The length of the randomized string.</param>
        /// <returns>A string of the specified length with random characters.</returns>
        public static string GenerateString( this Random iRandom, int Length )
        {
            string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            return iRandom.GenerateString( Length, Chars.ToCharArray() );
        }

        /// <summary>
        /// Generates a random string of the specified length using the specified characters.
        /// </summary>
        /// <param name="iRandom">The random number generator to use.</param>
        /// <param name="Length">The length of the randomized string.</param>
        /// <param name="Chars">The array of characters the random number generator is to pick from.</param>
        /// <returns>A string of the specified length with random characters.</returns>
        public static string GenerateString( this Random iRandom, int Length, char[] Chars )
        {
            string TempString = "";

            for( int i = 1; i <= Length; ++i )
            {
                int CharPos = iRandom.Next( 0, Chars.Length - 1 );
                TempString += Chars[CharPos];
            }

            return TempString;
        }
    }
}