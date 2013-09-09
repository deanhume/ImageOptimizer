namespace ImageOptimization.Tests
{
    using System.Configuration;
    using System.IO;
    using System.Threading;

    using NUnit.Framework;

    [TestFixture]
    public class ConverterTests
    {
        readonly string imagesFolder = ConfigurationManager.AppSettings["ImagesFolder"];

        [Test]
        public void ConvertImage_ShouldConvertAllImages()
        {
            // Arrange
            
            // Act
            Converter.Start();

            // Assert
            Assert.That(Directory.GetFiles(this.imagesFolder).Length, Is.GreaterThan(3));

            // Cleanup
            CleanUpAfter();
        }

        #region CleanUp

        private void CleanUpAfter()
        {
            // Stop for a second to catchup 
            // It seems to be deleting too fast!!
            Thread.Sleep(3000);

            var directory = new DirectoryInfo(this.imagesFolder);

            // Delete all webp files so that we have a clean start for the next run
            foreach (FileInfo file in directory.GetFiles())
            {
                if (file.Extension == ".webp")
                {
                    file.Delete();    
                }
            }
        }

        #endregion
    }
}
