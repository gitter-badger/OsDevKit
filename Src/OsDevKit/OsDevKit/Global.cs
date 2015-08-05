using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsDevKit
{
    public static class Global
    {
        public static ProjectFile CurrentProjectFile { get; set; }
        public static string CurrentProjectFilePath { get; set; }

        public static void Save()
        {
            File.WriteAllText(Path.Combine(Global.CurrentProjectFilePath, Global.CurrentProjectFile.Name + ".proj"), JsonConvert.SerializeObject(Global.CurrentProjectFile));
        }

    }
}
