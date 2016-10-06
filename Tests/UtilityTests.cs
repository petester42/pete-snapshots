using Xunit;
using System.Drawing;
using PMSnapshot;
using System;

namespace Tests
{
    public class UtilityTests
    {
        [Fact]
        public void ImagePathWillBeNullWithNoEnvironmentVariable()
        {
            var actual = PMSnapshot.Utility.GetImagePath("Test/Path", "TestClass", "PassingTest");

            Assert.Null(actual);
        }

        [Fact]
        public void ImagePathWillBeValidWithEnvironmentVariable()
        {
            Environment.SetEnvironmentVariable("PM_REFERENCE_IMAGE_DIR", "ReferenceImages");

            var actual = PMSnapshot.Utility.GetImagePath("TestClass", "PassingTest");
            var expected = "ReferenceImages/TestClass/PassingTest.png";

            Assert.NotNull(actual);
            Assert.Equal(expected, actual);

            Environment.SetEnvironmentVariable("PM_REFERENCE_IMAGE_DIR", null);
        }

        [Fact]
        public void ImagePathWillBeValidWithEnvironmentVariableAndImageName()
        {
            Environment.SetEnvironmentVariable("PM_REFERENCE_IMAGE_DIR", "ReferenceImages");

            var actual = PMSnapshot.Utility.GetImagePath("TestClass", "PassingTest", "Before");
            var expected = "ReferenceImages/TestClass/PassingTest_Before.png";

            Assert.NotNull(actual);
            Assert.Equal(expected, actual);

            Environment.SetEnvironmentVariable("PM_REFERENCE_IMAGE_DIR", null);
        }
    }
}