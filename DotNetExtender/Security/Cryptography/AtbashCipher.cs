using System.Collections.ObjectModel;

namespace System.System.Security.Cryptography
{
    public static class AtbashCipher
    {
        private static readonly ReadOnlyCollection<char> Table;

        static AtbashCipher()
        {
            var table = new char[char.MaxValue];

            for( var c = char.MinValue; c < char.MaxValue; ++c )
                table[c] = c;

            for( var c = 'A'; c <= 'Z'; ++c )
                table[Convert.ToInt32( c )] = Convert.ToChar( 'Z' + 'A' - c );

            for( var c = 'a'; c <= 'z'; ++c )
                table[Convert.ToInt32( c )] = Convert.ToChar( 'z' + 'a' - c );
        }

        public static string Transform( string source )
        {
            try
            {
                var characters = source.ToCharArray();
                var length = characters.Length;

                for( var i = 0; i < length; ++i )
                    characters[i] = Table[Convert.ToInt32( characters[i] )];

                return new String( characters );
            }
            catch
            {
                return source;
            }
        }
    }
}