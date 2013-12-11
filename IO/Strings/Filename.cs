using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stufkan.IO
{
    /// <summary>
    /// Methods to perform on filenames
    /// </summary>
    public static class Filename
    {
        /// <summary>
        /// Returns the last part of a filepath
        /// </summary>
        /// <param name="filepath">The filepath to parse</param>
        /// <returns>The last part of the specified <paramref name="filepath"/></returns>
        public static string getFilename(this string filepath)
        {
            return filepath.Split(new Char[] { '\\' }).Last();
        }

        /// <summary>
        /// Strips a file or folder from the path on a List of strings. C:/ProgramFiles/Vlc/VLC.exe becomes VLC.exe
        /// </summary>
        /// <param name="Files"></param>
        public static void stripPath(List<string> Files)
        {

            for (int i = 0; i < Files.Count; i++)
            {
                Files[i] = Files[i].getFilename();
            }
        }
    }
}
