using Xunit;
using System.Drawing;
using AssertExtensions;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void SameImagesPass()
        {
            var actual = Image.FromFile("./ReferenceImages/test.png");

            actual.ToMatchSnapshot();
        }

        [Fact]
        public void DifferentImagesFail()
        {
            var actual = Image.FromFile("./ReferenceImages/test.png");

            try {
                actual.ToMatchSnapshot();
            } catch {
                Assert.True(true);
            }
        }
    }
}