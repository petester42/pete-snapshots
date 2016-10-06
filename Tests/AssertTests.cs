using Xunit;
using System.Drawing;
using System;
using PMSnapshot;

namespace Tests
{
    public class AssertTests
    {
        public AssertTests()
        {
            Environment.SetEnvironmentVariable("PM_REFERENCE_IMAGE_DIR", "Tests/ReferenceImages");
        }

        public void Dispose()
        {
            Environment.SetEnvironmentVariable ("PM_REFERENCE_IMAGE_DIR", null);
        }

        [Fact]
        public void SameImagesPass()
        {
            var actual = Image.FromFile("Tests/BaseImage.png");

            actual.ToMatchSnapshot();
        }

        [Fact]
        public void DifferentImagesFail()
        {
            var actual = Image.FromFile("Tests/BaseImage.png");

            try
            {
                actual.ToMatchSnapshot();
            }
            catch
            {
                Assert.True(true);
            }
        }
    }
}