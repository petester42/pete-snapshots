using Xunit;
using System.Drawing;
using AssertExtensions;

namespace Tests
{
    public class Tests
    {
        [Fact]
        public void PassingTest()
        {
            var actual = Image.FromFile("./ReferenceImages/test_a.png");

            actual.ToMatchSnapshot();
        }

        [Fact]
        public void FailingTest()
        {
            var actual = Image.FromFile("./ReferenceImages/test_b.png");

            actual.ToMatchSnapshot();
        }
    }
}