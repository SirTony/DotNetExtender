namespace System
{
    /// <summary>
    /// Provides extension methods to the System.DateTime class.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts a System.DateTime object to a Unix timestamp.
        /// </summary>
        /// <param name="When">The DateTime object to convert to a Unix timestamp.</param>
        /// <returns>The time, in seconds, since the epoch.</returns>
        public static double ToUnixTime( this DateTime When )
        {
            DateTime Origin = new DateTime( 1970, 1, 1, 0, 0, 0, 0 );
            TimeSpan Difference = When - Origin;

            return Difference.TotalSeconds;
        }
    }
}