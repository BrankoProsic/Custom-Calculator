using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Calculator
{
    public class SaveToTextFileRepository : IRepository
    {
        
        public void SaveHistory(string text) // ova metoda je beskorisna trenutno, popravi je
            // pokusaj da shvatis kako da upotrebis parametar, ona mora da dodbije neki tekst da bi ga upisala!!!
        {
            string filePath =
                @"C:\Users\brank\Desktop\PROJECTS\APLIKACIJE\CALCULATORS\Calculator WF\Custom Calculator\history.txt";
            //string history =
            File.AppendAllText(filePath, text);

        }

        //private void CheckFile()
        //{
        //    string path = $"{directory}{displayHistory}";

        //    if (!File.Exists(path))
        //    {
        //        //Create the directory
        //        if (!Directory.Exists(path))
        //            Directory.CreateDirectory(directory);

        //        //Create the empty file
        //        FileStream fs = File.Create(path);
        //    }
        //}
    }
}
