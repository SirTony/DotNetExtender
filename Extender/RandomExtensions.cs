namespace System
{
    public static class RandomExtensions
    {
        public static string GenerateString( this Random iRandom, int Length )
        {
            string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            return iRandom.GenerateString( Length, Chars.ToCharArray() );
        }

        public static string GenerateString( this Random iRandom, int Length, char[] Chars )
        {
            string TempString = "";

            for( int i = 1; i <= Length; ++i )
            {
                int CharPos = iRandom.Next( 0, Chars.Length - 1 );
                TempString += Chars[CharPos];
            }

            return TempString;
        }
    }
}