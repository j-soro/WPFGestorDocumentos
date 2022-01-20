using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace WPFGestorDocumentos.Utility
{
    /// <summary>
    /// Clase que contiene funciones útiles relacionadas con imágenes y su transformación.
    /// </summary>
    internal static class CUtility
    {

        /// <summary>
        /// Función para redimensionar una imagen a un tamaño dado por ancho y alto determinados en px.
        /// </summary>
        /// <param name="imgToResize">Imagen original a redimensionar.</param>
        /// <param name="w">Ancho deseado de la imagen resultante, en px.</param>
        /// <param name="h">Alto deseado de la imagen resultante, en px.</param>
        /// <returns>Image</returns>
        public static Image resizeImage(System.Drawing.Image imgToResize, int w, int h)
        {
            Size size = new Size(w, h);
            // Ancho actual
            int sourceWidth = imgToResize.Width;
            // Alto actual
            int sourceHeight = imgToResize.Height;
            float nPercent = 0;
            float nPercentW = 0;
            float nPercentH = 0;
            // Calcula ancho con el nuevo tamaño deseado
            nPercentW = ((float)size.Width / (float)sourceWidth);
            // Calcula alto con el nuevo tamaño deeado 
            nPercentH = ((float)size.Height / (float)sourceHeight);

            if (nPercentH < nPercentW)
                nPercent = nPercentH;
            else
                nPercent = nPercentW;

            // Nuevo ancho
            int destWidth = (int)(sourceWidth * nPercent);

            // Nuevo alto
            int destHeight = (int)(sourceHeight * nPercent);
            Bitmap b = new Bitmap(destWidth, destHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)b);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            // Crear nueva imagen con los tamaños obtenidos 
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();
            return b;
        }

        /// <summary>
        /// Función para transformar un objeto Image a un ByteArray.
        /// </summary>
        /// <param name="imageIn">Imagen a transformar</param>
        /// <returns>byte[]</returns>
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }

        /// <summary>
        /// Función para transformar un objeto ByteArray a un Image.
        /// </summary>
        /// <param name="byteArrayIn">ByteArray que contiene una imagen codificada.</param>
        /// <returns>Image</returns>
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
