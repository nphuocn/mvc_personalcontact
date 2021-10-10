using Newtonsoft.Json.Linq;
using System.IO;

namespace MVC.NetCore.Commons
{
    public static class FileExtenstions
    {
        /// <summary>
        /// Create a json file for calling Post method
        /// </summary>
        /// <param name="path">Directory to containt the file</param>
        /// <param name="fileName">File name</param>
        /// <param name="obj">Object content</param>
        public static void CreateJsonFile(string path, string fileName, JObject obj)
        {
            if (!string.IsNullOrEmpty(path) && !string.IsNullOrEmpty(fileName))
            {
                if(!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string filePath = Path.Combine(path, fileName);
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);

                // Write to file
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    streamWriter.Write(json);
                    streamWriter.Flush();
                }
            }
        }
    }
}
