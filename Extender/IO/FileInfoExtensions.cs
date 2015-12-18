using System.Text;
using System.Security.Cryptography;

namespace System.IO
{
    /// <summary>
    /// Provides extension methods for the System.IO.FileInfo class.
    /// </summary>
    public static class FileInfoExtensions
    {
        /// <summary>
        /// Computes the hash of a file using the specified hash algorithm.
        /// </summary>
        /// <param name="file">The file to hash.</param>
        /// <param name="algorithm">The HashAlgorithm to use when computing the checksum.</param>
        /// <returns>The hexadecimal string representation of the file's checksum.</returns>
        public static string GetChecksum( this FileInfo file, HashAlgorithm algorithm )
            => file.GetChecksum( algorithm, false );

        public static string GetChecksum<T>( this FileInfo file ) where T : HashAlgorithm, new()
            => file.GetChecksum( new T() );

        /// <summary>
        /// Computes the hash of a file using the specified hash algorithm.
        /// </summary>
        /// <param name="file">The file to hash.</param>
        /// <param name="algorithm">The HashAlgorithm to use when computing the checksum.</param>
        /// <param name="upper">Whether or not to return the hash as an upper-case string.</param>
        /// <returns>The hexadecimal string representation of the file's checksum.</returns>
        public static string GetChecksum( this FileInfo file, HashAlgorithm algorithm, bool upper )
        {
            var builder = new StringBuilder();

            using( algorithm )
            using( var stream = File.Open( file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read ) )
            {
                var bytes = algorithm.ComputeHash( stream );
                var format = upper ? "X2" : "x2";

                foreach( var @byte in bytes )
                    builder.Append( @byte.ToString( format ) );
            }

            return builder.ToString();
        }

        public static string GetChecksum<T>( this FileInfo file, bool upper ) where T : HashAlgorithm, new()
            => file.GetChecksum( new T(), upper );
    }
}