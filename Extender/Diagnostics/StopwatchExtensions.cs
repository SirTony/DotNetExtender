namespace System.Diagnostics
{
    public static class StopwatchExtensions
    {
        public static double GetElapsedMicroseconds( this Stopwatch iStopwatch )
        {
            return ( iStopwatch.ElapsedTicks / Stopwatch.Frequency ) * 1e6;
        }

        public static double GetElapsedNanoseconds( this Stopwatch iStopwatch )
        {
            return ( iStopwatch.ElapsedTicks / Stopwatch.Frequency ) * 1e9;
        }
    }
}