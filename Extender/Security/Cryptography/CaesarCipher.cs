namespace System.Security.Cryptography
{
    public static class CaesarCipher
    {
        public static string Encode( string source, int shift )
        {
            var chars = source.ToCharArray();
            var len = chars.Length;

            for( var i = 0; i < len; ++i )
            {
                var c = (char)( chars[i] + shift );

                if( c > 'z' )
                    c = (char)( c - 26 );
                else if( c < 'a' )
                    c = (char)( c + 26 );

                chars[i] = c;
            }

            return new String( chars );
        }

        public static string Decode( string source, int shift )
            => Encode( source, shift < 0 ? shift : -shift );
    }
}