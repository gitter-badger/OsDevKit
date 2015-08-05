using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsDevKit
{
    public static class Compiler
    {
        public static string Log = "";

        public static void Compile()
        {
            if(Global.CurrentProjectFile == null)
            {
                return;
            }
            Log = "";
            foreach (var i in Global.CurrentProjectFile.Files)
            {
                if(i.EndsWith(".c"))
                {
                    StartProcces("Factory\\CompileC.bat", "" + Path.GetFullPath( Path.Combine(Global.CurrentProjectFilePath, "files" ,i)) + " " + new FileInfo(i).Name.Split('.').First() + " " + Path.GetFullPath(Path.Combine(Global.CurrentProjectFilePath,"files", "include")) , "Factory");
                }
                if (i.EndsWith(".asm"))
                {
                    StartProcces("Factory\\CompileAsm.bat", "" + Path.GetFullPath(Path.Combine(Global.CurrentProjectFilePath, "files", i)) + " " + new FileInfo(i).Name.Split('.').First(), "Factory");

                }
            }
            StartProcces("Factory\\Link.bat","", Path.GetFullPath("Factory"));
            StartProcces("Factory\\BuildBootImage.bat", "", Path.GetFullPath("Factory"));
            var img = Path.Combine(Global.CurrentProjectFilePath, "Bin", "Boot.img");
            File.Delete(img);
            File.Copy("Factory\\Boot.img",img);
            StartProcces("Factory\\Qemu.bat", img, Path.GetFullPath("Factory"));

        }

        public static void StartProcces(string name, string args, string path)
        {


            System.Diagnostics.Process p = new System.Diagnostics.Process();
            // p.StartInfo.WorkingDirectory = new DirectoryInfo( path).FullName ;




             p.StartInfo.UseShellExecute = true;
            //p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            p.StartInfo.FileName = name;
            p.StartInfo.Arguments = args;
            p.Start();
            p.WaitForExit();
        }
    }
}
