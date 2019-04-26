using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppExecuteHelper
{
    class FileUtil
    {
        /// <summary>
        /// 读取模块名与模块String[]
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Dictionary<string, List<string>> ReadConfigFile(string filename)
        {
            var result = new Dictionary<string, List<string>>();
            string content;
            using (var file = new FileStream(filename, FileMode.Open))
            using (var reader = new StreamReader(file))
            {
                string currentModule = null;
                var currentModuleList = new List<string>();
                while (null != (content = reader.ReadLine()))
                {
                    if (content.Contains("###"))
                    {
                        if (currentModule != null)
                            result.Add(currentModule, currentModuleList);
                        currentModule = content.Replace("#", "").Replace(" ", "");
                        currentModuleList = new List<string>();
                    }
                    else
                    {
                        currentModuleList.Add(content);
                    }
                }
                result.Add(currentModule, currentModuleList);
            }
            return result;
        }

        public static void WriteConfigFile(string filename, Dictionary<string, List<string>> keyValuePairs)
        {
            using (var file = new FileStream(filename, FileMode.Create))
            using (var writer = new StreamWriter(file))
            {
                foreach (var key in keyValuePairs.Keys)
                {
                    writer.WriteLine("##### " + key + " #####");
                    var moduleList = keyValuePairs[key];
                    foreach (var moduleItemString in moduleList)
                        writer.WriteLine(moduleItemString);
                }
            }
        }
    }
}
