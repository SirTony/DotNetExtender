namespace System.IO
{
    using Text.RegularExpressions;
    using Collections.Generic;

    /// <summary>
    /// Provides extensions methods for the System.IO.DirectoryInfo class.
    /// </summary>
    public static class DirectoryInfoExtensions
    {
        /// <summary>
        /// Gets an array of the files in a specific directory, filtering results against a regular expression.
        /// </summary>
        /// <param name="iDirectoryInfo">The DirectoryInfo object to pull files from.</param>
        /// <param name="RegexFilter">An instance of the System.Text.RegularExpression.Regex class to test file names against.</param>
        /// <returns>An array of the FileInfo class validated against the regular expression.</returns>
        public static FileInfo[] GetFiles( this DirectoryInfo iDirectoryInfo, Regex RegexFilter )
        {
            return iDirectoryInfo.GetFiles( RegexFilter, SearchOption.TopDirectoryOnly );
        }

        /// <summary>
        /// Gets an array of the files in a specific directory, filtering results against a regular expression.
        /// </summary>
        /// <param name="iDirectoryInfo">The DirectoryInfo object to pull files from.</param>
        /// <param name="RegexFilter">An instance of the System.Text.RegularExpression.Regex class to test file names against.</param>
        /// <param name="iSearchOption">Denotes whether to search the top-level directory only or recursively list files.</param>
        /// <returns>An array of the FileInfo class validated against the regular expression.</returns>
        public static FileInfo[] GetFiles( this DirectoryInfo iDirectoryInfo, Regex RegexFilter, SearchOption iSearchOption )
        {
            FileInfo[] Files = iDirectoryInfo.GetFiles( "*", iSearchOption );
            List<FileInfo> MatchedFiles = new List<FileInfo>();

            foreach( FileInfo iFile in Files )
            {
                if( RegexFilter.IsMatch( iFile.Name ) )
                    MatchedFiles.Add( iFile );
            }

            return MatchedFiles.ToArray();
        }

        /// <summary>
        /// Gets an array of the files in a specific directory, filtering results against a regular expression.
        /// </summary>
        /// <param name="iDirectoryInfo">The DirectoryInfo object to pull files from.</param>
        /// <param name="FilterCallback">A method that is called to test each file against user-defined standards. This method passes the FileInfo object as it's only argument and should return true if the file meets the criteria, false otherwise.</param>
        /// <returns>An array of the FileInfo class validated by the FilterCallback.</returns>
        public static FileInfo[] GetFiles( this DirectoryInfo iDirectoryInfo, Func<FileInfo, bool> FilterCallback )
        {
            return iDirectoryInfo.GetFiles( FilterCallback, SearchOption.TopDirectoryOnly );
        }

        /// <summary>
        /// Gets an array of the files in a specific directory, filtering results against a regular expression.
        /// </summary>
        /// <param name="iDirectoryInfo">The DirectoryInfo object to pull files from.</param>
        /// <param name="FilterCallback">A method that is called to test each file against user-defined standards. This method passes the FileInfo object as it's only argument and should return true if the file meets the criteria, false otherwise.</param>
        /// <param name="iSearchOption">Denotes whether to search the top-level directory only or recursively list files.</param>
        /// <returns>An array of the FileInfo class validated by the FilterCallback.</returns>
        public static FileInfo[] GetFiles( this DirectoryInfo iDirectoryInfo, Func<FileInfo, bool> FilterCallback, SearchOption iSearchOption )
        {
            FileInfo[] Files = iDirectoryInfo.GetFiles( "*", iSearchOption );
            List<FileInfo> FilteredFiles = new List<FileInfo>();

            foreach( FileInfo iFile in Files )
            {
                if( FilterCallback( iFile ) )
                    FilteredFiles.Add( iFile );
            }

            return FilteredFiles.ToArray();
        }
    }
}