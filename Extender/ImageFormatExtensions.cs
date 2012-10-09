namespace System.Drawing.Imaging
{
    /// <summary>
    /// Provides extensions to the System.Drawing.Imaging.ImageFormat class.
    /// </summary>
    public static class ImageFormatExtensions
    {
        /// <summary>
        /// Gets the codec info the specified image format.
        /// </summary>
        /// <param name="Format">The image format to search.</param>
        /// <returns>The codec info for the specified image format, or null if none could be found.</returns>
        public static ImageCodecInfo GetEncoder( this ImageFormat Format )
        {
            ImageCodecInfo[] CodecInfos = ImageCodecInfo.GetImageDecoders();

            foreach( ImageCodecInfo CodecInfo in CodecInfos )
            {
                if( CodecInfo.FormatID == Format.Guid )
                    return CodecInfo;
            }

            return null;
        }
    }
}