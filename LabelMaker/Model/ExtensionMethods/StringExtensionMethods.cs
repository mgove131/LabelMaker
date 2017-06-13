using System.IO;

namespace LabelMaker.Model.ExtensionMethods
{
    /// <summary>
    /// String Extension Methods.
    /// </summary>
    public static class StringExtensionMethods
    {
        /// <summary>
        /// Deletes file at the path. In a try catch, so no errors.
        /// </summary>
        /// <param name="path">Path to delete.</param>
        public static void SafeFileDelete(this string path)
        {
            try
            {
                File.Delete(path);
            }
            catch { }
        }
    }
}
