using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ReportSharpCore.Helper
{
    public static class StorageFileExtensions
    {
        public static async Task<StorageFile> TryGetFileFromPathAsync(string path)
        {
            try
            {
                return await StorageFile.GetFileFromPathAsync(path);
            }
            catch (FileNotFoundException)
            {
                return null;
            }
        }
    }
}
