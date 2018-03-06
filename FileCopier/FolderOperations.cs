using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopier
{
    static class FolderOperations
    {
        public static void RemoveEmptyFolders(string root)
        {
            foreach (var directory in Directory.GetDirectories(root))
            {
                RemoveEmptyFolders(directory);
                if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }

        public static int CheckFilesWithName(string name, string path)
        {
            return Directory.GetFiles(path, "*" + FilePathDeconstructor.PathWithoutExt(name) + "*").Count();

        }

        /// <summary>
        /// </summary>
        /// <param name="location"></param>
        /// <param name="searchSubfolders"></param>
        /// <returns></returns>
        public static int CalculateNumFiles(string location, bool searchSubfolders)
        {
            SearchOption option = (searchSubfolders) ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            return Directory.GetFiles(location, "*.*", option).Length;
        }

    }
}
