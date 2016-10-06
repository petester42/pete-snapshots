using System.Drawing;
using System.IO;

namespace PMSnapshot
{
    internal static class ImageExtensions
    {
        internal static byte[] ByteArray(this Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }
    }
}