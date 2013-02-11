namespace System.IO
{
    public static class StreamExtensions
    {
        private const int DEFAULT_BUFFER_SIZE = 10240;

        public static long BlockCopy( this Stream iStream, Stream DestinationStream )
        {
            return iStream.BlockCopy( DestinationStream, iStream.Position, iStream.Length - iStream.Position, DestinationStream.Position, DEFAULT_BUFFER_SIZE, true, true );
        }

        public static long BlockCopy( this Stream iStream, Stream DestinationStream, long Length )
        {
            return iStream.BlockCopy( DestinationStream, iStream.Position, Length, DestinationStream.Position, DEFAULT_BUFFER_SIZE, true, true );
        }

        public static long BlockCopy( this Stream iStream, Stream DestinationStream, long StartPosition, long Length )
        {
            return iStream.BlockCopy( DestinationStream, StartPosition, Length, DestinationStream.Position, DEFAULT_BUFFER_SIZE, true, true );
        }

        public static long BlockCopy( this Stream iStream, Stream DestinationStream, long StartPosition, long Length, int BufferSize )
        {
            return iStream.BlockCopy( DestinationStream, StartPosition, Length, DestinationStream.Position, BufferSize, true, true );
        }

        public static long BlockCopy( this Stream iStream, Stream DestinationStream, long StartPosition, long Length, int BufferSize, bool PreserveInternalPointer )
        {
            return iStream.BlockCopy( DestinationStream, StartPosition, Length, DestinationStream.Position, BufferSize, PreserveInternalPointer );
        }

        public static long BlockCopy( this Stream iStream, Stream DestinationStream, long StartPosition, long Length, int BufferSize, bool PreserveInternalPointer, bool AutoFlush )
        {
            return iStream.BlockCopy( DestinationStream, StartPosition, Length, DestinationStream.Position, BufferSize, PreserveInternalPointer, AutoFlush );
        }

        public static long BlockCopy( this Stream iStream, Stream DestinationStream, long StartPosition, long DestinationStartIndex )
        {
            return iStream.BlockCopy( DestinationStream, StartPosition, iStream.Length - iStream.Position, DestinationStartIndex, DEFAULT_BUFFER_SIZE, true, true );
        }

        public static long BlockCopy( this Stream iStream, Stream DestinationStream, long StartPosition, long Length, long DestinationStartIndex )
        {
            return iStream.BlockCopy( DestinationStream, StartPosition, Length, DestinationStartIndex, DEFAULT_BUFFER_SIZE, true, true );
        }

        public static long BlockCopy( this Stream iStream, Stream DestinationStream, long StartPosition, long Length, long DestinationStartIndex, int BufferSize )
        {
            return iStream.BlockCopy( DestinationStream, StartPosition, Length, DestinationStartIndex, BufferSize, true, true );
        }

        public static long BlockCopy( this Stream iStream, Stream DestinationStream, long StartPosition, long Length, long DestinationStartIndex, int BufferSize, bool PreserveInternalPointer )
        {
            return iStream.BlockCopy( DestinationStream, StartPosition, Length, DestinationStartIndex, BufferSize, PreserveInternalPointer, true );
        }

        public static long BlockCopy( this Stream iStream, Stream DestinationStream, long StartPosition, long Length, long DestinationStartIndex, int BufferSize, bool PreserveInternalPointer, bool AutoFlush )
        {
            if( Length < 1 )
                throw new ArgumentOutOfRangeException( "Length", "Length must be equal to or greater than 1 (one)." );

            if( StartPosition < 0 )
                throw new ArgumentOutOfRangeException( "StartPosition", "Start position must be greater than or equal to 0 (zero)." );

            if( DestinationStartIndex < 0 )
                throw new ArgumentOutOfRangeException( "DestinationStartIndex", "Destination stream start position must be greater than or equal to 0 (zero)." );

            if( BufferSize < 1 )
                throw new ArgumentOutOfRangeException( "BufferSize", "Buffer size must be greater than or equal to 1 (one)." );

            long TotalBytesRead = 0;
            long CurrentSourcePosition = iStream.Position;
            long CurrentDestPosition = DestinationStream.Position;

            iStream.Position = StartPosition;
            DestinationStream.Position = DestinationStartIndex;

            while( Length > 0 )
            {
                int AbsoluteBufferSize = (int)Math.Min( (long)BufferSize, Length ); //If the bytes left to read is less than the buffer size, we adjust the buffer accordingly.

                byte[] pBuffer = new byte[ AbsoluteBufferSize ];
                int BytesReadThisPass = iStream.Read( pBuffer, 0, AbsoluteBufferSize );
                DestinationStream.Write( pBuffer, 0, AbsoluteBufferSize );

                if( AutoFlush )
                    DestinationStream.Flush();

                Length -= BytesReadThisPass;
                TotalBytesRead += BytesReadThisPass;
            }

            if( PreserveInternalPointer )
            {
                iStream.Position = CurrentSourcePosition;
                DestinationStream.Position = CurrentDestPosition;
            }

            return TotalBytesRead;
        }
    }
}