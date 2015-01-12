namespace System.System.Security.Cryptography
{
    public static class AtbashCipher
    {
        private static char[] Table;

        static AtbashCipher()
        {
            AtbashCipher.Table = new char[ char.MaxValue ];

            for( int i = 0; i < char.MaxValue; ++i )
                AtbashCipher.Table[ i ] = Convert.ToChar( i );

            for( char c = 'A'; c <= 'Z'; ++c )
                AtbashCipher.Table[ Convert.ToInt32( c ) ] = Convert.ToChar( 'Z' + 'A' - c );

            for( char c = 'a'; c <= 'z'; ++c )
                AtbashCipher.Table[ Convert.ToInt32( c ) ] = Convert.ToChar( 'z' + 'a' - c );
        }

        public static string Transform( string Input )
        {
            try
            {
                char[] Chars = Input.ToCharArray();
                int Length = Chars.Length;

                for( int i = 0; i < Length; ++i )
                    Chars[ i ] = AtbashCipher.Table[ Convert.ToInt32( Chars[ i ] ) ];

                return new string( Chars );
            }
            catch
            {
                return Input;
            }
        }
    }
}