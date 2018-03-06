using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCopier
{
    static class FilePathDeconstructor
    {
        public static string PathWithoutExt(string file)
        {
            return file.Substring(0, file.LastIndexOf('.'));
        }

        public static string GetExt(string file)
        {
            return file.Substring(file.LastIndexOf('.'));
        }


    }
}
