using Xunit;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Runtime.CompilerServices;

namespace AssertExtensions
{
    public static class AssertExtensions
    {
       public static void ToMatchSnapshot(this Image actual, string imageName = null, [CallerMemberName] string memberName = null, [CallerFilePath] string filePath = null)
        {
            var expected = Image.FromFile(GetImagePath(filePath, memberName, imageName));

            Assert.True(expected.Size.Equals(actual.Size));

            var actualBytes = actual.ByteArray();
            var expectedBytes = expected.ByteArray();

            var imagesAreEqual = StructuralComparisons.StructuralEqualityComparer.Equals(actualBytes, expectedBytes);

            Assert.Equal(actualBytes, expectedBytes);
        }

        private static byte[] ByteArray(this Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private static string GetImagePath(string filePath, string memberName, string imageName = null) {
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            return string.Format("{0}/{1}/{2}", "./ReferenceImages", fileName, GetUniqueTestImageName(filePath, memberName, imageName));
        }

        private static string GetUniqueTestImageName(string filePath, string memberName, string imageName = null) {
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            if (imageName == null) {
                return string.Format("{0}_{1}.png", fileName, memberName);
            } else {
                return string.Format("{0}_{1}_{2}.png", fileName, memberName, imageName);
            }
        }
    }
}