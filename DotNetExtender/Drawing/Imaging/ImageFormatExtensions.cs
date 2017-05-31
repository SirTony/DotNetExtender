using System.Linq;

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
        /// <param name="format">The image format to search.</param>
        /// <returns>The codec info for the specified image format, or null if none could be found.</returns>
        public static ImageCodecInfo GetEncoder( this ImageFormat format ) => ImageCodecInfo.GetImageDecoders().FirstOrDefault( codec => codec.FormatID == format.Guid );
    }
}