using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace System.IO
{
    /// <summary>
    ///     Provides extensions methods for the System.IO.DirectoryInfo class.
    /// </summary>
    public static class DirectoryInfoExtensions
    {
        /// <summary>
        ///     Gets an array of the files in a specific directory, filtering results against a regular expression.
        /// </summary>
        /// <param name="directory">The DirectoryInfo object to pull files from.</param>
        /// <param name="filter">An instance of the System.Text.RegularExpression.Regex class to test file names against.</param>
        /// <returns>A lazy enumerator of FileInfo validated against the regular expression.</returns>
        public static IEnumerable<FileInfo> EnumerateFiles( this DirectoryInfo directory, Regex filter )
            => directory.EnumerateFiles( filter, SearchOption.TopDirectoryOnly );

        /// <summary>
        ///     Gets an array of the files in a specific directory, filtering results against a regular expression.
        /// </summary>
        /// <param name="directory">The DirectoryInfo object to pull files from.</param>
        /// <param name="filter">An instance of the System.Text.RegularExpression.Regex class to test file names against.</param>
        /// <returns>An array of the FileInfo class validated against the regular expression.</returns>
        public static FileInfo[] GetFiles( this DirectoryInfo directory, Regex filter )
            => directory.EnumerateFiles( filter ).ToArray();

        /// <summary>
        ///     Gets an array of the files in a specific directory, filtering results against a regular expression.
        /// </summary>
        /// <param name="directory">The DirectoryInfo object to pull files from.</param>
        /// <param name="filter">An instance of the System.Text.RegularExpression.Regex class to test file names against.</param>
        /// <param name="search">Denotes whether to search the top-level directory only or recursively list files.</param>
        /// <returns>A lazy enumerator of FileInfo validated against the regular expression.</returns>
        public static IEnumerable<FileInfo> EnumerateFiles(
            this DirectoryInfo directory,
            Regex filter,
            SearchOption search )
            => directory.EnumerateFiles( "*", search ).Where( f => filter.IsMatch( f.Name ) );

        /// <summary>
        ///     Gets an array of the files in a specific directory, filtering results against a regular expression.
        /// </summary>
        /// <param name="directory">The DirectoryInfo object to pull files from.</param>
        /// <param name="filter">An instance of the System.Text.RegularExpression.Regex class to test file names against.</param>
        /// <param name="search">Denotes whether to search the top-level directory only or recursively list files.</param>
        /// <returns>An array of the FileInfo class validated against the regular expression.</returns>
        public static FileInfo[] GetFiles( this DirectoryInfo directory, Regex filter, SearchOption search )
            => directory.EnumerateFiles( filter, search ).ToArray();

        /// <summary>
        ///     Gets an array of the files in a specific directory, filtering results against a regular expression.
        /// </summary>
        /// <param name="directory">The DirectoryInfo object to pull files from.</param>
        /// <param name="filter">
        ///     A method that is called to test each file against user-defined standards. This method passes the
        ///     FileInfo object as it's only argument and should return true if the file meets the criteria, false otherwise.
        /// </param>
        /// <returns>A lazy enumerator of FileInfo validated by the filter.</returns>
        public static IEnumerable<FileInfo> EnumerateFiles( this DirectoryInfo directory, Func<FileInfo, bool> filter )
            => directory.EnumerateFiles( filter, SearchOption.TopDirectoryOnly );

        /// <summary>
        ///     Gets an array of the files in a specific directory, filtering results against a regular expression.
        /// </summary>
        /// <param name="directory">The DirectoryInfo object to pull files from.</param>
        /// <param name="filter">
        ///     A method that is called to test each file against user-defined standards. This method passes the
        ///     FileInfo object as it's only argument and should return true if the file meets the criteria, false otherwise.
        /// </param>
        /// <returns>An array of the FileInfo class validated by the FilterCallback.</returns>
        public static FileInfo[] GetFiles( this DirectoryInfo directory, Func<FileInfo, bool> filter )
            => directory.EnumerateFiles( filter, SearchOption.TopDirectoryOnly ).ToArray();

        /// <summary>
        ///     Gets an array of the files in a specific directory, filtering results against a regular expression.
        /// </summary>
        /// <param name="directory">The DirectoryInfo object to pull files from.</param>
        /// <param name="filter">
        ///     A method that is called to test each file against user-defined standards. This method passes the
        ///     FileInfo object as it's only argument and should return true if the file meets the criteria, false otherwise.
        /// </param>
        /// <param name="search">Denotes whether to search the top-level directory only or recursively list files.</param>
        /// <returns>A lazy enumerator of FileInfo validated by the FilterCallback.</returns>
        public static IEnumerable<FileInfo> EnumerateFiles(
            this DirectoryInfo directory,
            Func<FileInfo, bool> filter,
            SearchOption search )
            => directory.EnumerateFiles( "*", search ).Where( filter );

        /// <summary>
        ///     Gets an array of the files in a specific directory, filtering results against a regular expression.
        /// </summary>
        /// <param name="directory">The DirectoryInfo object to pull files from.</param>
        /// <param name="filter">
        ///     A method that is called to test each file against user-defined standards. This method passes the
        ///     FileInfo object as it's only argument and should return true if the file meets the criteria, false otherwise.
        /// </param>
        /// <param name="search">Denotes whether to search the top-level directory only or recursively list files.</param>
        /// <returns>An array of the FileInfo class validated by the FilterCallback.</returns>
        public static FileInfo[] GetFiles(
            this DirectoryInfo directory,
            Func<FileInfo, bool> filter,
            SearchOption search )
            => directory.EnumerateFiles( filter, search ).ToArray();
    }
}
