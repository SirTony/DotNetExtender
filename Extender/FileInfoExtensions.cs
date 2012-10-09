namespace System.IO
{
    using Security.Cryptography;

    /// <summary>
    /// Provides extension methods for the System.IO.FileInfo class.
    /// </summary>
    public static class FileInfoExtensions
    {
        /// <summary>
        /// Computes the hash of a file using the specified hash algorithm.
        /// </summary>
        /// <param name="iFileInfo">The file to hash.</param>
        /// <param name="iHashAlgorithm">The HashAlgorithm to use when computing the checksum.</param>
        /// <returns>The hexadecimal string representation of the file's checksum.</returns>
        public static string GetChecksum( this FileInfo iFileInfo, HashAlgorithm iHashAlgorithm )
        {
            return iFileInfo.GetChecksum( iHashAlgorithm, false );
        }

        /// <summary>
        /// Computes the hash of a file using the specified hash algorithm.
        /// </summary>
        /// <param name="iFileInfo">The file to hash.</param>
        /// <param name="iHashAlgorithm">The HashAlgorithm to use when computing the checksum.</param>
        /// <param name="Uppercase">Whether or not to return the hash as an upper-case string.</param>
        /// <returns>The hexadecimal string representation of the file's checksum.</returns>
        public static string GetChecksum( this FileInfo iFileInfo, HashAlgorithm iHashAlgorithm, bool Uppercase )
        {
            string HashString = "";

            using( iHashAlgorithm )
            using( FileStream iFileStream = File.Open( iFileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read ) )
            {
                byte[] HashBytes = iHashAlgorithm.ComputeHash( iFileStream );
                string Format = ( Uppercase ) ? "X2" : "x2";

                foreach( byte HashByte in HashBytes )
                    HashString += HashByte.ToString( Format );
            }

            return HashString;
        }
    }
}