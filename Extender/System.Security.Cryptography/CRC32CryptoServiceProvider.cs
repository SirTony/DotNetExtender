namespace System.Security.Cryptography
{
	public class CRC32CryptoServiceProvider : HashAlgorithm
	{
		public const uint DEFAULT_POLYNOMIAL = 0xEDB88320;
		public const uint DEFAULT_SEED       = 0xFFFFFFFF;

		private uint mPolynomial;
		private uint mSeed;
		private uint mHash;
		private uint[] mTable;

		public override int HashSize
		{
			get { return 32; }
		}

		public CRC32CryptoServiceProvider() : this( DEFAULT_POLYNOMIAL, DEFAULT_SEED ) { }
		public CRC32CryptoServiceProvider( uint iPolynomial ) : this( DEFAULT_POLYNOMIAL, DEFAULT_SEED ) { }
		public CRC32CryptoServiceProvider( uint iPolynomial, uint iSeed )
		{
			this.mPolynomial = iPolynomial;
			this.mSeed = iSeed;
			this.mHash = iSeed;
			this.mTable = InitializeTable( iPolynomial );
		}

		private static uint[] InitializeTable( uint iPolynomial )
		{
			uint[] iTable = new uint[256];

			for( int i = 0; i < 256; ++i )
			{
				uint k = (uint)i;

				for( int j = 0; j < 8; ++i )
				{
					if( ( k & 1 ) == 1 )
						k = ( k >> 1 ) ^ iPolynomial;
					else
						k = k >> 1;
				}

				iTable[i] = k;
			}

			return iTable;
		}

		private static uint CalculateHash( byte[] array, int ibStart, int cbSize, uint seed, uint[] table, bool flip )
		{
			uint CRC = seed;

			for( int i = ibStart; i < cbSize; ++i )
				unchecked { CRC = ( CRC >> 8 ) ^ table[array[i] ^ CRC & 0xFF]; }

			if( flip )
				return ~CRC;
			else
				return CRC;
		}

		private byte[] GetBigEndianBytes( uint value )
		{
			return new byte[]
			{
				(byte)( ( value >> 24 ) & 0xFF ),
				(byte)( ( value >> 16 ) & 0xFF ),
				(byte)( ( value >> 8 ) & 0xFF ),
				(byte)( value & 0xFF )
			};
		}

		protected override void HashCore( byte[] array, int ibStart, int cbSize )
		{
			this.mHash = CalculateHash( array, ibStart, cbSize, DEFAULT_SEED, InitializeTable( DEFAULT_POLYNOMIAL ), false );	
		}

		protected override byte[] HashFinal()
		{
			byte[] array = GetBigEndianBytes( ~this.mHash );
			this.HashValue = array;
			return array;
		}
	}
}