namespace ImageOptimization
{
    using System.Configuration;
    using System.IO;
    using System.Web;

    /// <summary>
    /// The image converter class.
    /// </summary>
    public static class Converter
    {
        private static readonly string PathToImages;
        private static readonly string WebPToolFolder;

        #region ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="Converter"/> class.
        /// </summary>
        static Converter()
        {
            PathToImages = ConfigurationManager.AppSettings["ImagesFolder"];
            WebPToolFolder = ConfigurationManager.AppSettings["WebPToolFolder"];
        }

        #endregion

        /// <summary>
        /// Convert the images to WebP format.
        /// </summary>
        public static void Start()
        {
            string webPTool = GetWebPFilePath();

            // Loop through the images directory
            string[] filePaths = Directory.GetFiles(GetFullPathToImages());

            foreach (var filePath in filePaths)
            {
                // Break if the file is already a webp file
                if (filePath.Contains("webp"))
                {
                    continue;
                }

                // Current file extension
                string extension = Path.GetExtension(filePath);

                // Dont continue if the file doesnt have an extension for any reason
                if (extension != null)
                {
                    // The webp file name to create
                    string webPfileName = filePath.Replace(extension, ".webp");

                    // Check if the extension is an allowed file type
                    if (IsAllowedFileType(extension) && !filePath.Contains(webPfileName))
                    {
                        // Pass the images to the WebP converter in the format - "cwebp input.png -q 80 -o output.webp"
                        string arguments = string.Format("{0} -q 80 -o {1}", filePath, webPfileName);
                        System.Diagnostics.Process.Start(webPTool, arguments);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the WebP file path.
        /// </summary>
        /// <returns>The WebP file path</returns>
        private static string GetWebPFilePath()
        {
            var httpContext = HttpContext.Current;
            string webPToolFolder = httpContext.Server.MapPath(WebPToolFolder);

            return Path.Combine(webPToolFolder, "cwebp.exe");
        }

        /// <summary>
        /// The full path to the images folder.
        /// </summary>
        /// <returns>The full image path folder.</returns>
        private static string GetFullPathToImages()
        {
            var httpContext = HttpContext.Current;
            return httpContext.Server.MapPath(PathToImages);
        }

        /// <summary>
        /// Check if the file type is an allowed type.
        /// </summary>
        /// <param name="extension">The file extension.</param>
        /// <returns>A boolean based on the file type.</returns>
        private static bool IsAllowedFileType(string extension)
        {
            if (extension.ToLower() == ".jpg")
            {
                return true;
            }

            if (extension.ToLower() == ".gif")
            {
                return true;
            }

            if (extension.ToLower() == ".png")
            {
                return true;
            }

            // File type is not recognized
            return false;
        }
    }
}
