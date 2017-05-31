namespace System.System.Security.Cryptography
{
    public static class Rot13
    {
        public static string Transform( string source )
        {
            var characters = source.ToCharArray();
            var length = characters.Length;

            for( var i = 0; i < length; ++i )
            {
                var ascii = Convert.ToInt16( characters[ i ] );

                if( ascii >= 'a' && ascii <= 'z' )
                {
                    if( ascii > 'm' )
                        ascii -= 13;
                    else
                        ascii += 13;
                }
                else if( ascii >= 'A' && ascii <= 'Z' )
                {
                    if( ascii > 'M' )
                        ascii -= 13;
                    else
                        ascii += 13;
                }

                characters[i] = Convert.ToChar( ascii );
            }

            return new String( characters );
        }
    }
}