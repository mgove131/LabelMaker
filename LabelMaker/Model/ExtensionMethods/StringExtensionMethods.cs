using System.IO;

namespace LabelMaker.Model.ExtensionMethods
{
    public static class StringExtensionMethods
    {
        public static void SafeDelete(this string path)
        {
            try
            {
                File.Delete(path);
            }
            catch { }
        }
    }
}
