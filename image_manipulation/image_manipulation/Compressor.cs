using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageManipulation
{
    class Compressor
    {
        /// <summary>
        /// Retrieves the right ImageCodecInfo based on the ImageFormat passed. Returns null if the codec is not found.
        /// </summary>
        /// <param name="format"></param>
        /// <returns>ImageCodecInfo</returns>
        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();
            foreach(var codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                    return codec;
            }
            return null;
        }

        /// <summary>
        /// Compress an image with the specified compression rate and image format wanted.
        /// </summary>
        /// <param name="image"></param>
        /// <param name="format"></param>
        /// <param name="rate"></param>
        /// <returns>Converted image in a byte[] struct.</returns>
        public byte[] Compress(byte[] image, ImageFormat format, long rate)
        {
            var encoder = GetEncoder(format);

            using var inStream = new MemoryStream(image);
            using var outStream = new MemoryStream();
            var img = Image.FromStream(inStream);
            if (encoder == null)
                img.Save(outStream, format);
            else
            {
                var qualityEncoder = Encoder.Quality;
                var encoderParameters = new EncoderParameters(1);
                encoderParameters.Param[0] = new EncoderParameter(qualityEncoder, rate);
                img.Save(outStream, encoder, encoderParameters);
            }
            return outStream.ToArray();
        }

        /// <summary>
        /// Recursive function to compress an image to an approximate size.
        /// </summary>
        /// <param name="img"></param>
        /// <param name="format"></param>
        /// <param name="maxSize"></param>
        /// <param name="compressRate"></param>
        /// <returns>Converted image in a byte[] struct.</returns>
        public byte[] CompressToSize(byte[] img, ImageFormat format, long maxSize, long compressRate)
        {
            if (img.Length >= maxSize && compressRate < 200)
            {
                img = Compress(img, format, 100L - compressRate);
                return CompressToSize(img, format, maxSize, compressRate + compressRate);
            }
            else
                return img;
        }
    }
}
