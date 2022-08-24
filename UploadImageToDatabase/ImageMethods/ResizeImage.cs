using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace BlazorFormDemo_002.ImageMethods
{
	public class ResizeImage
	{

		public byte[]? Resize(byte[] bytes, int desiredWidth, int desiredHeight)
		{
			try
			{
				Bitmap original;

                using (var ms = new MemoryStream(bytes))
                {
                    original = new Bitmap(ms);
                }

                int sourceWidth = original.Width;
                int sourceHeight = original.Height;
                int sourceX = 0;
                int sourceY = 0;
                int destX = 0;
                int destY = 0;

                float nPercent = 0;
                float nPercentW = 0;
                float nPercentH = 0;

                nPercentW = ((float)desiredWidth / (float)sourceWidth);
                nPercentH = ((float)desiredHeight / (float)sourceHeight);

                if (nPercentH < nPercentW)
                {
                    nPercent = nPercentH;
                    destX = System.Convert.ToInt16((desiredWidth - (sourceWidth * nPercent)) / 2);
                }
                else
                {
                    nPercent = nPercentW;
                    destY = System.Convert.ToInt16((desiredHeight - (sourceHeight * nPercent)) / 2);
                }

                int destWidth = (int)(sourceWidth * nPercent);
                int destHeight = (int)(sourceHeight * nPercent);

                Bitmap bmPhoto = new Bitmap(desiredWidth, desiredHeight, PixelFormat.Format24bppRgb);
                bmPhoto.SetResolution(original.HorizontalResolution, original.VerticalResolution);

                Graphics grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.Clear(Color.Black);
                //grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                grPhoto.InterpolationMode = InterpolationMode.Default;

                grPhoto.DrawImage(original,
                    new Rectangle(destX, destY, destWidth, destHeight),
                    new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                    GraphicsUnit.Pixel);

                grPhoto.Dispose();
                //return bmPhoto;

                return ImageToByte(bmPhoto);
            }
            catch (Exception)
			{

			}

			return null;
		}

        public byte[] ImageToByte(System.Drawing.Image img)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));
        }

    }
}
