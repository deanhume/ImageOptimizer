namespace ImageOptimization
{
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// The image helper.
    /// </summary>
    public static class ImageHelper
    {
        private static readonly WebPHelper WebPHelper = new WebPHelper();
        private static readonly DataUriHelper DataUriHelper = new DataUriHelper();

        /// <summary>
        /// The method that will return the correct image.
        /// </summary>
        /// <param name="helper">
        /// The helper.
        /// </param>
        /// <param name="imageUrl">
        /// The image url.
        /// </param>
        /// <param name="alt">
        /// The alt tag.
        /// </param>
        /// <returns>
        /// The <see cref="MvcHtmlString"/>.
        /// </returns>
        public static MvcHtmlString DrawImage(this HtmlHelper helper, string imageUrl, string alt)
        {
            // Check the size of the image
            if (DataUriHelper.CanBrowserHandleDataUris() && DataUriHelper.IsFileSizeCorrect(imageUrl))
            {
                // If its the right size, return a data URI
                return DataUriHelper.BuildDataUriHtmlString(imageUrl, alt);
            }

            // Else if its the wrong size, return a WebP image
            return WebPHelper.BuildWebPHtmlString(imageUrl, alt);
        }
    }
}
