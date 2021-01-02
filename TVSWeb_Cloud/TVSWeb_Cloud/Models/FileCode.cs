using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace TVSWeb_Cloud.Models
{
    public static class FileCode
    {
        public static string Create(string fileName, string path, string content)
        {
            using (StreamWriter streamWriter = new StreamWriter(path + "/" + fileName))
            {
                streamWriter.WriteLine(content);

            }

            return path + fileName;
        }

        public static void Delete(string fileName, string path)
        {
            File.Delete(path + "/" + fileName);
        }
    }
}