namespace System.Diagnostics
{
    public static class StopwatchExtensions
    {
        public static long GetElapsedMicroseconds( this Stopwatch iStopwatch )
        {
            return iStopwatch.GetElapsedNanoseconds() / 10;
        }

        public static long GetElapsedNanoseconds( this Stopwatch iStopwatch )
        {
            return iStopwatch.ElapsedTicks / 100; //Stopwatch ticks are 100 per nanosecond.
        }
    }
}