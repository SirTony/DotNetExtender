using System.Linq;
using System.Security.Cryptography;

namespace System.IO
{
    /// <summary>
    ///     Provides extension methods for the System.IO.FileInfo class.
    /// </summary>
    public static class FileInfoExtensions
    {
        /// <summary>
        ///     Computes the hash of a file using the specified hash algorithm.
        /// </summary>
        /// <param name="file">The file to hash.</param>
        /// <param name="algorithm">The HashAlgorithm to use when computing the checksum.</param>
        /// <param name="upper">Whether or not to return the hash as an upper-case string.</param>
        /// <returns>The hexadecimal string representation of the file's checksum.</returns>
        public static string GetChecksum( this FileInfo file, HashAlgorithm algorithm, bool upper = false )
        {
            using( algorithm )
            using( var stream = File.Open( file.FullName, FileMode.Open, FileAccess.Read, FileShare.Read ) )
            {
                return algorithm.ComputeHash( stream ).Select( b => b.ToString( upper ? "X2" : "x2" ) ).Join( "" );
            }
        }

        /// <summary>
        ///     Computes the hash of a file using the specified hash algorithm.
        /// </summary>
        /// <typeparam name="T">The hash algorithm to use when computing the checksum</typeparam>
        /// <param name="file">The file to hash.</param>
        /// <param name="upper">Whether or not to return the hash as an upper-case string.</param>
        /// <returns>The hexadecimal string representation of the file's checksum.</returns>
        public static string GetChecksum<T>( this FileInfo file, bool upper = false )
            where T : HashAlgorithm, new()
            => file.GetChecksum( new T(), upper );
    }
}
