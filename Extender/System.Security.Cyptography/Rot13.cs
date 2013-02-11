namespace System.System.Security.Cyptography
{
    public static class Rot13
    {
        public static string Transform( string Input )
        {
            char[] Chars = Input.ToCharArray();
            int Length = Chars.Length;

            for( int i = 0; i < Length; ++i )
            {
                short AsInt = Convert.ToInt16( Chars[ i ] );

                if( AsInt >= 'a' && AsInt <= 'z' )
                {
                    if( AsInt > 'm' )
                        AsInt -= 13;
                    else
                        AsInt += 13;
                }
                else if( AsInt >= 'A' && AsInt <= 'Z' )
                {
                    if( AsInt > 'M' )
                        AsInt -= 13;
                    else
                        AsInt += 13;
                }

                Chars[ i ] = Convert.ToChar( AsInt );
            }

            return new string( Chars );
        }
    }
}