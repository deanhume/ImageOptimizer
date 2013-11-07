namespace ImageOptimization
{
    using System;
    using System.Drawing;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// The Data URI helper.
    /// </summary>
    internal class DataUriHelper
    {
        /// <summary>
        /// Builds the data URI HTML string.
        /// </summary>
        /// <param name="imageUrl">
        /// The image url.
        /// </param>
        /// <param name="alt">
        /// The alt.
        /// </param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns>
        /// The <see cref="MvcHtmlString"/>.
        /// </returns>
        public MvcHtmlString BuildDataUriHtmlString(string imageUrl, string alt, string width, string height)
        {
            // Get the file type
            string fileType = Path.GetExtension(imageUrl);
            if (fileType != null)
            {
                fileType = fileType.Replace(".", "");
            }

            // Convert the image
            imageUrl = ConvertImageToBase64String(imageUrl);

            return new MvcHtmlString(String.Format("<img alt=\"{0}\" src=\"data:image/{1};base64,{2}\" width=\"{3}\" height=\"{4}\" />", alt, fileType, imageUrl, width, height));
        }

        /// <summary>
        /// The is file size correct.
        /// </summary>
        /// <param name="imageUrl">
        /// The image url.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsFileSizeCorrect(string imageUrl)
        {
            string imagepath = HttpContext.Current.Server.MapPath(imageUrl);

            // determine the length
            long fileLength = new FileInfo(imagepath).Length;
            return fileLength < 32768;
        }


        /// <summary>
        /// Determines if the browser is able to handle Data URIs based on its version.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance [can browser handle data uris]; otherwise, <c>false</c>.
        /// </returns>
        public bool CanBrowserHandleDataUris()
        {
            float browserVersion = -1;

            var httpContext = HttpContext.Current;
            HttpBrowserCapabilities browser = httpContext.Request.Browser;

            if (browser.Browser == "IE")
            {
                browserVersion = (float)(browser.MajorVersion + browser.MinorVersion);
            }

            if (browserVersion > 8 || browserVersion == -1)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Converts the image to base64 string.
        /// </summary>
        /// <param name="imageUrl">The image URL.</param>
        /// <returns>A Base64 string of the image.</returns>
        private string ConvertImageToBase64String(string imageUrl)
        {
            var httpContext = HttpContext.Current;
            string imagepath = httpContext.Server.MapPath(imageUrl);

            using (Image image = Image.FromFile(imagepath))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    // Convert Image to byte[]
                    image.Save(memoryStream, image.RawFormat);
                    byte[] imageBytes = memoryStream.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
    }
}
