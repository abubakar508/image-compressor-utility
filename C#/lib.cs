using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageCompressUtility
{
    public class ImageCompression
    {
        public static byte[] CompressImage(byte[] imageData, long quality)
        {
            using (MemoryStream inputMemoryStream = new MemoryStream(imageData))
            {
                using (MemoryStream outputMemoryStream = new MemoryStream())
                {
                    using (Image image = Image.FromStream(inputMemoryStream))
                    {
                        ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                        EncoderParameters encoderParameters = new EncoderParameters(1);
                        encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);

                        image.Save(outputMemoryStream, jpgEncoder, encoderParameters);
                    }

                    return outputMemoryStream.ToArray();
                }
            }
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }

            return null;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Test the CompressImage method
            byte[] inputImage = File.ReadAllBytes("input.jpg");
            byte[] compressedImage = ImageCompression.CompressImage(inputImage, 50);

            File.WriteAllBytes("output.jpg", compressedImage);
            Console.WriteLine("Image compression complete.");
        }
    }
}
