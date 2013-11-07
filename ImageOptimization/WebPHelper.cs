namespace ImageOptimization
{
    using System;
    using System.IO;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// The WebP helper.
    /// </summary>
    internal class WebPHelper
    {
        /// <summary>
        /// Builds the WebP HTML string.
        /// </summary>
        /// <param name="imageUrl">
        /// The image url.
        /// </param>
        /// <param name="alt">
        /// The alt.
        /// </param>
        /// <returns>
        /// The <see cref="MvcHtmlString"/>.
        /// </returns>
        public MvcHtmlString BuildWebPHtmlString(string imageUrl, string alt)
        {
            if (CanBrowserHandleWebPImages())
            {
                // Get the file type
                string fileType = Path.GetExtension(imageUrl);
                if (fileType != null)
                {
                    imageUrl = imageUrl.Replace(fileType, ".webp");
                    alt = "WebP: " + alt;
                }

                return new MvcHtmlString(String.Format("<img alt=\"{0}\" " + "src=\"{1}\" title=\"{0}\" />", alt, imageUrl));
            }

            return new MvcHtmlString(String.Format("<img alt=\"{0}\" " + "src=\"{1}\" title=\"{0}\" />", alt, imageUrl));
        }

        /// <summary>
        /// Detect if the current browser is capable
        /// of handling WebP images
        /// </summary>
        /// <returns>A boolean based on the result.</returns>
        private bool CanBrowserHandleWebPImages()
        {
            HttpRequest httpRequest = HttpContext.Current.Request;
            HttpBrowserCapabilities browser = httpRequest.Browser;

            if (browser.Type.Contains("Chrome") || browser.Type.Contains("Opera") || browser.Type.Contains("Android"))
            {
                return true;
            }

            return false;
        }
    }
}
