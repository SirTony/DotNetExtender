namespace System.Net.Sockets
{
    public static class SocketExtensions
    {
        public static bool IsConnected( this Socket iSocket )
        {
            try
            {
                return !( iSocket.Poll( 1, SelectMode.SelectRead ) && iSocket.Available == 0 );
            }
            catch
            {
                return false;
            }
        }
    }
}