using System;

namespace PMSnapshot
{
    internal class Utility
    {
        internal static string GetImagePath(string testClass, string testCase, string imageName = null)
        {
            var referenceImageDirectory = GetReferenceImageDirectory();

            if (referenceImageDirectory == null)
            {
                return null;
            }
            else
            {
                return string.Format("{0}/{1}/{2}", referenceImageDirectory, testClass, GetUniqueTestImageName(testCase, imageName));
            }
        }

        private static string GetUniqueTestImageName(string testCase, string imageName = null)
        {
            if (imageName == null)
            {
                return string.Format("{0}.png", testCase);
            }
            else
            {
                return string.Format("{0}_{1}.png", testCase, imageName);
            }
        }

        private static string GetReferenceImageDirectory()
        {
            string referenceImageDirectory = Environment.GetEnvironmentVariable("PM_REFERENCE_IMAGE_DIR");

            if (referenceImageDirectory == null)
            {
                return null; //handle execption here
            }
            else
            {
                return referenceImageDirectory;
            }
        }
    }
}