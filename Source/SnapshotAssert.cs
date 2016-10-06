using Xunit;
using System.Drawing;
using System.IO;
using System.Collections;
using System.Runtime.CompilerServices;

namespace PMSnapshot
{
    public static class AssertExtensions
    {
        public static void ToMatchSnapshot(this Image actual, string imageName = null, [CallerMemberName] string testCase = null, [CallerFilePath] string testFilePath = null)
        {
            var testClass = Path.GetFileNameWithoutExtension(testFilePath);

            var expected = Image.FromFile(Utility.GetImagePath(testClass, testCase, imageName));

            Assert.True(expected.Size.Equals(actual.Size));

            var actualBytes = actual.ByteArray();
            var expectedBytes = expected.ByteArray();

            var imagesAreEqual = StructuralComparisons.StructuralEqualityComparer.Equals(actualBytes, expectedBytes);

            Assert.True(imagesAreEqual);
        }
    }
}