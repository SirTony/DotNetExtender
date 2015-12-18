namespace System.Net.Sockets
{
    /// <summary>
    /// Provides a set of extension methods for the System.Net.Sockets.Socket class.
    /// </summary>
    public static class SocketExtensions
    {
        /// <summary>
        /// Polls the System.Net.Sockets.Socket object to test if the connection is still alive.
        /// </summary>
        /// <param name="socket">The Socket object to poll.</param>
        /// <returns>True if the connection is alive, false otherwise.</returns>
        public static bool IsConnected( this Socket socket )
        {
            try
            {
                return !( socket.Poll( 1, SelectMode.SelectRead ) && socket.Available == 0 );
            }
            catch
            {
                return false;
            }
        }
    }
}