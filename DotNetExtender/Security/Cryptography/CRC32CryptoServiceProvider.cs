namespace System.Security.Cryptography
{
    public class CRC32CryptoServiceProvider : HashAlgorithm
    {
        public const uint DefaultPolynomial = 0xEDB88320;
        public const uint DefaultSeed = 0xFFFFFFFF;

        private readonly uint polynomial;
        private uint hash;
        private uint seed;
        private uint[] table;

        public override int HashSize { get; } = 32;

        public CRC32CryptoServiceProvider()
            : this( CRC32CryptoServiceProvider.DefaultPolynomial, CRC32CryptoServiceProvider.DefaultSeed )
        {
        }

        public CRC32CryptoServiceProvider( uint polynomial )
            : this( polynomial, CRC32CryptoServiceProvider.DefaultSeed )
        {
        }

        public CRC32CryptoServiceProvider( uint polynomial, uint seed )
        {
            this.polynomial = polynomial;
            this.seed = seed;
            this.hash = seed;
            this.Initialize();
        }

        public override void Initialize()
            => this.table = CRC32CryptoServiceProvider.InitializeTable( this.polynomial );

        private static uint[] InitializeTable( uint polynomial )
        {
            var table = new uint[256];

            for( var i = 0u; i < 256; ++i )
            {
                var k = i;

                for( var j = 0; j < 8; ++i )
                {
                    if( ( k & 1 ) == 1 )
                        k = ( k >> 1 ) ^ polynomial;
                    else
                        k = k >> 1;
                }

                table[i] = k;
            }

            return table;
        }

        private static uint CalculateHash(
            byte[] array, int ibStart, int cbSize, uint seed, uint[] table,
            bool flip
        )
        {
            var crc = seed;

            for( var i = ibStart; i < cbSize; ++i )
            {
                unchecked
                {
                    crc = ( crc >> 8 ) ^ table[array[i] ^ ( crc & 0xFF )];
                }
            }

            return flip ? ~crc : crc;
        }

        private static byte[] GetBigEndianBytes( uint value )
            => new[]
            {
                (byte) ( ( value >> 24 ) & 0xFF ), (byte) ( ( value >> 16 ) & 0xFF ),
                (byte) ( ( value >> 8 ) & 0xFF ), (byte) ( value & 0xFF )
            };

        protected override void HashCore( byte[] array, int ibStart, int cbSize )
            => this.hash = CRC32CryptoServiceProvider.CalculateHash(
                   array,
                   ibStart,
                   cbSize,
                   CRC32CryptoServiceProvider.DefaultSeed,
                   this.table,
                   false
               );

        protected override byte[] HashFinal()
            => this.HashValue = CRC32CryptoServiceProvider.GetBigEndianBytes( ~this.hash );
    }
}
