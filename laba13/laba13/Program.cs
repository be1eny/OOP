using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace lab13
{
    class Program
    {
        static void Main(string[] args)
        {
            TASDiskInfo diskInfo = new TASDiskInfo();
            diskInfo.DiskInfo();
            TASFileInfo fileInfo = new TASFileInfo();
            fileInfo.FileData(@"/Users/Alex/Univercity/OOP/laba13/laba13/Class1.cs");
            TASDirInfo dirInfo = new TASDirInfo();
            dirInfo.DirInfo(@"/Users/Alex/Univercity");
            TASFileManager fileManager = new TASFileManager();
            fileManager.FileManager("/Users");
            TASLog.SearchByString("FileInfo:");
        }
    }
}