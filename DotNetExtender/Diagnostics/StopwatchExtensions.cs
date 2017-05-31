namespace System.Diagnostics
{
    /// <summary>
    ///     Provides a set of extensions for Stopwatches
    /// </summary>
    public static class StopwatchExtensions
    {
        /// <summary>
        ///     Gets the number of elapsed ticks as microseconds.
        /// </summary>
        /// <param name="stopwatch">The stopwatch object</param>
        /// <returns>The stopwatch's elapsed ticks converted to microseconds</returns>
        public static double GetElapsedMicroseconds( this Stopwatch stopwatch ) => stopwatch.ElapsedTicks /
                                                                                   (double)Stopwatch.Frequency *
                                                                                   1e6;

        /// <summary>
        ///     Gets the number of elapsed ticks as nanoseconds.
        /// </summary>
        /// <param name="stopwatch">The stopwatch object</param>
        /// <returns>The stopwatch's elapsed ticks converted to nanoseconds</returns>
        public static double GetElapsedNanoseconds( this Stopwatch stopwatch ) => stopwatch.ElapsedTicks /
                                                                                  (double)Stopwatch.Frequency *
                                                                                  1e9;
    }
}
