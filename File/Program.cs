using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace File
{
    class Program
    {
        static long FileSize(DirectoryInfo directory)
        {
            long size = 0;
            try
            {
                var SizeFile = directory.GetFiles();
                foreach (var files in SizeFile)
                {
                    size += SizeFile.Length;
                }

                var SizeDir = directory.GetDirectories();

                foreach (var dir in SizeDir)
                {
                    size += FileSize(dir);
                } 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return size / 1024;
        }
        static void Main(string[] args)
        {
            int Byte;
            do
            {
                Console.WriteLine("Укажите путь до директории ");
                var dirOnfo = Console.ReadLine();
                var newdir = new DirectoryInfo(dirOnfo);
                if (newdir.Exists)
                {
                    Byte = 1;
                    Console.WriteLine($"объём папки {newdir.Name} = {FileSize(newdir)} mb");
                }
                else
                {
                    Byte = 0;
                    Console.WriteLine("Неверно указан путь до директории");
                }
            } while (Byte == 0);

        }
    }
}
